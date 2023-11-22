///////////////////////////////////////////////////////////////////////////////
// Module Name:   flopr
// Description:   This module represents a simple positive-edge triggered flip-flop
//                with a reset feature. It stores the input data 'd' and updates
//                the output 'q' on the positive edge of the clock signal 'clk'. When
//                the 'reset' signal is asserted, the flip-flop's state is reset to '0'.
//
// Parameters:    WIDTH - Determines the bit width of input and output signals.
//
// Inputs:        clk   - Clock signal, used to trigger the flip-flop's operation.
//                reset - Reset signal, when asserted, resets the flip-flop's state to '0'.
//                d     - Input data of width 'WIDTH' to be stored in the flip-flop.
//
// Outputs:       q - Output data of the same width as 'd', representing the stored value.
//
// Usage:         Instantiate this module in your design to implement a basic positive-edge
//                triggered flip-flop with an optional reset feature. The width can be
//                adjusted according to the 'WIDTH' parameter.
//
// Example Usage:
// ```
//   flopr #(8) myFlipFlop (
//     .clk(clock_signal),
//     .reset(reset_signal),
//     .d(input_data),
//     .q(output_data)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module flopr #(parameter WIDTH = 8) // Bit width parameter for input and output signals
	(
		input logic clk, // Clock signal
		input logic reset, // Reset signal
		input logic [WIDTH-1:0] d, // Input data
		output logic [WIDTH-1:0] q // Output data representing the stored value
	);

	always_ff @(posedge clk, posedge reset)
		if (reset)
		q <= 0;
		else
		q <= d;

endmodule