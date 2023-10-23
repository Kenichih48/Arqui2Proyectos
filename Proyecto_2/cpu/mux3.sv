///////////////////////////////////////////////////////////////////////////////
// Module Name:  mux3
// Description:   This module represents a 3:1 multiplexer (mux) with a parameterized width.
//                It selects one of the three input data sources 'd0', 'd1', or 'd2' based on
//                the two-bit select signal 's' and routes it to the output 'y'.
//
// Parameters:    WIDTH - Determines the bit width of input and output signals.
//
// Inputs:        d0 - Input data source 0 of width 'WIDTH'
//                d1 - Input data source 1 of width 'WIDTH'
//                d2 - Input data source 2 of width 'WIDTH'
//                s  - Two-bit select signal:
//                   - s[1] selects between 'd1' (when s[1] is 1) and 'd0' (when s[1] is 0)
//                   - s[0] selects between 'd1' (when s[0] is 1) and 'd0' (when s[0] is 0)
//
// Outputs:       y  - Output data, either 'd0', 'd1', or 'd2' based on the value of 's'
//
// Usage:         Instantiate this module in your design to implement a 3:1 multiplexer
//                for data routing, with adjustable width according to the 'WIDTH' parameter.
//
// Example Usage:
// ```
//   mux3 #(16) myMux (
//     .d0(input_source0),
//     .d1(input_source1),
//     .d2(input_source2),
//     .s(select_signals),
//     .y(output_data)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module mux3 #(
  parameter WIDTH = 8 // Width parameter for input and output signals
) (
  input logic [WIDTH-1:0] d0, // Input data source 0
  input logic [WIDTH-1:0] d1, // Input data source 1
  input logic [WIDTH-1:0] d2, // Input data source 2
  input logic [1:0] s, // Two-bit select signal
  output logic [WIDTH-1:0] y // Output data routed from 'd0', 'd1', or 'd2'
);

  // Routing logic based on the value of two-bit select signal 's'
  assign y = s[1] ? d2 : (s[0] ? d1 : d0);

endmodule
