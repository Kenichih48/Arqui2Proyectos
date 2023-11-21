`timescale 1ns / 1ps

module test_dmem;

    reg clk;
    reg we, wev;
    reg [31:0] a, wd;
    reg [31:0] va[0:3], wdv[0:3];
    wire [31:0] rd;
    wire [31:0] rdv[0:3];

    // Instantiate the module
    dmem u_dmem (
        .clk(clk), .we(we), .wev(wev),
        .a(a), .wd(wd),
        .va(va), .wdv(wdv),
        .rd(rd), .rdv(rdv)
    );

    // Clock generator
    always begin
        #5 clk = ~clk;
    end

    // Test sequence
    initial begin
        clk = 0;
        we = 0; wev = 0;
        a = 0; wd = 0;
        va[0] = 0; va[1] = 0; va[2] = 0; va[3] = 0;
        wdv[0] = 0; wdv[1] = 0; wdv[2] = 0; wdv[3] = 0;

        #10;
        we = 1; a = 10; wd = 8'hAA;
        #10;
        we = 0; a = 10;
        #10;
        $display("Read data: %h", rd);

        #10;
        wev = 1; va[0] = 20; va[1] = 21; va[2] = 22; va[3] = 23;
        wdv[0] = 8'hBB; wdv[1] = 8'hCC; wdv[2] = 8'hDD; wdv[3] = 8'hEE;
        #10;
        wev = 0; va[0] = 20; va[1] = 21; va[2] = 22; va[3] = 23;
        #10;
        $display("Read data: %h %h %h %h", rdv[0], rdv[1], rdv[2], rdv[3]);

        #10;
    end

endmodule