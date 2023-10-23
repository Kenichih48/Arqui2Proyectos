///////////////////////////////////////////////////////////////////////////////
// Module Name:  suma
// Description:   This module performs addition of two input numbers 'a' and 'b'.
//                It calculates the sum of 'a' and 'b' and sets flags to indicate
//                various conditions.
//
// Parameters:    n - Determines the bit width of 'a', 'b' inputs, 'c' output, and flags.
//
// Inputs:        a - Input signal 'a' of width 'n'
//                b - Input signal 'b' of width 'n'
//
// Outputs:       c - Output signal 'c' representing the sum of 'a' and 'b'
//                banderas - Flags indicating various conditions (N, Z, C, V)
//
// Usage:         Instantiate this module in your design to perform addition
//                operations with adjustable width according to the 'n' parameter.
//
// Important Notes:
// - 'c' is the result of 'a + b'.
// - 'banderas' is a 4-bit flag register:
//   - bit 3 (banderas[3]) indicates negativity (N).
//   - bit 2 (banderas[2]) indicates zero (Z).
//   - bit 1 (banderas[1]) indicates carry (C) for unsigned addition.
//   - bit 0 (banderas[0]) is reserved for overflow (V) and is not used in this module.
//
// Example Usage:
// ```
//   suma #(8) myAddition (
//     .a(input_a),
//     .b(input_b),
//     .c(output_sum),
//     .banderas(output_flags)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module suma #(
  parameter n = 4 // Bit width parameter for input, output, and flags
) (
  input [n-1:0] a, // Input signal 'a'
  input [n-1:0] b, // Input signal 'b'
  output [n-1:0] c, // Output signal 'c' representing the sum of 'a' and 'b'
  output [3:0] banderas // Flags for negativity, zero, carry, and overflow
);

  reg [n:0] result;

  // Calculate the sum of 'a' and 'b'
  assign result = a + b;

  // Set flag values
  assign banderas[3] = 0; // Negativity (N)
  assign banderas[2] = result[n-1:0] == 0; // Zero (Z)
  assign banderas[1] = result[n]; // Carry (C) for unsigned addition
  assign banderas[0] = 0; // Overflow (V) (Unused)

  // Set the output 'c' to the sum result
  assign c = result[n-1:0];

endmodule
