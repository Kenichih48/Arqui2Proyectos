///////////////////////////////////////////////////////////////////////////////
// Module Name:   datapath
// Description:   This module represents the datapath of a pipelined processor,
//                including various stages such as fetch, decode, execute,
//                memory, and writeback.
//
// Inputs:        clk - Clock signal
//                reset - Reset signal
//                RegSrcD, ImmSrcD - Source control for registers and immediate values
//                ALUSrcE, BranchTakenE - Control signals for ALU source and branching
//                ALUControlE - Control signals for the ALU operation
//                MemtoRegW, PCSrcW, RegWriteW - Control signals for memory and register writes
//                InstrF - Instruction input in the fetch stage
//                ReadDataM - Data read from memory
//                StallF, StallD, FlushD - Control signals for stalls and flushes
//
// Outputs:       PCF - Program Counter in the fetch stage
//                InstrD - Instruction in the decode stage
//                ALUOutM, WriteDataM - ALU output and write data in the memory stage
//                ALUFlagsE - Flags generated by the ALU in the execute stage
//                Match_1E_M, Match_1E_W, Match_2E_M, Match_2E_W, Match_12D_E - Hazard detection signals
//
// Usage:         Instantiate this module in your processor design to represent
//                the processor's datapath with various pipeline stages.
//
///////////////////////////////////////////////////////////////////////////////

