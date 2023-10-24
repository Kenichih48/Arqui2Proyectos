///////////////////////////////////////////////////////////////////////////////
// Module Name:   flopenrc
// Description:   This module represents a resettable flip-flop with enable and clear signals.
//                It stores the input data 'd' and updates the output 'q' on the
//                positive edge of the clock signal 'clk'. It also allows for a
//                reset operation when the 'reset' signal is asserted. The flip-flop
//                can be enabled or disabled using the 'en' signal, and the stored
//                value can be cleared to '0' using the 'clear' signal.
//
// Parameters:    WIDTH - Determines the bit width of input and output signals.
//
// Inputs:        clk   - Clock signal, used to trigger the flip-flop's operation.
//                reset - Reset signal, when asserted, resets the flip-flop's state.
//                en    - Enable signal, when asserted, allows the flip-flop to update 'q'.
//                clear - Clear signal, when asserted, clears the stored value to '0'.
//                d     - Input data of width 'WIDTH' to be stored in the flip-flop.
//
// Outputs:       q - Output data of the same width as 'd', representing the stored value.
//
// Usage:         Instantiate this module in your design to implement a versatile flip-flop
//                with reset, enable, and clear features, with adjustable width according
//                to the 'WIDTH' parameter.
//
// Example Usage:
// ```
//   flopenrc #(8) myFlipFlop (
//     .clk(clock_signal),
//     .reset(reset_signal),
//     .en(enable_signal),
//     .clear(clear_signal),
//     .d(input_data),
//     .q(output_data)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module flopenrc #(parameter WIDTH = 8) // Bit width parameter for input and output signals
	(
		input logic clk,   // Clock signal
		input logic reset, // Reset signal
		input logic en,    // Enable signal
		input logic clear, // Clear signal
		input logic [WIDTH-1:0] d, // Input data
		output logic [WIDTH-1:0] q // Output data representing the stored value
	);

	always_ff @(posedge clk, posedge reset)
		if (reset)
		q <= 0;
		else if (en)
		begin
			if (clear) q <= 0;
			else q <= d;
		end
endmodule