import numpy as np
import matplotlib.pyplot as plt

# Función para trazar una línea en una matriz de píxeles
def plot_line(x1, y1, x2, y2, matrix, color):
    # Calcular las diferencias en las coordenadas x e y
    dx = abs(x2 - x1)
    dy = abs(y2 - y1)
    
    # Inicializar las coordenadas de inicio (x, y)
    x, y = x1, y1
    
    # Determinar la dirección de incremento en x (sx) e y (sy)
    sx = 1 if x1 < x2 else -1
    sy = 1 if y1 < y2 else -1

    if dx > dy:
        # Si la diferencia en x es mayor que en y, se utiliza el algoritmo de Bresenham para trazar la línea
        err = dx / 2.0  # Inicializar el error
        while x != x2:
            matrix[y, x] = color  # Establecer el píxel en la matriz con el color especificado
            err -= dy  # Actualizar el error
            if err < 0:
                y += sy  # Moverse verticalmente (arriba o abajo) si el error es negativo
                err += dx  # Restablecer el error
            x += sx  # Moverse horizontalmente (derecha o izquierda)
    else:
        # Si la diferencia en y es mayor que en x, se utiliza un enfoque similar
        err = dy / 2.0  # Inicializar el error
        while y != y2:
            matrix[y, x] = color  # Establecer el píxel en la matriz con el color especificado
            err -= dx  # Actualizar el error
            if err < 0:
                x += sx  # Moverse horizontalmente (derecha o izquierda) si el error es negativo
                err += dy  # Restablecer el error
            y += sy  # Moverse verticalmente (arriba o abajo)
    
    # Establecer el último píxel en la línea
    matrix[y, x] = color


# Función para trazar un cubo en la matriz de píxeles
def plot_cube(x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6, x7, y7, x8, y8):
    white = [255, 255, 255]

    # Trazar las líneas que forman el cubo
    plot_line(x1, y1, x2, y2, plane, white)
    plot_line(x2, y2, x3, y3, plane, white)
    plot_line(x3, y3, x4, y4, plane, white)
    plot_line(x4, y4, x1, y1, plane, white)

    plot_line(x1, y1, x5, y5, plane, white)
    plot_line(x2, y2, x6, y6, plane, white)
    plot_line(x3, y3, x7, y7, plane, white)
    plot_line(x4, y4, x8, y8, plane, white)

    plot_line(x5, y5, x6, y6, plane, white)
    plot_line(x6, y6, x7, y7, plane, white)
    plot_line(x7, y7, x8, y8, plane, white)
    plot_line(x8, y8, x5, y5, plane, white)


if __name__ == "__main__":
    # Configuración de la matriz de píxeles y las coordenadas de los vértices
    width, height = 640, 480
    plane = np.zeros((height, width, 3), dtype=np.uint8)

    x1, y1 = 100, 100
    x2, y2 = 200, 100
    x3, y3 = 200, 200
    x4, y4 = 100, 200
    x5, y5 = x1 + 50, y1 - 50
    x6, y6 = x2 + 50, y2 - 50
    x7, y7 = x3 + 50, y3 - 50
    x8, y8 = x4 + 50, y4 - 50

   
    # Trazar el cubo en la matriz de píxeles
    plot_cube(x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6, x7, y7, x8, y8)

    # Mostrar la imagen resultante
    plt.imshow(plane, origin='lower')
    plt.show()
