module test_eqcmp;
    // Parameters
    localparam WIDTH = 8;
    
    // Signals
    logic [WIDTH-1:0] a, b;
    logic y_expected, y_actual;
    
    // Instantiate the eqcmp module
    eqcmp #(WIDTH) u_eqcmp (
        .a(a),
        .b(b),
        .y(y_actual)
    );
    
    // Initialize test inputs
    initial begin
        a = 5;
        b = 5;
        
        // Calculate expected result
        y_expected = (a == b);
        
        // Wait for a few simulation cycles
        #10;
        
        // Check if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: a == b = %b", y_actual);
        end else begin
            $display("Test Failed: Expected %b, Got %b", y_expected, y_actual);
        end

        a = 8;
        b = 2;
        
        // Calculate expected result
        y_expected = (a == b);
        
        // Wait for a few simulation cycles
        #10;
        
        // Check if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: a == b = %b", y_actual);
        end else begin
            $display("Test Failed: Expected %b, Got %b", y_expected, y_actual);
        end
    end
endmodule