///////////////////////////////////////////////////////////////////////////////
// Module Name:  mux2
// Description:   This module represents a 2:1 multiplexer (mux) with a parameterized width.
//                It selects one of the two input data sources 'd0' or 'd1' based on the
//                value of the select signal 's' and routes it to the output 'y'.
//
// Parameters:    WIDTH - Determines the bit width of input and output signals.
//
// Inputs:        d0 - Input data source 0 of width 'WIDTH'
//                d1 - Input data source 1 of width 'WIDTH'
//                s  - Select signal to choose between 'd0' (when 's' is 0) and 'd1' (when 's' is 1)
//
// Outputs:       y  - Output data, either 'd0' or 'd1' depending on the value of 's'
//
// Usage:         Instantiate this module in your design to implement a 2:1 multiplexer
//                for data routing, with adjustable width according to the 'WIDTH' parameter.
//
// Example Usage:
// ```
//   mux2 #(16) myMux (
//     .d0(input_source0),
//     .d1(input_source1),
//     .s(select_signal),
//     .y(output_data)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module mux2 #(parameter WIDTH = 8) // Width parameter for input and output signals
	(
		input logic [WIDTH-1:0] d0, // Input data source 0
		input logic [WIDTH-1:0] d1, // Input data source 1
		input logic s,              // Select signal
		output logic [WIDTH-1:0] y  // Output data routed from 'd0' or 'd1'
	);

	// Routing logic based on the value of select signal 's'
	assign y = s ? d1 : d0;

endmodule