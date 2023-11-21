///////////////////////////////////////////////////////////////////////////////
// Module Name:  division
// Description:   This module performs division of two input numbers 'a' and 'b'.
//                It calculates the result of 'a' divided by 'b' and sets flags
//                to indicate various conditions.
//
// Parameters:    n - Determines the bit width of 'a' and 'b' inputs, 'c' output, and flags.
//
// Inputs:        a - Input signal 'a' of width 'n'
//                b - Input signal 'b' of width 'n'
//
// Outputs:       c - Output signal 'c' representing the result of 'a' divided by 'b'
//                banderas - Flags indicating various conditions (N, Z, C, V)
//
// Usage:         Instantiate this module in your design to perform division operations
//                with adjustable width according to the 'n' parameter.
//
// Important Notes:
// - 'c' is the result of 'a / b'.
// - 'banderas' is a 4-bit flag register:
//   - bit 3 (banderas[3]) indicates negativity (N).
//   - bit 2 (banderas[2]) indicates zero (Z).
//   - bit 1 (banderas[1]) is reserved for carry (C) and is not used in this module.
//   - bit 0 (banderas[0]) is reserved for overflow (V) and is not used in this module.
//
// Example Usage:
// ```
//   division #(16) myDivision (
//     .a(input_dividend),
//     .b(input_divisor),
//     .c(output_result),
//     .banderas(output_flags)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module division #(
  parameter n = 4 // Bit width parameter for input, output, and flags
) (
  input [n-1:0] a, // Input signal 'a'
  input [n-1:0] b, // Input signal 'b'
  output [n-1:0] c, // Output signal 'c' representing the result of 'a' divided by 'b'
  output [3:0] banderas // Flags for negativity, zero, carry, and overflow
);

  logic [n:0] result;

  // Calculate the result of 'a' divided by 'b'
  assign result = a / b;

  // Set flag values
  assign banderas[3] = 0; // Negativity (N)
  assign banderas[2] = result[n-1:0] == 0; // Zero (Z)
  assign banderas[1] = 0; // Carry (C) (Unused)
  assign banderas[0] = 0; // Overflow (V) (Unused)

  // Set the output 'c' to the division result
  assign c = result[n-1:0];

endmodule