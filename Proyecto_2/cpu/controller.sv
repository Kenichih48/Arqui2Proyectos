///////////////////////////////////////////////////////////////////////////////
// Module Name:   controller
// Description:   This module serves as the control unit for a processor.
//                It decodes instructions, manages various control signals,
//                and handles conditional operations.
//
// Inputs:        clk - Clock signal
//                reset - Reset signal
//                InstrD - Decoded instruction
//                ALUFlagsE - Flags generated by the ALU in the execute stage
//
// Outputs:       RegSrcD, ImmSrcD - Control signals for register and immediate sources
//                ALUSrcE, BranchTakenE - Control signals for ALU source and branching
//                ALUControlE - Control signals for the ALU operation
//                MemWriteM, MemtoRegW, PCSrcW, RegWriteW - Control signals for memory and register writes
//                RegWriteM, MemtoRegE - Control signals for memory and register writes in the execute stage
//                PCWrPendingF - Control signal for pending program counter write
//                FlushE - Flush signal for the execute stage
//
// Usage:         Instantiate this module in your processor design to decode instructions,
//                manage control signals, and handle conditional operations.
//
///////////////////////////////////////////////////////////////////////////////

module controller (
    input logic             clk, reset,
    input logic  [26:10]    InstrD,
    input logic  [3:0]      ALUFlagsE,
    output logic [1:0]      RegSrcD, ImmSrcD,
    output logic            ALUSrcE, BranchTakenE, 
    output logic [2:0]      ALUControlE,
    output logic            MemWriteM, MemtoRegW, PCSrcW, RegWriteW,
    //hazard interface
    output logic            RegWriteM, MemtoRegE, 
    output logic            PCWrPendingF, 
    input logic             FlushE);

    logic [9:0] controlsD; 
    logic CondExE, ALUOpD; 
    logic [2:0] ALUControlD; 
    logic ALUSrcD; 
    logic MemtoRegD, MemtoRegM; 
    logic RegWriteD, RegWriteE, RegWriteGatedE;
    logic MemWriteD, MemWriteE, MemWriteGatedE;
    logic BranchD, BranchE; 
    logic [1:0] FlagWriteD, FlagWriteE; 
    logic PCSrcD, PCSrcE, PCSrcM; 
    logic [3:0] FlagsE, FlagsNextE; 
    logic       CondE;
    logic       NoWrite;

    // Decode stage 
    // Main Decoder
    always_comb 
        casex(InstrD[25:23]) 
                    // data-processing escalar
                    // immediate
            3'b000: if (InstrD[22]) controlsD = 10'b0000101001; 
                    // register
                    else            controlsD = 10'b0000001001;

                    // branch    
            3'b001:                 controlsD = 10'b0110100010;

                    // memory escalar
                    // GET
            3'b010: if (InstrD[18]) controlsD = 10'b0001111000; 
                    // PUT
                    else            controlsD = 10'b1001110100; 
                    
                    // unimplemented
            default:                controlsD = 10'bx; 
       endcase 

    assign {RegSrcD, ImmSrcD, ALUSrcD, MemtoRegD, RegWriteD, 
    MemWriteD, BranchD, ALUOpD} = controlsD; 

    // ALU Decoder
    always_comb 
        if (ALUOpD) begin // which Data-processing Instr? 
            case(InstrD[21:19]) 
                3'b000:     ALUControlD = 3'b000;    // SUM
                3'b001:     ALUControlD = 3'b001;    // RES                
                3'b010:     ALUControlD = 3'b010;    // MUL
                3'b011:     ALUControlD = 3'b011;    // DIV
                3'b100:     ALUControlD = 3'b100;    // MOD
                3'b101:     ALUControlD = 3'b101;    // MOV
                3'b110:     ALUControlD = 3'b001;    // EQV
                default:    ALUControlD = 3'bx;      // Unimplemented
            endcase 

            // update flags if S bit is set (C & V only for arithmetic)
            FlagWriteD[1] = InstrD[18];  
            FlagWriteD[0] = InstrD[18] & 
                (ALUControlD == 3'b000 | ALUControlD == 3'b001 |
                ALUControlD == 3'b010 | ALUControlD == 3'b011 | ALUControlD == 3'b100);

            NoWrite = (InstrD[21:19] == 3'b110);

        end else begin  // not Data-processing
            ALUControlD = 3'b000; // perform addition for non-dp instr 
            FlagWriteD = 2'b00; // don't update Flags 
            NoWrite = 1'b0;       // don't update NoWrite
        end

    assign PCSrcD = (((InstrD[17:14] == 4'b1001) & RegWriteD) | BranchD); 

    // Execute stage 
    floprc #(7) flushedregsE(clk, reset, FlushE, {FlagWriteD, BranchD, MemWriteD, RegWriteD, 
    PCSrcD, MemtoRegD}, {FlagWriteE, BranchE, MemWriteE, RegWriteE, PCSrcE, MemtoRegE}); 
    
    flopr #(4) regsE(clk, reset, {ALUSrcD, ALUControlD}, {ALUSrcE, ALUControlE});
    flopr #(1) condregE(clk, reset, InstrD[25], CondE); 
    flopr #(4) flagsreg(clk, reset, FlagsNextE, FlagsE); 
	 
    // Write and Branch controls are conditional 
    conditional Cond(CondE, FlagsE, ALUFlagsE, FlagWriteE, CondExE, FlagsNextE); 
    assign BranchTakenE = BranchE & CondExE; 
    assign RegWriteGatedE = RegWriteE & ~NoWrite & CondExE;
    assign MemWriteGatedE = MemWriteE & CondExE; 
    assign PCSrcGatedE = PCSrcE & CondExE; 

    // Memory stage 
    flopr #(4) regsM(clk, reset, {MemWriteGatedE, MemtoRegE, RegWriteGatedE, PCSrcGatedE}, 
    {MemWriteM, MemtoRegM, RegWriteM, PCSrcM}); 

    // Writeback stage 
    flopr #(3) regsW(clk, reset, {MemtoRegM, RegWriteM, PCSrcM}, {MemtoRegW, RegWriteW, PCSrcW});

    // Hazard Prediction 
    assign PCWrPendingF = PCSrcD | PCSrcE | PCSrcM;
endmodule