module test_adder;
    // Parameters
    localparam WIDTH = 8;
    
    // Signals
    logic [WIDTH-1:0] a, b;
    logic [WIDTH-1:0] y_expected, y_actual;
    
    // Instantiate the adder module
    adder #(WIDTH) u_adder (
        .a(a),
        .b(b),
        .y(y_actual)
    );
    
    // Initialize test inputs
    initial begin
        a = 5; // You can set your desired input values
        b = 3;
        
        // Calculate expected result
        y_expected = a + b;
        
        // Wait for a few simulation cycles
        #10;
        
        // Check if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: a + b = %d", y_actual);
        end else begin
            $display("Test Failed: Expected %d, Got %d", y_expected, y_actual);
        end

        a = 50;
        b = 5;
        
        // Calculate expected result
        y_expected = a + b;
        
        // Wait for a few simulation cycles
        #10;
        
        // Check if the output matches the expected result
        if (y_actual === y_expected) begin
            $display("Test Passed: a + b = %d", y_actual);
        end else begin
            $display("Test Failed: Expected %d, Got %d", y_expected, y_actual);
        end
    end
endmodule