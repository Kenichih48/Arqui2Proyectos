module test_top();
    logic clk;
    logic reset;
    logic [31:0] WriteData, DataAdr;
    logic MemWrite, MemWriteVec;
	 logic [31:0] DataAdrVec[0:3], WriteDataVec[0:3];
	 logic H_SYNC, V_SYNC, SYNC_B, SYNC_BLANK;
	 logic clk_25;
    logic [7:0] r,g,b;
	 

    // instantiate device to be tested
    top dut(clk, reset, WriteData, DataAdr, 
	 DataAdrVec, WriteDataVec, MemWrite, MemWriteVec,
	 H_SYNC, V_SYNC, SYNC_B, SYNC_BLANK,clk_25,r,g,b);
	 
	 
    // initialize test
    initial begin
        reset <= 1; #22; reset <= 0;
    end

    // generate clock to sequence tests
    always
    begin
        clk <= 1; #5; clk <= 0; #5;
    end
endmodule