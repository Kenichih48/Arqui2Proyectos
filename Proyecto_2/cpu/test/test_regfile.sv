module test_regfile;

    // Signals
    logic clk;
    logic writeEnable;
    logic [3:0] readAddr1, readAddr2, writeAddr;
    logic [31:0] writeData, r9;
    logic [31:0] readData1, readData2;
    
    // Instantiate the regfile module
    regfile u_regfile (
        .clk(clk),
        .writeEnable(writeEnable),
        .readAddr1(readAddr1),
        .readAddr2(readAddr2),
        .writeAddr(writeAddr),
        .writeData(writeData),
        .r9(r9),
        .readData1(readData1),
        .readData2(readData2)
    );
    
    // Initialize test inputs
    initial begin
        clk = 0;
        writeEnable = 0;
        readAddr1 = 4'b0000;
        readAddr2 = 4'b0001;
        writeAddr = 4'b0010;
        writeData = 32'hA5A5A5A5;
        r9 = 32'h12345678;
        
        // Apply a rising clock edge
        clk = 0;
        #5;
        clk = 1;
        #5;
        
        // Verify that the registers are not written because writeEnable is 0
        if (readData1 !== 32'h00000000) begin
            $display("Test Failed: readData1 is not 0");
        end
        else
            $display("Test Passed: readData1 is 0");
        
        if (readData2 !== 32'h00000000) begin
            $display("Test Failed: readData2 is not 0");
        end
        else
            $display("Test Passed: readData2 is 0");
        
        // Enable write operation
        readAddr2 = 4'b0010;
        writeEnable = 1;
        
        // Apply another rising clock edge
        clk = 0;
        #5;
        clk = 1;
        #5;
        
        // Verify that write operation is successful
        if (readData1 !== 32'h00000000) begin
            $display("Test Failed: readData1 is not 0 after write");
        end
        else
            $display("Test Passed: readData1 is 0 after write");
        
        if (readData2 !== 32'hA5A5A5A5) begin
            $display("Test Failed: readData2 is not hA5A5A5A5 after write");
        end
        else
            $display("Test Passed: readData2 is hA5A5A5A5 after write");
        
        // Set the write address to read from register 9
        readAddr1 = 4'b1001;
        
        // Apply another rising clock edge
        clk = 0;
        #5;
        clk = 1;
        #5;
        
        // Verify that the readData1 and readData2 values match r9
        if (readData1 !== 32'h12345678) begin
            $display("Test Failed: readData1 does not match r9");
        end
        else
            $display("Test Passed: readData1 matches r9");
    end
endmodule