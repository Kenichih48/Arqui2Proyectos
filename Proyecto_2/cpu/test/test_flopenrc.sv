module test_flopenrc;
    // Parameters
    localparam WIDTH = 8;
    
    // Signals
    logic clk;
    logic reset;
    logic en;
    logic clear;
    logic [WIDTH-1:0] d;
    logic [WIDTH-1:0] q_expected, q_actual;
    
    // Instantiate the flopenrc module
    flopenrc #(WIDTH) u_flopenrc (
        .clk(clk),
        .reset(reset),
        .en(en),
        .clear(clear),
        .d(d),
        .q(q_actual)
    );
    
    // Initialize test inputs
    initial begin
        clk = 0;
        reset = 0;
        en = 1; // Enable the module
        clear = 0;
        d = 8'hA5; // Input value
        
        // Wait for one clock cycle
        #5;
        
        // Set reset to 1 (active low)
        reset = 1;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output resets to 0 after reset is asserted
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after reset");
        end
        else
            $display("Test Passed: q_actual == 0 after reset");
        
        // Set reset to 0 (inactive)
        reset = 0;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output remains 0 after reset deassertion
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after reset deassertion");
        end
        else
            $display("Test Passed: q_actual == 0 after reset deassertion");
        
        // Set the enable signal to 0 (inactive)
        en = 0;
        
        // Set the input value to a new value
        d = 8'h3C;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output remains 0 when the enable signal is inactive
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 when enable is inactive");
        end
        else
            $display("Test Passed: q_actual == 0 when enable is inactive");
        
        // Set the enable signal back to 1 (active)
        en = 1;
        clk = 1;
        // Wait for one clock cycle
        #5;
        clk = 0;
        // Verify that the output updates with the new input value when the enable signal is active
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d after input update");
        end
        else
            $display("Test Passed: q_actual == d after input update");
        
        // Set the clear signal to 1 (active low)
        clear = 1;
        clk = 1;
        // Wait for one clock cycle
        #5;
        clk = 0;
        // Verify that the output resets to 0 after the clear is asserted
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after clear, q_actual = %h", q_actual);
        end
        else
            $display("Test Passed: q_actual == 0 after clear");
        
        // Set the clear signal to 0 (inactive)
        clear = 0;
        clk = 1;
        // Wait for one clock cycle
        #5;
        clk = 0;
        // Verify that the output remains 0 after clear deassertion
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after clear deassertion, q_actual = %h", q_actual);
        end
        else
            $display("Test Passed: q_actual == 0 after clear deassertion");
        
        // Set the clock value to 1 (rising edge)
        clk = 1;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output doesn't change on the rising clock edge
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d on rising clock edge");
        end
        else
            $display("Test Passed: q_actual == d on rising clock edge");
        
        // Set the clock value to 0 (falling edge)
        clk = 0;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output still doesn't change on the falling clock edge
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d on falling clock edge");
        end
        else
            $display("Test Passed: q_actual == d on falling clock edge");
    end
endmodule