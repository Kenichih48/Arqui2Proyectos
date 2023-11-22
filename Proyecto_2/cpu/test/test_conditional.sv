module test_conditional;

    // Inputs
    logic Cond;
    logic [3:0] Flags;
    logic [3:0] ALUFlags;
    logic [1:0] FlagsWrite;

    // Outputs
    logic CondEx;
    logic [3:0] FlagsNext;

    // Instantiate the module
    conditional uut (
        .Cond(Cond),
        .Flags(Flags),
        .ALUFlags(ALUFlags),
        .FlagsWrite(FlagsWrite),
        .CondEx(CondEx),
        .FlagsNext(FlagsNext)
    );

    // Clock generation
    initial begin

        // Test case 1: Always true condition
        Cond = 0;
        Flags = 4'b0000;
        ALUFlags = 4'b1100;
        FlagsWrite = 2'b11;
        #10;

        // Expected output: CondEx = 1, FlagsNext = ALUFlags
        
        assert(CondEx === 1) $display("Test Case 1 passed"); else $display("Test Case 1 failed");
        assert(FlagsNext === ALUFlags) $display("Test Case 1 passed"); else $display("Test Case 1 failed");

        // Test case 2: EQV condition, zero flag set
        Cond = 1;
        Flags = 4'b0110;
        ALUFlags = 4'b0011;
        FlagsWrite = 2'b11;
        #10;

        // Expected output: CondEx = 1 (zero flag set), FlagsNext = ALUFlags
        assert(CondEx === 1) $display("Test Case 2 passed"); else $display("Test Case 2 failed");
        assert(FlagsNext === ALUFlags) $display("Test Case 2 passed"); else $display("Test Case 2 failed");

        // Test case 3: EQV condition, zero flag not set
        Cond = 1;
        Flags = 4'b0101;
        ALUFlags = 4'b1100;
        FlagsWrite = 2'b11;
        #10;

        // Expected output: CondEx = 0 (zero flag not set), FlagsNext = Flags
        assert(CondEx === 1) $display("Test Case 3 passed"); else $display("Test Case 3 failed");
        assert(FlagsNext === ALUFlags) $display("Test Case 3 passed"); else $display("Test Case 3 failed");

    end

endmodule