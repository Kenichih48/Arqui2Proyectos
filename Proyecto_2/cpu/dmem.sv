///////////////////////////////////////////////////////////////////////////////
// Module Name:   dmem
// Description:   This module represents a data memory (dmem) module with read
//                and write capability.
//
// Inputs:        clk - Clock signal
//                we - Write enable signal
//                a - Address signal for reading data memory
//                a1 - Alternate address signal for reading data memory
//                wd - Data to be written
//
// Outputs:       rd - Read data from the main address
//                rd2 - Read data from the alternate address
//
// Usage:         Instantiate this module in your design to provide data memory
//                functionality with read and write access based on the specified
//                addresses.
//
// Example Usage:
// ```
//   dmem myDataMemory (
//     .clk(clock),
//     .we(write_enable),
//     .a(address),
//     .a1(alternate_address),
//     .wd(data_to_write),
//     .rd(read_data),
//     .rd2(alternate_read_data)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module dmem ( 
    input logic clk, we,
    input logic [31:0] a, wd,
    output logic [31:0] rd
);

    logic [31:0] RAM[1000:0];       // Array to store data

    initial begin
        $readmemh("DataMemInit.mif", RAM);   // Initialize RAM by reading from a file
    end

    assign rd = RAM[a[31:0]];         // Read data from RAM (word-aligned)

    always_ff @(posedge clk)              // On positive edge of the clock
        if (we) RAM[a[31:0]] <= wd;       // Write data to RAM if write enable is active
endmodule