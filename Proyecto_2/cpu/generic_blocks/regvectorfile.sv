///////////////////////////////////////////////////////////////////////////////
// Module Name:   regvectorfile
// Description:   This module represents a register file with vectorized data storage.
//
// Inputs:
//   clk - Clock signal
//   wren - Write enable signal. When high (1), data is written to the specified register.
//   wraddr - Write address for data to be written.
//   wrdata - Vector of 4 data elements, each 32 bits, to be written into the register file.
//   readAddr1, readAddr2 - Read addresses for the two read ports.
//
// Outputs:
//   r1v, r2v - Vector of 4 data elements, each 32 bits, representing the values read from the register file.
//
// Usage:
//   Instantiate this module in your design to provide register file functionality with vectorized data access.
//
// Example Usage:
// ```
//   regvectorfile myRegVectorFile (
//     .clk(clock),
//     .wren(writeEnable),
//     .wraddr(writeAddress),
//     .wrdata(dataToWrite),
//     .readAddr1(readAddress1),
//     .readAddr2(readAddress2),
//     .r1v(dataRead1),
//     .r2v(dataRead2)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module regvectorfile (
    input logic clk, wren,
    input logic [3:0] wraddr,
    input logic [31:0] wrdata [3:0],
    input logic [3:0] readAddr1, readAddr2,
    output logic [31:0] r1v [0:3],
    output logic [31:0] r2v [0:3]
);

    logic [31:0] regs [0:8][0:3] = '{default: 32'h0};

    // This register file supports vectorized write and dual read ports.
    // Data is written on the rising edge of the clock when the write enable is high.
    // Vectorized data is read from the specified read addresses.

    always_ff @(posedge clk) begin
        if (wren) begin
            // Write all values from the vector to the selected register.
            regs[wraddr] <= wrdata;
        end
    end

    assign r1v = regs[readAddr1];
    assign r2v = regs[readAddr2];

endmodule
