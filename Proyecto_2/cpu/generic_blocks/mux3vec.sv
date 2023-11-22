//////////////////////////////////////////////////////////////////////////
// module mux3vec
// Description:   This module represents a 3:1 multiplexer (mux) with a parameterized width and depth.
//                It selects one of the three input data sources 'd0', 'd1', or 'd2' based on
//                the two-bit select signal 's' and routes it to the output 'y'.
// Parameters:    WIDTH - Determines the bit width of input and output signals.
//                DEPTH - Determines the depth of input and output vectors.
// Inputs:        d0 - Input data source 0 of width 'WIDTH' and depth 'DEPTH'
//                d1 - Input data source 1 of width 'WIDTH' and depth 'DEPTH'
//                d2 - Input data source 2 of width 'WIDTH' and depth 'DEPTH'
//                s  - Two-bit select signal:
//                   - s[1] selects between 'd1' (when s[1] is 1) and 'd0' (when s[1] is 0)
//                   - s[0] selects between 'd1' (when s[0] is 1) and 'd0' (when s[0] is 0)
// Outputs:       y  - Output data, either 'd0', 'd1', or 'd2' based on the value of 's'
// Usage:         Instantiate this module in your design to implement a 3:1 multiplexer
//                for data routing, with adjustable width and depth according to the 'WIDTH' and 'DEPTH' parameters.
// Example Usage:
// ```
//   mux3vec #(16, 4) myMux (
//     .d0(input_source0),
//     .d1(input_source1),
//     .d2(input_source2),
//     .s(select_signals),
//     .y(output_data)
//   );
// ```
//////////////////////////////////////////////////////////////////////////
module mux3vec #(parameter WIDTH = 32, DEPTH = 4) // Width parameter for input and output signals
    (
        input logic [WIDTH-1:0] d0 [0:DEPTH-1], // Input data source 0
        input logic [WIDTH-1:0] d1 [0:DEPTH-1], // Input data source 1
        input logic [WIDTH-1:0] d2 [0:DEPTH-1], // Input data source 2
        input logic [1:0] s, // Two-bit select signal
        output logic [WIDTH-1:0] y [0:DEPTH-1] // Output data routed from 'd0', 'd1', or 'd2'
    );

    // Routing logic based on the value of two-bit select signal 's'
    assign y = s[1] ? d2 : (s[0] ? d1 : d0);

endmodule