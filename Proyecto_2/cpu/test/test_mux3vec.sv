module test_mux3vec;

    // Parameters
    parameter WIDTH = 32;
    parameter DEPTH = 4;

    // Signals
    logic [WIDTH-1:0] d0 [0:DEPTH-1];
    logic [WIDTH-1:0] d1 [0:DEPTH-1];
    logic [WIDTH-1:0] d2 [0:DEPTH-1];
    logic [WIDTH-1:0] y [0:DEPTH-1];
    logic [1:0] s;

    // DUT
    mux3vec #(WIDTH, DEPTH) dut (
        .d0(d0),
        .d1(d1),
        .d2(d2),
        .s(s),
        .y(y)
    );

    // Testbench
    initial begin
        // Initialize inputs
        for (int i = 0; i < DEPTH; i++) begin
            d0[i] = i;
            d1[i] = i + DEPTH;
            d2[i] = i + 2*DEPTH;
        end

        // Test 0: select d0
        s = 2'b00;
        #10;
        for (int i = 0; i < DEPTH; i++) begin
            if (y[i] !== d0[i]) $display("Test 0 failed at index %0d: y = %h, expected = %h", i, y[i], d0[i]);
            else $display("Test 0 passed at index %0d: y = %h, expected = %h", i, y[i], d0[i]);
        end

        // Test 1: select d1
        s = 2'b01;
        #10;
        for (int i = 0; i < DEPTH; i++) begin
            if (y[i] !== d1[i]) $display("Test 1 failed at index %0d: y = %h, expected = %h", i, y[i], d1[i]);
            else $display("Test 1 passed at index %0d: y = %h, expected = %h", i, y[i], d1[i]);
        end

        // Test 2: select d2
        s = 2'b10;
        #10;
        for (int i = 0; i < DEPTH; i++) begin
            if (y[i] !== d2[i]) $display("Test 2 failed at index %0d: y = %h, expected = %h", i, y[i], d2[i]);
            else $display("Test 2 passed at index %0d: y = %h, expected = %h", i, y[i], d2[i]);
        end

    end

endmodule