///////////////////////////////////////////////////////////////////////////////
// Module Name:  eqcmp
// Description:   This module performs an equality comparison between two input numbers 'a' and 'b'.
//                It checks if 'a' is equal to 'b' and sets the output 'y' accordingly.
//
// Parameters:    WIDTH - Determines the bit width of input signals 'a' and 'b'.
//
// Inputs:        a - Input signal 'a' of width 'WIDTH'
//                b - Input signal 'b' of width 'WIDTH'
//
// Outputs:       y - Output signal 'y' representing the result of the equality comparison:
//                - '1' when 'a' is equal to 'b'.
//                - '0' when 'a' is not equal to 'b'.
//
// Usage:         Instantiate this module in your design to perform equality comparisons
//                with adjustable width according to the 'WIDTH' parameter.
//
// Example Usage:
// ```
//   eqcmp #(8) myEqualityComparator (
//     .a(input_data_a),
//     .b(input_data_b),
//     .y(output_result)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module eqcmp #(
  parameter WIDTH = 8 // Bit width parameter for input signals
) (
  input logic [WIDTH-1:0] a, // Input signal 'a'
  input logic [WIDTH-1:0] b, // Input signal 'b'
  output logic y // Output signal 'y' indicating equality comparison result
);

  // Perform equality comparison and set the output 'y'
  assign y = (a == b);

endmodule
