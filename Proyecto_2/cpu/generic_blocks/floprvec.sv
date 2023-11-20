///////////////////////////////////////////////////////////////////////////////
// This file is part of the floprvec module. It is a vectorized version of the flopr module. 
// It is used to store a vector of data in a vector of flip-flops.
// parameters: WIDTH = bit width of input and output signals, DEPTH = depth of input and output vectors
// inputs: clk = clock signal, reset = reset signal, d = input vector, q = output vector
// outputs: q = output vector representing the stored values
// usage: instantiate this module in your design to implement a vectorized positive-edge triggered flip-flop with an optional reset feature. The width and depth can be adjusted according to the WIDTH and DEPTH parameters.
// example usage:
// ```
// floprvec #(8, 4) myFlipFlop (
//     .clk(clock_signal),
//     .reset(reset_signal),
//     .d(input_data),
//     .q(output_data)
// );
// ```
///////////////////////////////////////////////////////////////////////////////

module floprvec #(parameter WIDTH = 8, DEPTH = 4) // Bit width parameter for input and output signals
    (
        input logic clk, // Clock signal
        input logic reset, // Reset signal
        input logic [WIDTH-1:0] d [0:DEPTH-1], // Input data
        output logic [WIDTH-1:0] q [0:DEPTH-1] // Output data representing the stored value
    );

    always_ff @(posedge clk, posedge reset)
        if (reset)
            q <= '{default:0};
        else
            q <= d;

endmodule