module test_flopr;
    // Parameters
    localparam WIDTH = 8;
    
    // Signals
    logic clk;
    logic reset;
    logic [WIDTH-1:0] d;
    logic [WIDTH-1:0] q_expected, q_actual;
    
    // Instantiate the flopr module
    flopr #(WIDTH) u_flopr (
        .clk(clk),
        .reset(reset),
        .d(d),
        .q(q_actual)
    );
    
    // Initialize test inputs
    initial begin
        clk = 0;
        reset = 0;
        d = 8'hA5; // Input value

        // Changes the value of reset to 1 (active low)
        reset = 1;
        
        // Wait for a clock cycle
        #5;
        
        // Verifies that the output is reset to 0 after reset is asserted
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after reset");
        end
        else begin
            $display("Test Passed: q_actual == 0 after reset");
        end
        
        // Changes the value of reset to 0 (inactive)
        reset = 0;
        
        // Wait for a clock cycle
        #5;
        
        // Verifies that the output is still 0 after reset is deasserted
        if (q_actual !== 8'h00) begin
            $display("Test Failed: q_actual != 0 after reset deassertion");
        end
        else begin
            $display("Test Passed: q_actual == 0 after reset deassertion");
        end
        
        // Changes the value of the input to a new value
        d = 8'h3C;
        clk = 1;
        #5;
        clk = 0;    
        #5;
        // Verifies that the output is updated with the new input value
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d after input update");
        end
        else begin
            $display("Test Passed: q_actual == d after input update");
        end
        
        // Change the value of the clock to 1 (rising edge)
        clk = 1;
        
        // Wait for a clock cycle
        #5;
        
        // Verifies that the output does not change on the rising clock edge
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d on rising clock edge");
        end
        else begin
            $display("Test Passed: q_actual == d on rising clock edge");
        end
        // Change the value of the clock to 0 (falling edge)
        clk = 0;
        
        // Wait for a clock cycle
        #5;
        
        // Verifies that the output does not change on the falling clock edge
        if (q_actual !== d) begin
            $display("Test Failed: q_actual != d on falling clock edge");
        end
        else begin
            $display("Test Passed: q_actual == d on falling clock edge");
        end
    end
endmodule