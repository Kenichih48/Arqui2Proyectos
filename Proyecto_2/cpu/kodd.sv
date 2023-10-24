///////////////////////////////////////////////////////////////////////////////
// Module Name:   kodd
// Description:   This top-level module represents the core of a processor
//                including the controller, datapath, and hazard management.
//
// Inputs:        clk - Clock signal
//                reset - Reset signal
//                InstrF - Instruction fetched from memory
//                ReadDataM - Data read from memory
//
// Outputs:       PCF - Program Counter value for the next cycle
//                MemWriteM - Control signal for memory write
//                ALUOutM - Result of the ALU operation in the memory stage
//                WriteDataM - Data to be written to memory
//
// Usage:         Instantiate this module as the core of your processor, connecting
//                it to the controller, datapath, and hazard modules.
//
// Example Usage:
// ```
//   kodd myProcessor (
//     .clk(clock),
//     .reset(reset_signal),
//     .InstrF(instruction_from_memory),
//     .ReadDataM(data_read_from_memory),
//     .PCF(program_counter_next_value),
//     .MemWriteM(memory_write_control),
//     .ALUOutM(ALU_result_memory_stage),
//     .WriteDataM(data_to_write_to_memory)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module kodd (
    input logic         clk, reset,  // Clock and Reset signals
    output logic [31:0] PCF,  // Program Counter value for the next cycle
    input logic  [31:0] InstrF,  // Instruction fetched from memory
    output logic        MemWriteM,  // Control signal for memory write
    output logic [31:0] ALUOutM, WriteDataM,  // Result of the ALU operation and data to be written to memory
    input logic  [31:0] ReadDataM  // Data read from memory
);

    logic [1:0] RegSrcD, ImmSrcD;
    logic [2:0] ALUControlE; 
    logic ALUSrcE, BranchTakenE, MemtoRegW, PCSrcW, RegWriteW; 
    logic [3:0] ALUFlagsE; 
    logic [31:0] InstrD; 
    logic RegWriteM, MemtoRegE, PCWrPendingF; 
    logic [1:0] ForwardAE, ForwardBE; 
    logic StallF, StallD, FlushD, FlushE; 
    logic Match_1E_M, Match_1E_W, Match_2E_M, Match_2E_W, Match_12D_E; 

    // Instantiate the controller, datapath, and hazard modules
    controller c(clk, reset, InstrD[26:10], ALUFlagsE, RegSrcD, ImmSrcD, ALUSrcE, 
                BranchTakenE, ALUControlE, MemWriteM, MemtoRegW, PCSrcW, RegWriteW, 
                RegWriteM, MemtoRegE, PCWrPendingF, FlushE); 

    datapath dp(clk, reset, RegSrcD, ImmSrcD, ALUSrcE, BranchTakenE, ALUControlE, 
                MemtoRegW, PCSrcW, RegWriteW, PCF, InstrF, InstrD, ALUOutM, WriteDataM, 
                ReadDataM, ALUFlagsE, Match_1E_M, Match_1E_W, Match_2E_M, Match_2E_W, 
                Match_12D_E, ForwardAE, ForwardBE, StallF, StallD, FlushD); 

    hazard h(clk, reset, Match_1E_M, Match_1E_W, Match_2E_M, Match_2E_W, Match_12D_E, 
                RegWriteM, RegWriteW, BranchTakenE, MemtoRegE, PCWrPendingF, PCSrcW, 
                ForwardAE, ForwardBE, StallF, StallD, FlushD, FlushE);
endmodule