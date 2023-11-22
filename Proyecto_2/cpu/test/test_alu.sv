module test_alu;

    // Parameters
    localparam WIDTH = 32;

    // Inputs
    logic [WIDTH-1:0] a, b;
    logic [2:0] ALUControl;

    // Outputs
    logic [WIDTH-1:0] result;
    logic [3:0] ALUFlags;

    // Instantiate the ALU module
    alu #(WIDTH) dut (
        .a(a),
        .b(b),
        .ALUControl(ALUControl),
        .result(result),
        .ALUFlags(ALUFlags)
    );

    // Test cases
    initial begin
        // Test case 1: SUM
        a = 32'h00000001;
        b = 32'h00000002;
        ALUControl = 3'b000;
        #1;
        if (result !== 32'h00000003 || ALUFlags !== 4'b0010) $error("Test case 1 failed");

        // Test case 2: RES - EQV
        a = 32'h00000003;
        b = 32'h00000002;
        ALUControl = 3'b001;
        #1;
        if (result !== 32'h00000001 || ALUFlags !== 4'b0000) $error("Test case 2 failed");

        // Test case 3: MUL
        a = 32'h00000003;
        b = 32'h00000002;
        ALUControl = 3'b010;
        #1;
        if (result !== 32'h00000006 || ALUFlags !== 4'b0000) $error("Test case 3 failed");

        // Test case 4: DIV
        a = 32'h00000006;
        b = 32'h00000002;
        ALUControl = 3'b011;
        #1;
        if (result !== 32'h00000003 || ALUFlags !== 4'b0000) $error("Test case 4 failed");

        // Test case 5: MOD
        a = 32'h00000007;
        b = 32'h00000002;
        ALUControl = 3'b100;
        #1;
        if (result !== 32'h00000001 || ALUFlags !== 4'b0000) $error("Test case 5 failed");

        // Test case 6: MOV
        a = 32'h00000007;
        b = 32'h00000002;
        ALUControl = 3'b101;
        #1;
        if (result !== 32'h00000002 || ALUFlags !== 4'b0000) $error("Test case 6 failed");

        // Test case 7: Default case
        a = 32'h00000007;
        b = 32'h00000002;
        ALUControl = 3'b111;
        #1;
        if (result !== 32'h00000000 || ALUFlags !== 4'b0000) $error("Test case 7 failed");

        // Add even more cases here

        $display("All test cases passed");
    end

endmodule