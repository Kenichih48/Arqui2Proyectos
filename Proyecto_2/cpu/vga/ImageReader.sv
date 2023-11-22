module ImageReader(input logic [9:0] cuentaX,cuentaY,input logic [7:0] ri,gi,bi,
						output logic [7:0] ro,go,bo);

	always@(cuentaX,cuentaY,ri,gi,bi) begin

		if((cuentaX < 25) & (cuentaY < 25) ) begin
			ro <= ri;
			go <= gi;
			bo <= bi;

		end else begin
			ro <= 8'd255;
			bo <= 8'd255;
			go <= 8'd255;
		
		end 


	end

endmodule


