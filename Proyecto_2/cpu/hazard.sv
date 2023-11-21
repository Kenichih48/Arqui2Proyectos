///////////////////////////////////////////////////////////////////////////////
// Module Name:   hazard
// Description:   This module handles hazard detection and control for a
//                pipelined processor, including forwarding, stalls, and flushes.
//
// Inputs:        clk - Clock signal
//                reset - Reset signal
//                Match_1E_M, Match_1E_W, Match_2E_M, Match_2E_W, Match_12D_E - 
//                Hazard detection signals for instruction matches
//                RegWriteM, RegWriteW - Signals indicating register writes in M and W stages
//                BranchTakenE, MemtoRegE - Signals related to branching and memory operations
//                PCWrPendingF, PCSrcW - Signals related to PC writes
//
// Outputs:       ForwardAE, ForwardBE - Forwarding signals for operand A and operand B
//                StallF, StallD - Stall signals for fetch and decode stages
//                FlushD, FlushE - Flush signals for decode and execute stages
//
// Usage:         Instantiate this module in your processor design to manage
//                hazards, forwarding, stalls, and flushes in the pipeline.
//
// Example Usage:
// ```
//   hazard myHazard (
//     .clk(clock),
//     .reset(reset_signal),
//     .Match_1E_M(match_signal_1E_M),
//     .Match_1E_W(match_signal_1E_W),
//     .Match_2E_M(match_signal_2E_M),
//     .Match_2E_W(match_signal_2E_W),
//     .Match_12D_E(match_signal_12D_E),
//     .RegWriteM(register_write_M),
//     .RegWriteW(register_write_W),
//     .BranchTakenE(branch_taken_E),
//     .MemtoRegE(mem_to_register_E),
//     .PCWrPendingF(pc_write_pending_F),
//     .PCSrcW(pc_source_W),
//     .ForwardAE(forwarding_signal_A),
//     .ForwardBE(forwarding_signal_B),
//     .StallF(stall_signal_fetch),
//     .StallD(stall_signal_decode),
//     .FlushD(flush_signal_decode),
//     .FlushE(flush_signal_execute)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module hazard ( 
    input logic        clk, reset, 
    input logic        Match_1E_M, Match_1E_W, Match_2E_M, Match_2E_W, Match_12D_E, Match_12D_E_Vec, 
    input logic        Match_1E_M_Vec, Match_1E_W_Vec, Match_2E_M_Vec, Match_2E_W_Vec, //TODO: hazard vectorial
    input logic        RegWriteM, RegWriteVecM, RegWriteW, RegWriteVecW,
    input logic        BranchTakenE, MemtoRegE, 
    input logic        PCWrPendingF, PCSrcW, 
    output logic [1:0] ForwardAE, ForwardBE, 
    output logic [1:0] ForwardAEVec, ForwardBEVec, 
    output logic       StallF, StallD,
    output logic       FlushD, FlushE
);

    logic ldrStallD, ldrStallDVec; 
    logic StallDVec, StallFVec, FlushEVec;
    logic StallDScalar, StallFScalar, FlushEScalar;

    // Forwarding logic 
    always_comb begin 
        if (Match_1E_M & RegWriteM) ForwardAE = 2'b10; // SrcAE = ALUOutM
        else if (Match_1E_W & RegWriteW) ForwardAE = 2'b01;  // SrcAE = ResultW
        else ForwardAE = 2'b00; // SrcAE from regfile
    
        if (Match_2E_M & RegWriteM) ForwardBE = 2'b10; // SrcAE = ALUOutM
        else if (Match_2E_W & RegWriteW) ForwardBE = 2'b01; // SrcAE = ResultW
        else ForwardBE = 2'b00;  // SrcAE from regfile

        if (Match_1E_M_Vec & RegWriteVecM) ForwardAEVec = 2'b10; // SrcAE = ALUOutM
        else if (Match_1E_W_Vec & RegWriteVecW) ForwardAEVec = 2'b01;  // SrcAE = ResultW
        else ForwardAEVec = 2'b00; // SrcAE from regfile
    
        if (Match_2E_M_Vec & RegWriteVecM) ForwardBEVec = 2'b10; // SrcAE = ALUOutM
        else if (Match_2E_W_Vec & RegWriteVecW) ForwardBEVec = 2'b01; // SrcAE = ResultW
        else ForwardBEVec = 2'b00;  // SrcAE from regfile
    end

    // Stalls and flushes 
    // --- Load RAW ---
    // When an instruction reads a register loaded by the previous instruction,
    // stall in the decode stage until it is ready. 
    // --- Branch hazard ---
    // When a branch is taken, flush the incorrectly fetched instructions from
    // decode and execute stages.
    // --- PC Write Hazard --- 
    // When the PC might be written, stall all following instructions by
    // stalling the fetch and flushing the decode stage.
    // When a stage stalls, stall all previous and flush next.
 
    assign ldrStallD = Match_12D_E & MemtoRegE; 
    
    assign StallDScalar = ldrStallD; 
    assign StallFScalar = ldrStallD | PCWrPendingF; 
    assign FlushEScalar = ldrStallD | BranchTakenE; 
    assign FlushD = PCWrPendingF | PCSrcW | BranchTakenE;

    // stalls vectoriales
    assign ldrStallDVec = Match_12D_E_Vec & MemtoRegE; 
    
    assign StallDVec = ldrStallDVec; 
    assign StallFVec = ldrStallDVec | PCWrPendingF; 
    assign FlushEVec = ldrStallDVec | BranchTakenE; 

    assign StallD = StallDScalar | StallDVec;
    assign StallF = StallFScalar | StallFVec;
    assign FlushE = FlushEScalar | FlushEVec;

endmodule