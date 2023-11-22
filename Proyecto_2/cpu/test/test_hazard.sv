module test_hazard;

    // Inputs
    logic clk, reset;
    logic Match_1E_M, Match_1E_W, Match_2E_M, Match_2E_W, Match_12D_E;
    logic RegWriteM, RegWriteW;
    logic BranchTakenE, MemtoRegE;
    logic PCWrPendingF, PCSrcW;

    // Outputs
    logic [1:0] ForwardAE, ForwardBE;
    logic StallF, StallD;
    logic FlushD, FlushE;

    // Instantiate the hazard module
    hazard uut (
        .clk(clk),
        .reset(reset),
        .Match_1E_M(Match_1E_M),
        .Match_1E_W(Match_1E_W),
        .Match_2E_M(Match_2E_M),
        .Match_2E_W(Match_2E_W),
        .Match_12D_E(Match_12D_E),
        .RegWriteM(RegWriteM),
        .RegWriteW(RegWriteW),
        .BranchTakenE(BranchTakenE),
        .MemtoRegE(MemtoRegE),
        .PCWrPendingF(PCWrPendingF),
        .PCSrcW(PCSrcW),
        .ForwardAE(ForwardAE),
        .ForwardBE(ForwardBE),
        .StallF(StallF),
        .StallD(StallD),
        .FlushD(FlushD),
        .FlushE(FlushE)
    );

    // Clock generation
    initial begin

        // Test case 1: No hazards
        clk = 0; reset = 1; Match_1E_M = 0; Match_1E_W = 0; Match_2E_M = 0; Match_2E_W = 0; Match_12D_E = 0;
        RegWriteM = 0; RegWriteW = 0; BranchTakenE = 0; MemtoRegE = 0; PCWrPendingF = 0; PCSrcW = 0;
        #10; reset = 0;
        
        // Add assertions and display statements for checking the output values
            // Example assertion, modify or add more as needed
        if(!StallD && !StallF && !FlushD && !FlushE) begin
            $display("Test Case 1 passed");
        end else begin
                $display("Test Case 1 failed");
        end

        // Display statements for better visibility
        $display("StallD=%0b StallF=%0b FlushD=%0b FlushE=%0b", StallD, StallF, FlushD, FlushE);

    end

endmodule