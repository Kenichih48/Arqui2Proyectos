///////////////////////////////////////////////////////////////////////////////
// Module Name:   top
// Description:   This top-level module represents the main structure of a processor system.
//
// Inputs:        clk - Clock signal
//                reset - Reset signal
//
// Outputs:       WriteDataM - Data to be written to memory
//                DataAdrM - Address for data memory
//                MemWriteM - Control signal for memory write
//
// Usage:         Instantiate this module to create a processor system and connect it to
//                the processor core, instruction memory (instmem), and data memory (datmem).
//
// Example Usage:
// ```
//   top myProcessor (
//     .clk(clock),
//     .reset(reset_signal),
//     .WriteDataM(data_to_write_to_memory),
//     .DataAdrM(data_memory_address),
//     .MemWriteM(memory_write_control)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module top (
    input logic  clk, reset,  // Clock and Reset signals
    output logic [31:0] WriteDataM, DataAdrM,  // Data to be written to memory and memory address
    output logic MemWriteM  // Control signal for memory write
);

    logic [31:0] PCF, InstrF, ReadDataM;  // Internal signals for PC, instruction, and data read

    // Instantiate the processor core and memory modules
    kodd processor(clk, reset, PCF, InstrF, MemWriteM, DataAdrM, WriteDataM, ReadDataM);
    imem instmem(PCF, InstrF);  // Instruction memory
    dmem datmem(clk, MemWriteM, DataAdrM, WriteDataM, ReadDataM);  // Data memory

endmodule