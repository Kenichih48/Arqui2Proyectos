module test_mux2vec();

    // Parameters
    parameter WIDTH = 32;
    parameter DEPTH = 4;

    // Signals
    logic [WIDTH-1:0] in0 [0:DEPTH-1];
    logic [WIDTH-1:0] in1 [0:DEPTH-1];
    logic [WIDTH-1:0] out [0:DEPTH-1];
    logic sel;

    // DUT
    mux2vec #(WIDTH, DEPTH) dut (
        .in0(in0),
        .in1(in1),
        .sel(sel),
        .out(out)
    );

    // Testbench
    initial begin
        // Initialize inputs
        for (int i = 0; i < DEPTH; i++) begin
            in0[i] = i;
            in1[i] = i + DEPTH;
        end

        // Test 0: select in0
        sel = 0;
        #10;
        for (int i = 0; i < DEPTH; i++) begin
            if (out[i] !== in0[i]) $display("Test 0 failed at index %0d: out = %h, expected = %h", i, out[i], in0[i]);
            else $display("Test 0 passed at index %0d: out = %h, expected = %h", i, out[i], in0[i]);
        end

        // Test 1: select in1
        sel = 1;
        #10;
        for (int i = 0; i < DEPTH; i++) begin
            if (out[i] !== in1[i]) $display("Test 1 failed at index %0d: out = %h, expected = %h", i, out[i], in1[i]);
            else $display("Test 1 passed at index %0d: out = %h, expected = %h", i, out[i], in1[i]);
        end


        // Finish
        $finish;
    end

endmodule