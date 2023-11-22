///////////////////////////////////////////////////////////////////////////////
// Module Name:   regfile
// Description:   This module represents a simple register file with multiple ports.
//
// Inputs:        clk - Clock signal
//                writeEnable - Write enable signal
//                readAddr1, readAddr2 - Read addresses for the two read ports
//                writeAddr - Write address
//                writeData - Data to be written
//                r9 - Special read data from register 9
//
// Outputs:       readData1, readData2 - Data read from the two read ports
//
// Usage:         Instantiate this module in your design to provide register file
//                functionality with read and write access, and a special read
//                for register 9.
//
// Example Usage:
// ```
//   RegisterFile myRegisterFile (
//     .clk(clock),
//     .writeEnable(enable_write),
//     .readAddr1(address1),
//     .readAddr2(address2),
//     .writeAddr(address_write),
//     .writeData(data_to_write),
//     .r9(special_read_data),
//     .readData1(data_read1),
//     .readData2(data_read2)
//   );
// ```
///////////////////////////////////////////////////////////////////////////////

module regfile (
    input logic clk, writeEnable,
    input logic [3:0] readAddr1, readAddr2, writeAddr,
    input logic [31:0] writeData, r9,
    output logic [31:0] readData1, readData2
	);

	logic [31:0] registers [10:0] = '{default: 32'h0};
		
	// three ported register file
	// read two ports combinationally
	// write third port on rising edge of clock
	// register 9 reads PC + 8 instead

	always_ff @(negedge clk) begin
		if (writeEnable) begin
		registers[writeAddr] <= writeData;
		end
	end

	assign readData1 = (readAddr1 == 4'b1001) ? r9 : registers[readAddr1];
	assign readData2 = (readAddr2 == 4'b1001) ? r9 : registers[readAddr2];

endmodule