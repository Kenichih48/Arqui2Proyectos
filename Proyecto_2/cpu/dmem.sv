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
    input logic clk, we, wev,
    input logic [31:0] a, wd,
    input logic [31:0] va[0:3], wdv[0:3],
    input logic [31:0] avga,
    output logic [31:0] rd,
    output logic [31:0] rdv[0:3],
    output logic [31:0] rdvga
);

    logic [7:0] RAM[650:0] = '{default:0}; // Array to store data, initialized to 0       // Array to store data

    assign rd = {24'b0,RAM[a[31:0]]};         // Read data from RAM (word-aligned)
    assign rdv[0] = {24'b0,RAM[va[0][31:0]]}; //TODO: nuevos assigns vectoriales
    assign rdv[1] = {24'b0,RAM[va[1][31:0]]};
    assign rdv[2] = {24'b0,RAM[va[2][31:0]]};
    assign rdv[3] = {24'b0,RAM[va[3][31:0]]};
    assign rdvga = {24'b0,RAM[avga[31:0]]}; // word aligned

    always_ff @(posedge clk) begin         // On positive edge of the clock
        if (we) RAM[a[31:0]] <= wd[7:0];       // Write data to RAM if write enable is active
        if (wev) begin
            RAM[va[0][31:0]] <= wdv[0][7:0]; //TODO: nuevos always vectoriales
            RAM[va[1][31:0]] <= wdv[1][7:0];
            RAM[va[2][31:0]] <= wdv[2][7:0];
            RAM[va[3][31:0]] <= wdv[3][7:0]; 
        end
    end
endmodule