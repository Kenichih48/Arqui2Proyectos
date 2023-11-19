module test_vectorfu;

    // Parámetros del módulo
    logic [31:0] Atemp [0:3];
    logic [31:0] Btemp [0:3];
    logic [31:0] resultTemp [0:3];
    logic [2:0] operationTemp;
    vectorfu dut (
        .A(Atemp),
        .B(Btemp),
        .operation(operationTemp),
        .result(resultTemp)
    );

    // Bloque inicial para asignar valores a Atemp y Btemp
    initial begin
        Atemp = '{32'h5, 32'h8, 32'h12, 32'h20};
        Btemp = '{32'h2, 32'h4, 32'h6, 32'h10};

        // Test 1: Suma
        operationTemp = 3'b000;
        #10; // Esperar un poco para la combinacional lógica
        for (int i = 0; i < 4; i++) begin
            if (resultTemp[i] !== Atemp[i] + Btemp[i]) begin
                $display("Error en la prueba 1: Resultados de la suma incorrectos. Esperado: %h, Leído: %h", Atemp[i] + Btemp[i], resultTemp[i]);
            end
            else begin
                $display("Prueba 1 exitosa: Suma correcta.");
            end
        end

        // Test 2: Resta
        operationTemp = 3'b001;
        #10; // Esperar un poco para la combinacional lgica
        for (int i = 0; i < 4; i++) begin
            if (resultTemp[i] !== Atemp[i] - Btemp[i]) begin
                $display("Error en la prueba 2: Resultados de la resta incorrectos. Esperado: %h, Leído: %h", Atemp[i] - Btemp[i], resultTemp[i]);
            end
            else begin
                $display("Prueba 2 exitosa: Resta correcta.");
            end
        end

        // Test 3: Multiplicación
        operationTemp = 3'b010;
        #10; // Esperar un poco para la combinacional lógica
        for (int i = 0; i < 4; i++) begin
            if (resultTemp[i] !== Atemp[i] * Btemp[i]) begin
                $display("Error en la prueba 3: Resultados de la multiplicación incorrectos. Esperado: %h, Leído: %h", Atemp[i] * Btemp[i], resultTemp[i]);
            end
            else begin
                $display("Prueba 3 exitosa: Multiplicación correcta.");
            end
        end


        // Testbench completo
        #100; // Ajustar la duración total del testbench según sea necesario
    end

endmodule
