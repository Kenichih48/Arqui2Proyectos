///////////////////////////////////////////////////////////////////////////////
// Module Name:  clockDivider
// Description:   This module divides an input clock signal ('clock_in') by a specified
//                divisor value ('DIVISOR') to generate a divided output clock signal
//                ('clock_out'). The output clock signal transitions between '1' and '0'
//                based on the divisor value.
//
// Inputs:        clock_in - Input clock signal to be divided.
//
// Outputs:       clock_out - Divided output clock signal.
//
// Parameters:    DIVISOR - Defines the division factor for the input clock.
//
// Usage:         Instantiate this module in your design to generate a divided clock signal
//                based on the specified DIVISOR value. The module generates a pulse
//                signal that transitions between '1' and '0' based on the division factor.
//
// Example Usage:
// ```
//   clockDivider myDivider (
//     .clock_in(input_clock),
//     .clock_out(output_divided_clock)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module clockDivider (
  input clock_in, // Input clock signal to be divided
  output reg clock_out // Divided output clock signal
);

  reg [27:0] counter = 28'd0; // Counter for dividing the clock
  parameter DIVISOR = 28'd2; // Divisor value for clock division

  always @ (posedge clock_in)
  begin
    counter <= counter + 28'd1;
    if (counter >= (DIVISOR - 1))
      counter <= 28'd0;
    clock_out <= (counter < DIVISOR/2) ? 1'b1 : 1'b0;
  end

endmodule
