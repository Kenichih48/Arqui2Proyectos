module AddrCalc(input logic [9:0] cuentaX,cuentaY, output logic [31:0] addr);


    assign addr = cuentaX + cuentaY*9'd300;


endmodule
