///////////////////////////////////////////////////////////////////////////////
// Module Name:   alu
// Description:   This module represents an Arithmetic Logic Unit (ALU) with
//                support for various arithmetic operations and flag generation.
//
// Parameters:    WIDTH - Determines the width of the ALU inputs and output.
//
// Inputs:        a - Input signal 'a' of width 'WIDTH'
//                b - Input signal 'b' of width 'WIDTH'
//                ALUControl - 3-bit control signal to select the ALU operation
//
// Outputs:       result - Output signal 'result' of width 'WIDTH' which is the
//                result of the selected ALU operation.
//                ALUFlags - 4-bit output signal containing flags (N, Z, C, V),
//                where N indicates a negative result, Z indicates a zero result,
//                C indicates a carry flag, and V indicates an overflow flag.
//
// Usage:         Instantiate this module in your design to perform various
//                arithmetic operations with adjustable width according to the
//                'WIDTH' parameter.
//
// Example Usage:
// ```
//   ALU #(16) myALU (
//     .a(input_a),
//     .b(input_b),
//     .ALUControl(operation),
//     .result(output_result),
//     .ALUFlags(output_flags)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module alu #(parameter WIDTH = 32) 
	(
		input logic [WIDTH-1:0] a, b,
		input logic [2:0] ALUControl,
		output logic [WIDTH-1:0] result,
		output logic [3:0] ALUFlags 
	);

    logic N, Z, C, V;

    always_comb begin
        case (ALUControl)
            3'b000: // SUM
                result = a + b;
            3'b001: // RES - EQV
                result = a - b;
            3'b010: // MUL
                result = a * b;
            3'b011: // DIV
                result = a / b;
            3'b100: // MOD
                result = a % b;
			3'b101: // MOV
				result = b;
            default:
                result = 32'b0;
        endcase

        // Flags generation
        N = result[WIDTH-1];
        Z = (result == 0);
		C = (ALUControl == 3'b000) ? ((result > a) || (result == a && b != 0)) : 0; // Carry for ADD
		V = (ALUControl == 3'b000) ? ((a[WIDTH-1] && b[WIDTH-1] && !result[WIDTH-1]) ||
                         (!a[WIDTH-1] && !b[WIDTH-1] && result[WIDTH-1])) : 0; // Overflow for ADD

		ALUFlags = {N, Z, C, V};
    end

endmodule