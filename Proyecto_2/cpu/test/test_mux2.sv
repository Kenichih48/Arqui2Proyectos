module test_mux2;
    // Parameters
    localparam WIDTH = 8;
    
    // Signals
    logic [WIDTH-1:0] d0, d1;
    logic s;
    logic [WIDTH-1:0] y_expected, y_actual;
    
    // Instantiate the mux2 module
    mux2 #(WIDTH) u_mux2 (
        .d0(d0),
        .d1(d1),
        .s(s),
        .y(y_actual)
    );
    
    // Initialize test inputs
    initial begin
        d0 = 8'h3A; 
        d1 = 8'h5F;
        s = 1'b0;
        
        // Calculate expected result
        y_expected = d0;
        
        // Wait for a few simulation cycles
        #10;
        
        // Check if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: s=0, y = %h", y_actual);
        end else begin
            $display("Test Failed: Expected %h, Got %h", y_expected, y_actual);
        end
        
        // Change the selection to d1
        s = 1'b1;
        
        // Calculate the expected result with the new selection
        y_expected = d1;
        
        // Wait for a few simulation cycles
        #10;
        
        // Verify if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: s=1, y = %h", y_actual);
        end else begin
            $display("Test Failed: Expected %h, Got %h", y_expected, y_actual);
        end
    end
endmodule