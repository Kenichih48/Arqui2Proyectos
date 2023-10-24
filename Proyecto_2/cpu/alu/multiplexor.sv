///////////////////////////////////////////////////////////////////////////////
// Module Name:  multiplexor
// Description:   This module represents a multiplexer with a parameterized width
//                that selects one of the input data sources 'a', 'b', 'c', 'd', 'e', or 'f'
//                based on the three-bit select signal 'ss' and routes it to the output 'salida'.
//
// Parameters:    n - Determines the bit width of input and output signals.
//
// Inputs:        a - Input data source 'a' of width 'n'
//                b - Input data source 'b' of width 'n'
//                c - Input data source 'c' of width 'n'
//                d - Input data source 'd' of width 'n'
//                e - Input data source 'e' of width 'n'
//                f - Input data source 'f' of width 'n'
//                ss - Three-bit select signal 'ss' (0 to 5) to choose between the input sources
//
// Outputs:       salida - Output data, selected from 'a', 'b', 'c', 'd', 'e', or 'f' based on 'ss'
//
// Usage:         Instantiate this module in your design to implement a multiplexer
//                for data routing, with adjustable width according to the 'n' parameter.
//
// Example Usage:
// ```
//   multiplexor #(8) myMux (
//     .a(input_source_a),
//     .b(input_source_b),
//     .c(input_source_c),
//     .d(input_source_d),
//     .e(input_source_e),
//     .f(input_source_f),
//     .ss(select_signal),
//     .salida(output_data)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module multiplexor #(
  parameter n = 4 // Bit width parameter for input and output signals
) (
  input [n-1:0] a, // Input data source 'a'
  input [n-1:0] b, // Input data source 'b'
  input [n-1:0] c, // Input data source 'c'
  input [n-1:0] d, // Input data source 'd'
  input [n-1:0] e, // Input data source 'e'
  input [n-1:0] f, // Input data source 'f'
  input [2:0] ss, // Three-bit select signal 'ss'
  output [n-1:0] salida // Output data selected based on 'ss'
);

  logic [n-1:0] aux;

  always_comb begin
    case (ss)
      0:
        aux = a;
      1:
        aux = b;
      2:
        aux = c;
      3:
        aux = d;
      4:
        aux = e;
      5:
        aux = f;
      default:
        aux = 0;
    endcase
  end

  assign salida = aux;

endmodule

