dp_scalar = {
    'cond+op': '0000',  # Cond + Op
    'register': '0',    # I = register-register
    'immediate': '1',   # I = register-immediate
    'SUM': '0000',      # Tipo + S
    'RES': '0010',
    'MUL': '0100',
    'DIV': '0110',
    'MOD': '1000',
    'MOV': '1010',
    'EQV': '1101'
}

mem_escalar = {
   'cond+op': '0010',   # Cond + Op
   'PUT': '00000',      # Tipo + L
   'GET': '00011',      # Tipo + L
}

control = {
    'S': '00010',        # Cond + Op + L
    'SEQ': '10010'       # Cond + Op + L
}

registers = {
    'R0': '0000',
    'R1': '0001',
    'R2': '0010',
    'R3': '0011',
    'R4': '0100',
    'R5': '0101',
    'R6': '0110',
    'R7': '0111',
    'R8': '1000',
    'R9': '1001'
}

dp_vectorial = {
    'cond+op+i': '00110', # Cond + Op + I
    'SUMV': '0000',       # Tipo + S
    'RESV': '0010',       # Tipo + S
    'MULV': '0100',       # Tipo + S
}

mem_vectorial = {
   'cond+op': '0100',   # Cond + Op
   'PUTV': '00000',      # Tipo + L
   'GETV': '00011',      # Tipo + L
}

registers_vectorial = {
    'R0V': '0000',
    'R1V': '0001',
    'R2V': '0010',
    'R3V': '0011',
    'R4V': '0100',
    'R5V': '0101',
    'R6V': '0110',
    'R7V': '0111',
    'R8V': '1000',
    'R9V': '1001'
}

Rd = ''
Rn = ''
Src2 = ''
binary_instr = ''
list_hex = []
etiquetas = []

