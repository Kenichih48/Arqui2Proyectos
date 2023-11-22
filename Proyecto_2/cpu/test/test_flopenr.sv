module test_flopenr;
    // Parameters
    localparam WIDTH = 8;
    
    // Signals
    logic clk;
    logic reset;
    logic enable;
    logic [WIDTH-1:0] d;
    logic [WIDTH-1:0] q_expected, q_actual;
    
    // Instantiate the flopenr module
    flopenr #(WIDTH) u_flopenr (
        .clk(clk),
        .reset(reset),
        .enable(enable),
        .d(d),
        .q(q_actual)
    );
    
    // Initialize test inputs
    initial begin
        clk = 0;
        reset = 0;
        enable = 1; // Enable the module
        d = 8'hA5; // Input value

        // Test Case 1: Reset
        reset = 1;
        #10; // Wait for a few clock cycles
        reset = 0;
        // Check that q_actual is 0 after reset
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after reset");
        end
        else
            $display("Test Passed: q_actual == 0 after reset");
        
        // Test Case 2: Enable
        enable = 0;
        #10; // Wait for a few clock cycles
        d = 8'h3C; // Change input value
        enable = 1;
        #10; // Wait for a few clock cycles
        // Check that q_actual is 0 when enable is inactive
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 when enable is inactive");
        end
        else
            $display("Test Passed: q_actual == 0 when enable is inactive");
        
        // Test Case 3: Input Update
        d = 8'h3C; // Set input value
        #10; // Wait for a few clock cycles
        clk = 1;
        #10; // Wait for a few clock cycles
        clk = 0;
        // Check that q_actual updates with the new input value
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d after input update");
        end
        else
            $display("Test Passed: q_actual == d after input update");
        
        // Test Case 4: Clock Edge
        enable = 1;
        #10; // Wait for a few clock cycles
        clk = 1;
        #10; // Wait for a few clock cycles
        // Check that q_actual doesn't change on the rising clock edge
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d on rising clock edge");
        end
        else
            $display("Test Passed: q_actual == d on rising clock edge");
        
        clk = 0;
        #10; // Wait for a few clock cycles
        // Check that q_actual doesn't change on the falling clock edge
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d on falling clock edge");
        end
        else 
            $display("Test Passed: q_actual == d on falling clock edge");
    end
endmodule