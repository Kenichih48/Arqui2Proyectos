///////////////////////////////////////////////////////////////////////////////
// mux2vec module (generic) - multiplexes two vectors of the same width based on a select signal (1 bit)
// mux2vec #(WIDTH, DEPTH) mux2vec_inst ( .in0(in0), .in1(in1), .sel(sel), .out(out) );
// Parameters: WIDTH = width of the vectors, DEPTH = depth of the vectors
// Inputs: in0 = first vector, in1 = second vector, sel = select signal
// Outputs: out = output vector
// Example: mux2vec #(32, 4) mux2vec_inst ( .in0(in0), .in1(in1), .sel(sel), .out(out) );
// Notes:
// - The vectors are of the same width
// - The vectors are of the same depth
// - The select signal is 1 bit
// - The output vector is of the same width as the input vectors
// - The output vector is of the same depth as the input vectors
// - The output vector is the same as the first input vector if the select signal is 0
// - The output vector is the same as the second input vector if the select signal is 1
///////////////////////////////////////////////////////////////////////////////
module mux2vec #(parameter WIDTH = 32, DEPTH = 4) (
    input [WIDTH-1:0] in0 [0:DEPTH-1],
    input [WIDTH-1:0] in1 [0:DEPTH-1],
    input sel,
    output [WIDTH-1:0] out [0:DEPTH-1]
);
    assign out = sel ? in1 : in0;
endmodule