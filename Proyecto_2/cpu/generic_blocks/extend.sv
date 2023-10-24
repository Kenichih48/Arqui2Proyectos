///////////////////////////////////////////////////////////////////////////////
// Module Name:   extend
// Description:   This module is responsible for extending immediate values
//                based on the specified ImmSrc encoding.
//
// Inputs:        Instr - 22-bit instruction containing the immediate value
//                ImmSrc - 2-bit encoding to specify the type of immediate
//
// Outputs:       ExtImm - Extended immediate value
//
// Usage:         Instantiate this module in your design to extend immediate
//                values for various instruction types based on ImmSrc.
//
// Example Usage:
// ```
//   extend myExtender (
//     .Instr(instruction_data),
//     .ImmSrc(immediate_source),
//     .ExtImm(extended_immediate)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module extend (
    input logic [21:0] Instr,    // 22-bit instruction containing the immediate value
    input logic [1:0] ImmSrc,    // 2-bit encoding for specifying the type of immediate
    output logic [31:0] ExtImm  // Extended immediate value
);

    always_comb
        case(ImmSrc)
            // 10-bit unsigned immediate for data-processing
            2'b00: ExtImm = {22'b0, Instr[9:0]};

            // 10-bit unsigned immediate for GET/PUT
            2'b01: ExtImm = {22'b0, Instr[9:0]};

            // 24-bit two's complement shifted branch
            2'b10: ExtImm = {{8{Instr[21]}}, Instr[21:0], 2'b00};

            // undefined
            default: ExtImm = 32'bx;  // Unspecified value for unsupported cases
        endcase

endmodule