module datapath (
    input logic         clk, reset,
    input logic  [1:0]  RegSrcD, ImmSrcD,
    input logic         ALUSrcE, BranchTakenE,
    input logic  [2:0]  ALUControlE,
    input logic         MemtoRegW, PCSrcW, RegWriteW,
    input logic         RegWriteVecW, //TODO: nuevos inputs vectoriales
    output logic [31:0] PCF,
    input logic  [31:0] InstrF,
    output logic [31:0] InstrD,
    output logic [31:0] ALUOutM, WriteDataM,
    output logic [31:0] WriteDataMVec[0:3], VectorAddressM[0:3], //TODO: nuevos outputs vectoriales
    input logic  [31:0] ReadDataM,
    input logic  [31:0] ReadDataVecM[0:3], //TODO: nuevos inputs vectoriales
    output logic [3:0]  ALUFlagsE,
    // hazard logic
    output logic        Match_1E_M, Match_1E_W, Match_2E_M, Match_2E_W, Match_12D_E, 
    input logic  [1:0]  ForwardAE, ForwardBE, 
    input logic         StallF, StallD, FlushD);

    logic [31:0] PCPlus4F, PCnext1F, PCnextF; 
    logic [31:0] ExtImmD, rd1D, rd2D, PCPlus8D; 
    logic [31:0] rd1DVec[0:3], rd2DVec[0:3];
    logic [31:0] rd1E, rd2E, ExtImmE, SrcAE, SrcBE, WriteDataE, ALUResultE; 
    logic [31:0] rd1EVec[0:3], rd2EVec[0:3], ALUResultVecE[0:3];
    logic [31:0] ALUResultVecEE[0:3], addressVector[0:3];
    logic [31:0] ReadDataW, ALUOutW, ResultW; 
    logic [31:0] ResultVecW[0:3], ReadDataVecW[0:3], ALUOutMVec[0:3], ALUOutWVec[0:3];
    logic [3:0] RA1D, RA2D, RA1E, RA2E, WA3E, WA3M, WA3W; 
    logic Match_1D_E, Match_2D_E; 

    // Fetch stage 
    mux2 #(32) pcnextmux(PCPlus4F, ResultW, PCSrcW, PCnext1F); 
    mux2 #(32) branchmux(PCnext1F, ALUResultE, BranchTakenE, PCnextF); 
    flopenr #(32) pcreg(clk, reset, ~StallF, PCnextF, PCF); 
    adder #(32) pcadd(PCF, 32'h4, PCPlus4F);

     // Decode Stage 
    assign PCPlus8D = PCPlus4F; // skip register 
    flopenrc #(32) instrreg(clk, reset, ~StallD, FlushD, InstrF, InstrD); 
    mux2 #(4) ra1mux(InstrD[13:10], 4'b1001, RegSrcD[0], RA1D); 
    mux2 #(4) ra2mux(InstrD[3:0], InstrD[17:14], RegSrcD[1], RA2D); 

    regfile rf(clk, RegWriteW, RA1D, RA2D, WA3W, ResultW, PCPlus8D, rd1D, rd2D); 
    //TODO: registro vectorial
    regvectorfile rfv(clk, RegWriteVecW, InstrD[13:10], RA2D, WA3W, ResultVecW, rd1DVec, rd2DVec); 
    //TODO: extend para GET/PUT vectorial no necesario?
    extend ext(InstrD[21:0], ImmSrcD, ExtImmD); 

    // Execute Stage 
    flopr #(32) rd1reg(clk, reset, rd1D, rd1E); 
    flopr #(32) rd2reg(clk, reset, rd2D, rd2E); 

    //TODO: hacer flopr vectorial
    floprvec #(32, 4) rd1regvec(clk, reset, rd1DVec, rd1EVec); 
    floprvec #(32, 4) rd2regvec(clk, reset, rd2DVec, rd2EVec); 

    flopr #(32) immreg(clk, reset, ExtImmD, ExtImmE);
    flopr #(4) wa3ereg(clk, reset, InstrD[17:14], WA3E); 
    flopr #(4) ra1reg(clk, reset, RA1D, RA1E); //TODO: hazards vectoriales
    flopr #(4) ra2reg(clk, reset, RA2D, RA2E);  //TODO: hazards vectoriales
    mux3 #(32) byp1mux(rd1E, ResultW, ALUOutM, ForwardAE, SrcAE); 
    mux3 #(32) byp2mux(rd2E, ResultW, ALUOutM, ForwardBE, WriteDataE); 
    mux2 #(32) srcbmux(WriteDataE, ExtImmE, ALUSrcE, SrcBE); 
    alu #(32) alu(SrcAE, SrcBE, ALUControlE, ALUResultE, ALUFlagsE);
    //TODO: alu vectorial
    vectorfu vecalu(rd1EVec, rd2EVec, ALUControlE, ALUResultVecE);

    //TODO: vector load/store
    vector_load_store vectorls(ALUResultVecE, ALUResultE, ALUResultVecEE, addressVector);

    // Memory Stage 
    flopr #(32) aluresreg(clk, reset, ALUResultE, ALUOutM); 
    flopr #(32) wdreg(clk, reset, WriteDataE, WriteDataM); 
    flopr #(4) wa3mreg(clk, reset, WA3E, WA3M);

    //TODO: flopr vectorial
    floprvec #(32, 4) aluresregvec(clk, reset, ALUResultVecEE, ALUOutMVec); 
    floprvec #(32, 4) wdregvec(clk, reset, rd2EVec, WriteDataMVec); 
    floprvec #(32, 4) varegvec(clk, reset, addressVector, VectorAddressM); 

    // Writeback Stage 
    flopr #(32) aluoutreg(clk, reset, ALUOutM, ALUOutW); 
    flopr #(32) rdreg(clk, reset, ReadDataM, ReadDataW); 
    flopr #(4) wa3wreg(clk, reset, WA3M, WA3W); 

    //TODO: flopr vectorial
    floprvec #(32, 4) aluoutregvec(clk, reset, ALUOutMVec, ALUOutWVec); 
    floprvec #(32, 4) rdregvec(clk, reset, ReadDataVecM, ReadDataVecW); 

    mux2 #(32) resmux(ALUOutW, ReadDataW, MemtoRegW, ResultW); 
    //TODO: ALUOutW, ReadDatW pendiente
    mux2vec #(32, 4) resmuxvec(ALUOutWVec, ReadDataVecW, MemtoRegW, ResultVecW); 
    
    // hazard comparison 
    eqcmp #(4) m0(WA3M, RA1E, Match_1E_M); 
    eqcmp #(4) m1(WA3W, RA1E, Match_1E_W); 
    eqcmp #(4) m2(WA3M, RA2E, Match_2E_M); 
    eqcmp #(4) m3(WA3W, RA2E, Match_2E_W); 
    eqcmp #(4) m4a(WA3E, RA1D, Match_1D_E); 
    eqcmp #(4) m4b(WA3E, RA2D, Match_2D_E); 
    assign Match_12D_E = Match_1D_E | Match_2D_E; 
endmodule