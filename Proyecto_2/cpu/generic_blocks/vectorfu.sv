///////////////////////////////////////////////////////////////////////////////
// Module Name:   vectorfu
// Description:   This module represents a vectorized Arithmetic Logic Unit (ALU)
//                capable of performing operations on two vectors of 4 numbers,
//                each 32 bits. Supported operations include addition, subtraction,
//                multiplication, and division.
//
// Inputs:
//   A [0:3] - Input vector A with 4 numbers of 32 bits each.
//   B [0:3] - Input vector B with 4 numbers of 32 bits each.
//   operation [2:0] - 3-bit control signal for selecting the operation:
//                    000: Addition
//                    001: Subtraction
//                    010: Multiplication
//                    011: Division
//
// Outputs:
//   result [0:3] - Output vector with 4 results of the selected operation.
//
// Usage:
//   Instantiate this module in your design to perform vectorized arithmetic
//   operations on two input vectors.
//
// Example Usage:
// ```
//   vector_alu myAlu (
//     .A(inputVectorA),
//     .B(inputVectorB),
//     .operation(operationSignal),
//     .result(outputVector)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////
module vectorfu (
    input logic [31:0] A [0:3],
    input logic [31:0] B [0:3],
    input logic [2:0] operation,
    output logic [31:0] result [0:3]
);

    always_comb begin
        case (operation)
            3'b000: // Addition
				begin
                result[0] = A[0] + B[0];
                result[1] = A[1] + B[1];
                result[2] = A[2] + B[2];
                result[3] = A[3] + B[3];
				end

            3'b001: // Subtraction
				begin
                result[0] = A[0] - B[0];
                result[1] = A[1] - B[1];
                result[2] = A[2] - B[2];
                result[3] = A[3] - B[3];
				end

            3'b010: // Multiplication
				begin
                result[0] = A[0] * B[0];
                result[1] = A[1] * B[1];
                result[2] = A[2] * B[2];
                result[3] = A[3] * B[3];
				end

            3'b011: // Division
				begin
                result[0] = (B[0] != 0) ? A[0] / B[0] : 32'h0; // Avoid division by zero
                result[1] = (B[1] != 0) ? A[1] / B[1] : 32'h0;
                result[2] = (B[2] != 0) ? A[2] / B[2] : 32'h0;
                result[3] = (B[3] != 0) ? A[3] / B[3] : 32'h0;
				end

            default: // Unrecognized operation
				begin
                result[0] = 32'h0;
                result[1] = 32'h0;
                result[2] = 32'h0;
                result[3] = 32'h0;
				end
        endcase
    end

endmodule
