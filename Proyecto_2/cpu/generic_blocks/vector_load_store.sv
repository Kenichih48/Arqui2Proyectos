///////////////////////////////////////////////////////////////////////////////
// Module Name:   vector_load_store
// Description:   This module represents a vector Load/Store unit. It takes a
//                vector of 4 numbers of 32 bits each as input and provides two
//                outputs: ALUresult, which is a copy of the input vector, and
//                addressVector, which contains addresses calculated based on
//                an input number.
//
// Inputs:
//   inputVector [0:3] - Input vector with 4 numbers of 32 bits each.
//   number - Input number used to calculate addresses.
//
// Outputs:
//   ALUresult [0:3] - Output vector, a copy of the input vector.
//   addressVector [0:3] - Output vector containing addresses calculated based
//                        on the input number.
//
// Usage:
//   Instantiate this module in your design to perform vectorized Load/Store
//   operations on an input vector and calculate addresses based on an input
//   number.
//
// Example Usage:
// ```
//   vector_load_store myLoadStore (
//     .inputVector(inputVector),
//     .number(numberInput),
//     .ALUresult(ALUresultOutput),
//     .addressVector(addressVectorOutput)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////
module vector_load_store (
    input logic [31:0] inputVector [0:3],
    input logic [31:0] number,
    output logic [31:0] ALUresult [0:3],
    output logic [31:0] addressVector [0:3]
);

    // ALUresult is simply the input, it can be used directly.
    assign ALUresult = inputVector;

    // Calculate addresses based on the input number and store them in addressVector.
    always_comb begin
        addressVector[0] = number;
        addressVector[1] = number + 1;
        addressVector[2] = number + 2;
        addressVector[3] = number + 3;
    end

endmodule
