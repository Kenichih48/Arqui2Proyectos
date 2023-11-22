module test_controller;

    // Inputs
    logic clk, reset, FlushE;
    logic [26:10] InstrD;
    logic [3:0] ALUFlagsE;

    // Outputs
    logic [1:0] RegSrcD, ImmSrcD;
    logic ALUSrcE, BranchTakenE;
    logic [2:0] ALUControlE;
    logic MemWriteM, MemtoRegW, PCSrcW, RegWriteW;
    logic RegWriteM, MemtoRegE, PCWrPendingF;

    // Instantiate the module
    controller uut (
        .clk(clk),
        .reset(reset),
        .FlushE(FlushE),
        .InstrD(InstrD),
        .ALUFlagsE(ALUFlagsE),
        .RegSrcD(RegSrcD),
        .ImmSrcD(ImmSrcD),
        .ALUSrcE(ALUSrcE),
        .BranchTakenE(BranchTakenE),
        .ALUControlE(ALUControlE),
        .MemWriteM(MemWriteM),
        .MemtoRegW(MemtoRegW),
        .PCSrcW(PCSrcW),
        .RegWriteW(RegWriteW),
        .RegWriteM(RegWriteM),
        .MemtoRegE(MemtoRegE),
        .PCWrPendingF(PCWrPendingF),
        .FlushE(FlushE)
    );

    // Clock generation
    initial begin

        // Test case 1: Non-Data Processing Instruction
        // For example, a branch instruction
        clk = 0; reset = 1; InstrD = 27'b0; ALUFlagsE = 4'b0; FlushE = 0;
        #10; reset = 0; 
        #10; InstrD = 27'b001_0000000000000000000000; // Branch instruction
        #10;

        // Expected output: BranchTakenE = 0, RegWriteW = 0, MemWriteM = 0, MemtoRegE = 0
        assert(BranchTakenE === 0) $display("Test Case 1 passed"); else $display("Test Case 1 failed");
        assert(RegWriteW === 0) $display("Test Case 1 passed"); else $display("Test Case 1 failed");
        assert(MemWriteM === 0) $display("Test Case 1 passed"); else $display("Test Case 1 failed");
        assert(MemtoRegE === 0) $display("Test Case 1 passed"); else $display("Test Case 1 failed");

        // Test case 2: Data Processing Instruction - MOV
        // For example, MOV R1, R2
        InstrD = 27'b000_000010000000000000001; // MOV R1, R2
        #10;

        // Expected output: ALUSrcE = 1, ALUControlE = 1 (MOV), RegWriteW = 1, MemWriteM = 0, MemtoRegE = 1
        assert(ALUSrcE === 1) $display("Test Case 2 passed"); else $display("Test Case 2 failed");
        assert(ALUControlE === 3'b001) $display("Test Case 2 passed"); else $display("Test Case 2 failed");
        assert(RegWriteW === 1) $display("Test Case 2 passed"); else $display("Test Case 2 failed");
        assert(MemWriteM === 0) $display("Test Case 2 passed"); else $display("Test Case 2 failed");
        assert(MemtoRegE === 1) $display("Test Case 2 passed"); else $display("Test Case 2 failed");

        // Add more test cases as needed

    end
endmodule