




namespace Proyecto1
{
    internal class Program
    {

        static void Main(string[] args)
        {

            
            LoggerT.Start();

            LoggerT.LogReadReq(0, 0);
            // Crea una instancia de tu formulario
            GUI miFormulario = new();

            // Ejecuta el formulario
            Application.Run(miFormulario);
        }
    }
}