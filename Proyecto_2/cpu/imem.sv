///////////////////////////////////////////////////////////////////////////////
// Module Name:   imem
// Description:   This module represents an instruction memory (imem) module
//                with read capability.
//
// Inputs:        a - Address signal for reading instruction memory
//
// Outputs:       rd - Read data, representing the instruction at the given address
//
// Usage:         Instantiate this module in your design to provide instruction
//                memory functionality, allowing read access to instructions
//                based on the specified address.
//
// Example Usage:
// ```
//   imem myInstructionMemory (
//     .a(address_signal),
//     .rd(read_data)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module imem (
    input logic [31:0] a,         // Address for reading instruction memory
    output logic [31:0] rd        // Read data (instruction)
);

    logic [31:0] ROM[63:0];       // Array to store instructions

    initial
        $readmemh("machine_code.dat", ROM);  // Initialize ROM by reading from a file

    assign rd = ROM[a[31:2]]; // Read instruction from ROM (word-aligned)
endmodule