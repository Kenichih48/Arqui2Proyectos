module test_floprc;
    // Parameters
    localparam WIDTH = 8;
    
    // Signals
    logic clk;
    logic reset;
    logic clear;
    logic [WIDTH-1:0] d;
    logic [WIDTH-1:0] q_expected, q_actual;
    
    // Instantiate the floprc module
    floprc #(WIDTH) u_floprc (
        .clk(clk),
        .reset(reset),
        .clear(clear),
        .d(d),
        .q(q_actual)
    );
    
    // Initialize test inputs
    initial begin
        clk = 0;
        reset = 0;
        clear = 0;
        d = 8'hA5; // Input value
        
       
        // Set reset to 1 (active low)
        reset = 1;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output resets to 0 after reset is asserted
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after reset");
        end
        else begin
            $display("Test Passed: q_actual == 0 after reset");
        end
        
        // Set reset to 0 (inactive)
        reset = 0;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output remains 0 after reset deassertion
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after reset deassertion");
        end 
        else begin
            $display("Test Passed: q_actual == 0 after reset deassertion");
        end
        
        // Set the clear signal to 1 (active low)
        clear = 1;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output resets to 0 after the clear is asserted
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after clear");
        end
        else begin
            $display("Test Passed: q_actual == 0 after clear");
        end
        
        // Set the clear signal to 0 (inactive)
        clear = 0;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output remains 0 after clear deassertion
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after clear deassertion");
        end
        else begin
            $display("Test Passed: q_actual == 0 after clear deassertion");
        end
        // Set the input value to a new value
        d = 8'h3C;
        
        clk = 1;
        #5;
        clk = 0;
        #5;
        // Verify that the output updates with the new input value
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d after input update");
        end
        else begin
            $display("Test Passed: q_actual == d after input update");
        end

        // Set the clock value to 1 (rising edge)
        clk = 1;
        #5;
        clk = 0;
        #5;
        
        // Verify that the output doesn't change on the rising clock edge
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d on rising clock edge");
        end
        else begin
            $display("Test Passed: q_actual == d on rising clock edge");
        end
        
        // Set the clock value to 0 (falling edge)
        clk = 0;
        
        // Wait for one clock cycle
        #5;
        
        // Verify that the output still doesn't change on the falling clock edge
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d on falling clock edge");
        end
        else begin
            $display("Test Passed: q_actual == d on falling clock edge");
        end
    end
endmodule