module test_vector_load_store;

    // Parámetros del testbench
    logic [31:0] inputVectorTemp [0:3] = '{32'h5, 32'h8, 32'h12, 32'h20};
    logic [31:0] numberTemp = 32'h3;
    logic [31:0] ALUresultTemp [0:3];
    logic [31:0] addressVectorTemp [0:3];
    // Parámetros del módulo
    vector_load_store dut (
        .inputVector(inputVectorTemp),
        .number(numberTemp),
        .ALUresult(ALUresultTemp),
        .addressVector(addressVectorTemp)
    );



    // Test 1: Comprobar que ALUresult es igual a inputVector
    initial begin
        #10; // Esperar un poco para la combinacional lógica
        if (ALUresultTemp !== inputVectorTemp) begin
            $display("Error en la prueba 1: ALUresult no es igual a inputVector");
        end
        else begin
            $display("Prueba 1 exitosa: ALUresult es igual a inputVector.");
        end

    end

    // Test 2: Comprobar que addressVector es calculado correctamente
    initial begin
        #10;
        if (addressVectorTemp[0] !== numberTemp || addressVectorTemp[1] !== numberTemp + 1 || addressVectorTemp[2] !== numberTemp + 2 || addressVectorTemp[3] !== numberTemp + 3) begin
            $display("Error en la prueba 2: addressVector no se calcula correctamente.");
        end
        else begin
            $display("Prueba 2 exitosa: addressVector se calcula correctamente.");
        end
    end

    // Testbench completo
    initial begin
        #100; // Ajustar la duración total del testbench según sea necesario
    end

endmodule