def compiler():
    file = open("./KODD_code.txt", 'r')
    data = file.read()
    file.close()
    
    # separar instrucciones
    instrList = data.split('\n')

    # ---------------------------------------------------
    # mapear etiquetas y eliminar lineas vacias
    contador = 0
    eliminar = []
    for instr in instrList:
        lista = []
        lista = instr.split(' ')

        if (lista[0] == ''):
            # linea vacia
            eliminar.append(instr)
        elif((lista[0] not in dp_scalar) and (lista[0] not in mem_escalar) and (lista[0] not in control) 
             and (lista[0] not in dp_vectorial) and (lista[0] not in mem_vectorial)):
            # etiqueta
            etiquetas.append((lista[0], contador))
            eliminar.append(instr)
        else:
            # se aumenta contador si no es etiqueta (pc + 4)
            contador += 4

    # eliminar lineas vacias y etiquetas
    for item in eliminar:
        instrList.remove(item)
    # ---------------------------------------------------

    contador = 0
    for instr in instrList:
        binary_instr = ''
        lista = instr.split(' ')

        if lista[0] in dp_scalar: 
            # data-processing scalar instruction
            binary_instr = dp_scalar['cond+op'] # Cond + Op

            if len(lista) == 4: 
                # SUM, RES, MUL, DIV, MOD
                if lista[3] in registers:
                    # register-register 
                    binary_instr += dp_scalar['register']  # I = 0
                    
                    Src2 =  '000000'+ registers[lista[3]]  # - + Rm
                else:
                    # register-immediate
                    binary_instr += dp_scalar['immediate'] # I = 1

                    # se convierte el numero inmediato a binario de 10 bits
                    Src2 = str(bin(int(lista[3]))[2:].zfill(10)) # Src2

                binary_instr += dp_scalar[lista[0]] # Tipo + S
                Rd = registers[lista[1]]
                Rn = registers[lista[2]]

                binary_instr += Rd
                binary_instr += Rn
                binary_instr += Src2

            elif len(lista) == 3:
                # MOV, EQV
                if lista[0] == 'MOV':
                    if lista[2] in registers:
                        # register-register 
                        binary_instr += dp_scalar['register']  # I = 0
                        Rd = registers[lista[1]]
                        Rn = '0000'
                        Src2 = '000000' + registers[lista[2]] # - + Rm
                        
                    else:
                        # register-immediate
                        binary_instr += dp_scalar['immediate'] # I = 1
                        Rd = registers[lista[1]]
                        Rn = '0000'

                        # se convierte el numero inmediato a binario de 10 bits
                        Src2 = str(bin(int(lista[2]))[2:].zfill(10))

                else:
                    if lista[2] in registers:
                        # register
                        binary_instr += dp_scalar['register']  # I = 0
                        Rd = '1111'
                        Rn = registers[lista[1]]
                        Src2 = '000000' + registers[lista[2]]  # - + Rm
                    else:
                        # immediate
                        binary_instr += dp_scalar['immediate'] # I = 1
                        Rd = '1111'
                        Rn = registers[lista[1]]

                        # se convierte el numero inmediato a binario de 10 bits
                        Src2 = str(bin(int(lista[2]))[2:].zfill(10))

                binary_instr += dp_scalar[lista[0]] # Tipo + S
                binary_instr += Rd
                binary_instr += Rn
                binary_instr += Src2

        elif lista[0] in dp_vectorial:
            # data-processing scalar instruction
            binary_instr = dp_vectorial['cond+op+i'] # Cond + Op + I
            binary_instr += dp_vectorial[lista[0]] # Tipo + S

            Rd = registers_vectorial[lista[1]]
            Rn = registers_vectorial[lista[2]]
            Src2 =  '000000'+ registers_vectorial[lista[3]]  # - + Rm

            binary_instr += Rd
            binary_instr += Rn
            binary_instr += Src2
        
        elif lista[0] in mem_escalar: 
            # memory escalar instruction
            binary_instr += mem_escalar['cond+op'] # Cond + Op
            binary_instr += mem_escalar[lista[0]]  # Tipo + L
            Rd = registers[lista[1]]
            Rn = registers[lista[2]]
            Src2 = '0000000000'

            binary_instr += Rd
            binary_instr += Rn
            binary_instr += Src2

        elif lista[0] in mem_vectorial:
            # memory vectorial instruction
            binary_instr += mem_vectorial['cond+op'] # Cond + Op
            binary_instr += mem_vectorial[lista[0]]  # Tipo + L
            Rd = registers_vectorial[lista[1]]
            Rn = registers[lista[2]]
            Src2 = '0000000000'

            binary_instr += Rd
            binary_instr += Rn
            binary_instr += Src2

        else:
            # control instruction
            binary_instr += control[lista[0]]
            origen = contador
            destino = 0
            direccion = 0

            # encontrar direccion destino de salto
            for item in etiquetas:
                tuplalista = list(item)

                # si la etiqueta es igual a la que se busca
                if tuplalista[0] == lista[1]:
                    destino = tuplalista[1] 
                    break
        
            # calcular direccion de salto (logica de extend al revés)
            diferencia = destino - origen - 8 # pc + 8
            diferencia = diferencia // 4

            if diferencia >= 0:
                # salto hacia adelante
                direccion = str(bin(diferencia)[2:].zfill(22))
            else:
                # salto hacia atras
                complemento = bin(diferencia % (1<<22))
                direccion = str(complemento[2:])

            binary_instr += direccion

        # complete 32 bits
        binary_instr =  '00000' + binary_instr 
        decimal = int(binary_instr, 2)
        hexa = hex(decimal)
        
        list_hex.append(hexa[2:])
        contador += 4 # pc + 4
    
    # escribir en archivo
    f = open('machine_code.dat', 'w')
    for i, instr in enumerate(list_hex):
        if i != len(list_hex) - 1:
            f.write(instr + '\n')
        else:
            f.write(instr)
    f.close()

compiler()