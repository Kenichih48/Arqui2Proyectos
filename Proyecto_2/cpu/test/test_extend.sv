module test_extend;

    // Signals
    logic [21:0] Instr;
    logic [1:0] ImmSrc;
    logic [31:0] ExtImm_actual, ExtImm_expected;
    
    // Instantiate the extend module
    extend u_extend (
        .Instr(Instr),
        .ImmSrc(ImmSrc),
        .ExtImm(ExtImm_actual)
    );
    
    // Initialize test inputs
    initial begin
        Instr = 22'b1101101010101101101010; // Example instruction
        ImmSrc = 2'b00; // Immediate source
        
        // Calculate the expected ExtImm value based on ImmSrc = 2'b00
        ExtImm_expected = 32'b00000000000000000000001101101010;

        #10;
        
        // Check if the actual ExtImm matches the expected value
        if (ExtImm_actual !== ExtImm_expected) begin
            $display("Test Failed: ExtImm_actual gave value  %b", ExtImm_actual);
        end
        else
            $display("Test Passed: ExtImm_actual matches the expected value for DP Immediate");
        
        // Change ImmSrc to test other cases
        ImmSrc = 2'b01; // Immediate source for GET/PUT
        
        // Calculate the expected ExtImm value based on ImmSrc = 2'b01
        ExtImm_expected = 32'b00000000000000000000001101101010;

        #10;
        
        // Check if the actual ExtImm matches the expected value
        if (ExtImm_actual !== ExtImm_expected) begin
            $display("Test Failed: ExtImm_actual gave value  %b", ExtImm_actual);
        end
        else
            $display("Test Passed: ExtImm_actual matches the expected value for GET/PUT");
        
        // Change ImmSrc to test another case
        ImmSrc = 2'b10; // Immediate source for two's complement shifted branch
        
        // Calculate the expected ExtImm value based on ImmSrc = 2'b10
        ExtImm_expected = 32'b11111111110110101010110110101000;
        
        #10;

        // Check if the actual ExtImm matches the expected value
        if (ExtImm_actual !== ExtImm_expected) begin
            $display("Test Failed: ExtImm_actual gave value  %b", ExtImm_actual);
        end
        else
            $display("Test Passed: ExtImm_actual matches the expected value for two's complement shifted branch");
        
        // Change ImmSrc to test an unsupported case
        ImmSrc = 2'b11; // Unsupported case
        
        // Calculate the expected ExtImm value for unsupported cases
        ExtImm_expected = 32'bx; // Unspecified value

        #10;
        
        // Check if the actual ExtImm matches the expected value for unsupported cases
        if (ExtImm_actual !== ExtImm_expected) begin
            $display("Test Failed: ExtImm_actual does not match the expected value for unsupported cases");
        end
        else
            $display("Test Passed: ExtImm_actual matches the expected value for unsupported cases");
    end
endmodule