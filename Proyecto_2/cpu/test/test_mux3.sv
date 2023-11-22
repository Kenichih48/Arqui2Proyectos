module test_mux3;
    // Parameters
    localparam WIDTH = 8;
    
    // Signals
    logic [WIDTH-1:0] d0, d1, d2;
    logic [1:0] s;
    logic [WIDTH-1:0] y_expected, y_actual;
    
    // Instantiate the mux3 module
    mux3 #(WIDTH) u_mux3 (
        .d0(d0),
        .d1(d1),
        .d2(d2),
        .s(s),
        .y(y_actual)
    );
    
    // Initialize test inputs
    initial begin
        d0 = 8'h3A;
        d1 = 8'h5F;
        d2 = 8'h80;
        s = 2'b00;
        
        // Calculate expected result
        y_expected = d0;
        
        // Wait for a few simulation cycles
        #10;
        
        // Check if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: s=00, y = %h", y_actual);
        end else begin
            $display("Test Failed: Expected %h, Got %h", y_expected, y_actual);
        end
        
        // Change the selection to d1
        s = 2'b01;
        
        // Calculate expected result with the new selection
        y_expected = d1;
        
        // Wait for a few simulation cycles
        #10;
        
        // Verify if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: s=01, y = %h", y_actual);
        end else begin
            $display("Test Failed: Expected %h, Got %h", y_expected, y_actual);
        end
        
        // Change the selection to d2
        s = 2'b10;
        
        // Calculate expected result with the new selection
        y_expected = d2;
        
        // Wait for a few simulation cycles
        #10;
        
        // Verify if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: s=10, y = %h", y_actual);
        end else begin
            $display("Test Failed: Expected %h, Got %h", y_expected, y_actual);
        end
    end
endmodule