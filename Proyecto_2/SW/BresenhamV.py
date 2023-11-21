import numpy as np
import matplotlib.pyplot as plt

import numpy as np

def plot_line_vectorized(x1, y1, x2, y2, matrix, color):
    # Calcular las diferencias en las coordenadas x e y
    dx = abs(x2 - x1)
    dy = abs(y2 - y1)
        
    # Determinar la dirección de incremento en x (sx) e y (sy)
    sx = np.sign(x2 - x1)
    sy = np.sign(y2 - y1)

    if dx != dy:
        
        # Si la diferencia en x es mayor que en y, se utiliza el algoritmo de Bresenham para trazar la línea
        num_iterations = (x2 - x1) // 4
        ydif = (y2 - y1)
        ydiv = ydif // dx
        for i in range(num_iterations):
            x1temp = x1 + i * 4
            x2temp = x1temp + 4
            x_values = np.arange(x1temp, x2temp, sx)
            y_values = np.round(y1 + (x_values - x1) * ydiv).astype(int)
            
            matrix[y_values, x_values] = color
            
    else:
        # Si la diferencia en y es mayor que en x, se utiliza un enfoque similar
        num_iterations = (y2 - y1) // 4
        xdiv =  (x2 - x1) / dy
        for i in range(num_iterations):
            y1temp = y1 + i * 4
            y2temp = y1temp + 4
            y_values = np.arange(y1temp, y2temp, sy)
            x_values = np.round(x1 + (y_values - y1) * xdiv).astype(int)
            matrix[y_values, x_values] = color


#plot triangle
def plot_triangle(matrix,x1,y1,x2,y2,x3,y3,color):


    plot_line_vectorized(x1, y1, x2, y2, matrix, color)
    plot_line_vectorized(x2, y2, x3, y3, matrix, color)
    plot_line_vectorized(x3, y3, x1, y1, matrix, color)



def main():
    # Create a matrix to represent the image
    white = np.array([255, 255, 255], dtype=np.uint8)  # White color
    image_matrix = np.full((480, 640, 3), white, dtype=np.uint8)

    # Set the endpoints of the line
    x1, y1 = 0, 0
    x2, y2 = 640, 480

    # Set the color (RGB values)
    black = np.array([0, 0, 0], dtype=np.uint8)  # Red color

    plot_line_vectorized(100, 100, 200, 200, image_matrix, black)
    plot_line_vectorized(200,100, 300, 200, image_matrix, black)
    plot_line_vectorized(100,100,200,100,image_matrix,black)
    plot_line_vectorized(200,200,300,200,image_matrix,black)

    # Display the image
    plt.imshow(image_matrix)
    plt.show()



if __name__ == '__main__':
    main()

    
