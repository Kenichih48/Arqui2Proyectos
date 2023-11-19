module test_regvecfile;

    // Parámetros del módulo
    regvectorfile dut (
        .clk(clk),
        .wren(wren),
        .wraddr(wraddr),
        .wrdata(wrdata),
        .readAddr1(readAddr1),
        .readAddr2(readAddr2),
        .r1v(r1v),
        .r2v(r2v)
    );

    // Parámetros del testbench
    logic clk = 0;
    logic wren = 1;
    logic [3:0] wraddr = 0;
    logic [31:0] wrdata [0:3] = '{32'h1111, 32'h2222, 32'h3333, 32'h4444};
    logic [3:0] readAddr1 = 0;
    logic [3:0] readAddr2 = 1;

    // Generación de clock
    always #5 clk =~clk;

    // Test 1: Escribir datos en el registro y leerlos
    initial begin
        // Esperar a que la señal de reset sea 0
        clk = 0;
        // Escribir datos en el registro
        dut.wren <= wren;
        dut.wraddr <= wraddr;
        dut.wrdata <= wrdata;
        #10; // Esperar un poco para que se realice la escritura

        // Leer datos y verificar si son correctos
        if (dut.r1v[0] !== wrdata[0]) begin
            $display("Error en la prueba 1: Datos leídos incorrectos en r1v[0]. Esperado: %h, Leído: %h", wrdata[0], dut.r1v[0]);
        end
        else begin
            $display("Prueba 1: Datos leídos correctamente en r1v[0]. Esperado: %h, Leído: %h", wrdata[0], dut.r1v[0]);
        end

        if (dut.r1v[1] !== wrdata[1]) begin
            $display("Error en la prueba 1: Datos leídos incorrectos en r1v[1]. Esperado: %h, Leído: %h", wrdata[1], dut.r1v[1]);
        end
        else begin
            $display("Prueba 1: Datos leídos correctamente en r1v[1]. Esperado: %h, Leído: %h", wrdata[1], dut.r1v[1]);
        end

        if (dut.r1v[2] !== wrdata[2]) begin
            $display("Error en la prueba 1: Datos leídos incorrectos en r1v[2]. Esperado: %h, Leído: %h", wrdata[2], dut.r1v[2]);
        end
        else begin
            $display("Prueba 1: Datos leídos correctamente en r1v[2]. Esperado: %h, Leído: %h", wrdata[2], dut.r1v[2]);
        end

        if (dut.r1v[3] !== wrdata[3]) begin
            $display("Error en la prueba 1: Datos leídos incorrectos en r1v[3]. Esperado: %h, Leído: %h", wrdata[3], dut.r1v[3]);
        end
        else begin
            $display("Prueba 1: Datos leídos correctamente en r1v[3]. Esperado: %h, Leído: %h", wrdata[3], dut.r1v[3]);
        end

        if (dut.r2v[0] !== wrdata[0]) begin
            $display("Error en la prueba 2: Datos leídos incorrectos en r2v[0]. Esperado: %h, Leído: %h", wrdata[0], dut.r2v[0]);
        end
        else begin
            $display("Prueba 2: Datos leídos correctamente en r2v[0]. Esperado: %h, Leído: %h", wrdata[0], dut.r2v[0]);
        end

        if (dut.r2v[1] !== wrdata[1]) begin
            $display("Error en la prueba 2: Datos leídos incorrectos en r2v[1]. Esperado: %h, Leído: %h", wrdata[1], dut.r2v[1]);
        end
        else begin
            $display("Prueba 2: Datos leídos correctamente en r2v[1]. Esperado: %h, Leído: %h", wrdata[1], dut.r2v[1]);
        end

        if (dut.r2v[2] !== wrdata[2]) begin
            $display("Error en la prueba 2: Datos leídos incorrectos en r2v[2]. Esperado: %h, Leído: %h", wrdata[2], dut.r2v[2]);
        end
        else begin
            $display("Prueba 2: Datos leídos correctamente en r2v[2]. Esperado: %h, Leído: %h", wrdata[2], dut.r2v[2]);
        end

        if (dut.r2v[3] !== wrdata[3]) begin
            $display("Error en la prueba 2: Datos leídos incorrectos en r2v[3]. Esperado: %h, Leído: %h", wrdata[3], dut.r2v[3]);
        end
        else begin
            $display("Prueba 2: Datos leídos correctamente en r2v[3]. Esperado: %h, Leído: %h", wrdata[3], dut.r2v[3]);
        end
    end

endmodule
