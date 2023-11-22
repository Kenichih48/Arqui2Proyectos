///////////////////////////////////////////////////////////////////////////////
// Module Name:   adder
// Description:   This module represents a simple adder with a parameterized width.
//
// Parameters:    WIDTH - Determines the width of the adder inputs and output.
//
// Inputs:        a - Input signal 'a' of width 'WIDTH'
//                b - Input signal 'b' of width 'WIDTH'
//
// Outputs:       y - Output signal 'y' of width 'WIDTH' which is the result of 'a + b'
//
// Usage:         Instantiate this module in your design to perform addition operations
//                with adjustable width according to the 'WIDTH' parameter.
//
// Example Usage:
// ```
//   adder #(8) myAdder (
//     .a(input_a),
//     .b(input_b),
//     .y(output_sum)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module adder #(parameter WIDTH = 8) // Width parameter for input and output signals
	(
	input logic [WIDTH-1:0] a, // Input signal 'a'
	input logic [WIDTH-1:0] b, // Input signal 'b'
	output logic [WIDTH-1:0] y // Output signal 'y' representing 'a + b'
	);

	// Logic for addition operation
	assign y = a + b;

endmodule