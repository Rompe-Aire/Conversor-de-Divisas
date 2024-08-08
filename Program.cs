class Program
{
    // Diccionario para almacenar las divisas y sus valores
    static Dictionary<string, decimal> divisas = new Dictionary<string, decimal>();

    // Ruta del archivo donde se guardan las divisas
    const string filePath = "values.txt";

    // Nombre de la divisa por defecto (Dólar)
    const string defaultCurrency = "USD";

    // Valor por defecto del Dólar
    const decimal defaultValue = 1.0m;

    static void Main(string[] args)
    {
        // Cargar las divisas desde el archivo al iniciar el programa
        LoadDivisas();
        int opcion; // Variable para almacenar la opción seleccionada por el usuario

        do
        {
            Console.Clear(); // Limpiar la consola al inicio del ciclo
            // Mostrar el menú de opciones al usuario
            Console.WriteLine("\n--- Conversor de Divisas ---");
            Console.WriteLine("1. Agregar divisa");
            Console.WriteLine("2. Cambiar valor de divisa");
            Console.WriteLine("3. Convertir divisa");
            Console.WriteLine("4. Ver lista de divisas");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine()); // Leer la opción del usuario

            // Ejecutar la opción seleccionada
            switch (opcion)
            {
                case 1:
                    AgregarDivisa(); // Llamar al método para agregar una nueva divisa
                    break;
                case 2:
                    CambiarValorDivisa(); // Llamar al método para cambiar el valor de una divisa
                    break;
                case 3:
                    ConvertirDivisa(); // Llamar al método para convertir divisas
                    break;
                case 4:
                    VerListaDivisas(); // Llamar al método para mostrar la lista de divisas
                    break;
                case 5:
                    Console.WriteLine("Saliendo..."); // Mensaje al salir del programa
                    break;
                default:
                    Console.WriteLine("Opción inválida, por favor intente de nuevo."); // Mensaje de error para opción inválida
                    break;
            }

            // Llamar a la función de pausa después de cada operación
            PauseAndClear();

        } while (opcion != 5); // Continuar hasta que el usuario elija salir
    }

    // Método para cargar las divisas desde el archivo
    static void LoadDivisas()
    {
        if (File.Exists(filePath)) // Verificar si el archivo existe
        {
            string[] lineas = File.ReadAllLines(filePath); // Leer todas las líneas del archivo
            if (lineas.Length == 0) // Si el archivo está vacío
            {
                divisas[defaultCurrency] = defaultValue; // Agregar el dólar por defecto
            }
            else
            {
                // Procesar cada línea del archivo
                foreach (string linea in lineas)
                {
                    var partes = linea.Split(','); // Dividir la línea en partes usando la coma como separador
                    // Verificar que hay exactamente dos partes y que la segunda parte es un valor decimal
                    if (partes.Length == 2 && decimal.TryParse(partes[1], out decimal valor))
                    {
                        divisas[partes[0]] = valor; // Agregar la divisa al diccionario
                    }
                }
            }
        }
        else
        {
            // Si el archivo no existe, lo creamos y agregamos la divisa dólar
            GuardarDivisas(); // Guardar la divisa por defecto en el archivo
            divisas[defaultCurrency] = defaultValue; // Agregar el dólar por defecto al diccionario
        }
    }

    // Método para guardar las divisas en el archivo
    static void GuardarDivisas()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Escribir cada divisa y su valor en una nueva línea en el archivo
            foreach (var divisa in divisas)
            {
                writer.WriteLine($"{divisa.Key},{divisa.Value}");
            }
        }
    }

    // Método para agregar una nueva divisa
    static void AgregarDivisa()
    {
        Console.Clear(); // Limpiar la consola
        Console.Write("Ingrese el nombre de la divisa (máximo 3 letras): ");
        string nombre = Console.ReadLine(); // Leer el nombre de la divisa

        // Verificar que el nombre no exceda 3 caracteres
        if (nombre.Length > 3)
        {
            Console.WriteLine("Error: El nombre de la divisa debe tener un máximo de 3 letras.");
            return; // Salir de la función si el nombre es inválido
        }

        Console.Write("Ingrese el valor de la divisa: ");
        decimal valor; // Variable para almacenar el valor de la divisa
        // Validar que el valor ingresado sea un número decimal positivo
        while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0)
        {
            Console.WriteLine("Error: Ingrese un valor válido y positivo.");
            Console.Write("Ingrese el valor de la divisa: ");
        }

        // Verificar si la divisa ya existe en el diccionario
        if (!divisas.ContainsKey(nombre))
        {
            divisas[nombre] = valor; // Agregar la divisa y su valor al diccionario
            GuardarDivisas(); // Guardar las divisas actualizadas en el archivo
            Console.WriteLine("Divisa agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("La divisa ya existe."); // Mensaje si la divisa ya está en el diccionario
        }
    }

    // Método para cambiar el valor de una divisa existente
    static void CambiarValorDivisa()
    {
        Console.Clear(); // Limpiar la consola
        Console.Write("Ingrese el nombre de la divisa a cambiar (máximo 3 letras): ");
        string nombre = Console.ReadLine(); // Leer el nombre de la divisa

        // Verificar que el nombre no exceda 3 caracteres
        if (nombre.Length > 3)
        {
            Console.WriteLine("Error: El nombre de la divisa debe tener un máximo de 3 letras.");
            return; // Salir de la función si el nombre es inválido
        }

        // Verificar si la divisa existe en el diccionario
        if (divisas.ContainsKey(nombre))
        {
            Console.Write("Ingrese el nuevo valor de la divisa: ");
            decimal nuevoValor; // Variable para almacenar el nuevo valor de la divisa
            // Validar que el nuevo valor ingresado sea un número decimal positivo
            while (!decimal.TryParse(Console.ReadLine(), out nuevoValor) || nuevoValor <= 0)
            {
                Console.WriteLine("Error: Ingrese un valor válido y positivo.");
                Console.Write("Ingrese el nuevo valor de la divisa: ");
            }

            divisas[nombre] = nuevoValor; // Actualizar el valor de la divisa en el diccionario
            GuardarDivisas(); // Guardar las divisas actualizadas en el archivo
            Console.WriteLine("Valor de la divisa cambiado exitosamente.");
        }
        else
        {
            Console.WriteLine("La divisa no existe."); // Mensaje si la divisa no está en el diccionario
        }
    }

    // Método para convertir una cantidad de una divisa a otra
    static void ConvertirDivisa()
    {
        Console.Clear(); // Limpiar la consola
        Console.Write("Ingrese la divisa de origen (máximo 3 letras): ");
        string divisaOrigen = Console.ReadLine(); // Leer la divisa de origen

        // Verificar que el nombre no exceda 3 caracteres
        if (divisaOrigen.Length > 3)
        {
            Console.WriteLine("Error: El nombre de la divisa debe tener un máximo de 3 letras.");
            return; // Salir de la función si el nombre es inválido
        }

        Console.Write("Ingrese la divisa de destino (máximo 3 letras): ");
        string divisaDestino = Console.ReadLine(); // Leer la divisa de destino

        // Verificar que el nombre no exceda 3 caracteres
        if (divisaDestino.Length > 3)
        {
            Console.WriteLine("Error: El nombre de la divisa debe tener un máximo de 3 letras.");
            return; // Salir de la función si el nombre es inválido
        }

        // Verificar si ambas divisas existen en el diccionario
        if (divisas.ContainsKey(divisaOrigen) && divisas.ContainsKey(divisaDestino))
        {
            Console.Write("Ingrese la cantidad a convertir: ");
            decimal cantidad; // Variable para almacenar la cantidad a convertir
            // Validar que la cantidad ingresada sea un número decimal positivo
            while (!decimal.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Error: Ingrese una cantidad válida y positiva.");
                Console.Write("Ingrese la cantidad a convertir: ");
            }

            // Calcular el resultado de la conversión y redondear a 2 decimales
            decimal resultado = Math.Round((cantidad * divisas[divisaDestino]) / divisas[divisaOrigen], 2);
            Console.WriteLine($"{cantidad} {divisaOrigen} son {resultado} {divisaDestino}"); // Mostrar el resultado
        }
        else
        {
            Console.WriteLine("Una o ambas divisas no existen."); // Mensaje si una o ambas divisas no están en el diccionario
        }
    }

    // Método para ver la lista de divisas y sus valores
    static void VerListaDivisas()
    {
        Console.Clear(); // Limpiar la consola
        Console.WriteLine("\nLista de Divisas:");
        // Mostrar cada divisa y su valor
        foreach (var divisa in divisas)
        {
            Console.WriteLine($"{divisa.Key}: {Math.Round(divisa.Value, 2)}"); // Redondear a 2 decimales al mostrar
        }
    }

    // Método para pausar y limpiar la consola
    static void PauseAndClear()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey(); // Pausa hasta que el usuario presione una tecla
        Console.Clear(); // Limpia la consola antes de volver al menú
    }
}