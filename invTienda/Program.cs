using System;
using System.Collections.Generic;

namespace invTienda
{
    class Program
    {
        static List<(string Codigo, string Nombre, int Cantidad, decimal Precio)> inventario = new List<(string, string, int, decimal)>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú de opciones:");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Modificar producto");
                Console.WriteLine("4. Consultar producto");
                Console.WriteLine("5. Mostrar todos los productos");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;
                    case 2:
                        EliminarProducto();
                        break;
                    case 3:
                        ModificarProducto();
                        break;
                    case 4:
                        ConsultarProducto();
                        break;
                    case 5:
                        MostrarTodosLosProductos();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (opcion != 6);
        }

        static void AgregarProducto()
        {
            Console.Write("Ingrese el código del producto: ");
            string codigo = Console.ReadLine();
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la cantidad del producto: ");
            int cantidad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio del producto: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            inventario.Add((codigo, nombre, cantidad, precio));
            Console.WriteLine("Producto agregado exitosamente.");
        }

        static void EliminarProducto()
        {
            Console.Write("Ingrese el código del producto a eliminar: ");
            string codigo = Console.ReadLine();

            var producto = inventario.Find(p => p.Codigo == codigo);
            if (producto != default)
            {
                inventario.Remove(producto);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void ModificarProducto()
        {
            Console.Write("Ingrese el código del producto a modificar: ");
            string codigo = Console.ReadLine();

            var index = inventario.FindIndex(p => p.Codigo == codigo);
            if (index != -1)
            {
                Console.Write("Ingrese el nuevo nombre del producto: ");
                string nuevoNombre = Console.ReadLine();
                Console.Write("Ingrese la nueva cantidad del producto: ");
                int nuevaCantidad = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el nuevo precio del producto: ");
                decimal nuevoPrecio = decimal.Parse(Console.ReadLine());

                inventario[index] = (codigo, nuevoNombre, nuevaCantidad, nuevoPrecio);
                Console.WriteLine("Producto modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void ConsultarProducto()
        {
            Console.Write("Ingrese el código del producto a consultar: ");
            string codigo = Console.ReadLine();

            var producto = inventario.Find(p => p.Codigo == codigo);
            if (producto != default)
            {
                Console.WriteLine($"Código: {producto.Codigo}");
                Console.WriteLine($"Nombre: {producto.Nombre}");
                Console.WriteLine($"Cantidad: {producto.Cantidad}");
                Console.WriteLine($"Precio: {producto.Precio}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        static void MostrarTodosLosProductos()
        {
            if (inventario.Count > 0)
            {
                foreach (var producto in inventario)
                {
                    Console.WriteLine($"Código: {producto.Codigo}, Nombre: {producto.Nombre}, Cantidad: {producto.Cantidad}, Precio: {producto.Precio}");
                }
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
        }
    }
}