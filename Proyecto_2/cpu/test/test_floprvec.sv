module test_floprvec;

    // Parameters
    parameter WIDTH = 32;
    parameter DEPTH = 4;

    // Signals
    logic clk;
    logic reset;
    logic [WIDTH-1:0] d [0:DEPTH-1];
    logic [WIDTH-1:0] q [0:DEPTH-1];

    // DUT
    floprvec #(WIDTH, DEPTH) dut (
        .clk(clk),
        .reset(reset),
        .d(d),
        .q(q)
    );

    // Testbench
    initial begin
        // Initialize signals
        clk = 0;
        reset = 1;
        for (int i = 0; i < DEPTH; i++) begin
            d[i] = i;
        end

        // Apply reset
        #10;
        reset = 1;
        #10;

        // Check output
        for (int i = 0; i < DEPTH; i++) begin
            if (q[i] !== 0) $display("Reset test failed at index %0d: q = %h, expected = 0", i, q[i]);
            else $display("Reset test passed at index %0d: q = %h", i, q[i]);
        end

        // Apply input
        reset = 0;
        for (int i = 0; i < DEPTH; i++) begin
            d[i] = i + DEPTH;
        end
        #10;

        // Check output
        for (int i = 0; i < DEPTH; i++) begin
            if (q[i] !== d[i]) $display("Data test failed at index %0d: q = %h, expected = %h", i, q[i], d[i]);
            else $display("Data test passed at index %0d: q = %h", i, q[i]);
        end

    end

    // Clock generator
    always #5 clk = ~clk;

endmodule