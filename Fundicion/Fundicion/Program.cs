using System;

class Program
{
    //Pilas de autos almacenados y fundidos
    public static PilaEnlazada compactos = new PilaEnlazada();
    public static PilaEnlazada compactosFundidos = new PilaEnlazada();
    public static PilaEnlazada camionetas = new PilaEnlazada();
    public static PilaEnlazada camionetasFundidas = new PilaEnlazada();
    public static PilaEnlazada vagonetas = new PilaEnlazada();
    public static PilaEnlazada vagonetasFundidas = new PilaEnlazada();
    public static PilaEnlazada camiones = new PilaEnlazada();
    public static PilaEnlazada camionesFundidos = new PilaEnlazada();
    public static PilaEnlazada autobuses = new PilaEnlazada();
    public static PilaEnlazada autobusesFundidos = new PilaEnlazada();
    
    //Clasificaciones de autos en plural y singular
    public static string[] clasificaciones = [
            "Compactos", 
            "Camionetas", 
            "Vagonetas",
            "Camiones",
            "Autobuses"
        ];
    public static string[] clasificacionesSingular = [
            "Compacto", 
            "Camioneta", 
            "Vagoneta",
            "Camión",
            "Autobuses"
        ];

    static void Main(string[] args)
    {
        //Carga de autos compactos
        compactos.AgregarAlFinal("SUIM","Subaru Impreza");
        compactos.AgregarAlFinal("TOSU","Toyota Supra");
        compactos.AgregarAlFinal("HOCI","Honda Civic");
        compactos.AgregarAlFinal("MAMX5","Mazda MX-5");
        compactos.AgregarAlFinal("HOACC","Honda Accord");

        //Carga de camionetas
        camionetas.AgregarAlFinal("MACX9","Mazda CX-9");
        camionetas.AgregarAlFinal("HOCRV","Honda CR-V");
        camionetas.AgregarAlFinal("VWTIG","Volkswagen Tiguan");
        
        //Carga de vagonetas
        vagonetas.AgregarAlFinal("MIXPA","Mitsubishi Xpander");  
        vagonetas.AgregarAlFinal("TOYSI","Toyota Sienna");
        vagonetas.AgregarAlFinal("CRYPA","Chrysler Pacifica");

        //Carga de camiones
        camiones.AgregarAlFinal("VOLGA","Volvo Gama FH");
        camiones.AgregarAlFinal("MERAC","Mercedes Actros");
        camiones.AgregarAlFinal("RETUCK","Renault Truck Gama");
        
        //Carga de autobuses
        autobuses.AgregarAlFinal("MERMB","Mercedes-Benz MBO 1421 ");  
        autobuses.AgregarAlFinal("VOLB","Volvo B13R");
        autobuses.AgregarAlFinal("MANLI","Man Lions Coach");

        int opc;
        do
            opc = Menu();
        while (opc != 6);
    }
    public static int Menu()
    {
        Console.Clear();
        Titulo(10,1,"Fundición de autos");

        PrintXY(5,3,"1. Ingresar auto");
        PrintXY(5,4,"2. Fundir auto");
        PrintXY(5,5,"3. Autos por calificación");
        PrintXY(5,6,"4. Autos totales");
        PrintXY(5,7,"5. Autos fundidos");
        PrintXY(5,8,"6. Salir");

        Instruccion(5,10,"> ");

        int opc = LeerNumero(1, 6);

        //Menu
        switch (opc)
        {
            case 1: IngresarAuto(); break;
            case 2: RetirarAuto(); break;
            case 3: AutosClasificacion(); break;
            case 4: AutosTotales(); break;
            case 5: AutosRetirados(); break;
            case 6: Salir(); break;
        }
        return opc;
    }
    //Opcion 1
    public static void IngresarAuto()
    {
        bool respuesta;
        do
        {
            PilaEnlazada[] pilas = [compactos, camionetas, vagonetas, camiones, autobuses];
            Console.Clear();
            Titulo(10,1, "Ingresar Auto");

            Instruccion(5,3, "Seleccione la categoría de su auto:");
            Lista(clasificaciones);
            Instruccion(5, Top(2), "> ");

            int categoria = LeerNumero(1, 5) - 1;

            if(validarEspacio(pilas[categoria], categoria))
            {
                Nodo nuevoNodo = solicitarDatos();
                pilas[categoria].Push(nuevoNodo.Valor1, nuevoNodo.Valor2);
                Correcto(5, Top(1), $"{clasificacionesSingular[categoria]} \"{nuevoNodo.Valor2}\" ingresado correctamente en la posición {pilas[categoria].ContarElementos()}!");
            }

            respuesta = Pregunta(5, Top(3), "¿Desea ingresar otro auto?"); 
        } while (respuesta);
    }
    public static bool validarEspacio(PilaEnlazada pila, int categoria){
        if(pila.ContarElementos() == 10){    
            Error(5, Top(1), $"La categoría \"{clasificaciones[categoria]}\" está llena");
            return false;
        }
        return true;
    }
    public static Nodo solicitarDatos(){
        Instruccion(5, Top(1), "Ingrese el código del auto: ");
        string codigo = Console.ReadLine();
        Instruccion(5, Top(1), "Ingresa la descripcion del auto: ");
        string descripcion = Console.ReadLine();

        Nodo nuevoNodo = new Nodo(codigo, descripcion);
        return nuevoNodo;
    }

    //Opcion 2
    public static void RetirarAuto(){
        bool respuesta;
        do
        {
            Console.Clear();
            Titulo(10,1,"Fundir Auto");
            
            PilaEnlazada[] pilas = [compactos, camionetas, vagonetas, camiones, autobuses];
            PilaEnlazada[] pilasFundidas = [compactosFundidos, camionetasFundidas, vagonetasFundidas, camionesFundidos, autobusesFundidos];	

            Instruccion(5,3, "Selecciona una categoría de autos para fundir:");
            Lista(clasificaciones);

            Instruccion(5, Top(2), "> ");

            int opc = LeerNumero(1,5) - 1;

            if (pilas[opc].ContarElementos() == 0)
                Error(5, Top(1), $"No hay autos en la categoría {clasificaciones[opc]}");
            else
            {
                Nodo eliminado = pilas[opc].Peek();
            
                PrintXY(5, Top(1), $"Se fundirá {clasificacionesSingular[opc]} \"{eliminado.Valor2}\" con código \"{eliminado.Valor1}\" en la posición {pilas[opc].ContarElementos()}");
                respuesta = Pregunta(5, Top(2), "¿Está seguro?");
                if(respuesta)
                {
                    pilas[opc].Pop();
                    pilasFundidas[opc].Push(eliminado.Valor1, eliminado.Valor2);
                    
                    Correcto(5, Top(1), $"Se fundió el auto \"{eliminado.Valor2}\"");
                }
                else
                    Correcto(5, Top(1), $"No se fundió el auto \"{eliminado.Valor2}\"");
            }

            respuesta = Pregunta(5, Top(3), "¿Desea fundir otro auto?"); 
        } while (respuesta);
    }
    //Opcion 3
    public static void AutosClasificacion()
    {
        bool respuesta;
        do
        {
            Console.Clear();
            PilaEnlazada[] pilas = [compactos, camionetas, vagonetas, camiones, autobuses];
            Titulo(10,1,"Autos por clasificación");
            Instruccion(5,3, "Selecciona una categoría de autos para visualizar:");
            Lista(clasificaciones);

            Instruccion(5, Top(2), "> ");
            
            int opc = LeerNumero(1,5) - 1;  
            
            Subtitulo(15, Top(1), $"{clasificaciones[opc]}");
            pilas[opc].Enlistar(Top(1));

            respuesta = Pregunta(5, Top(3), "¿Desea desplegar otra categoría?"); 
        } while (respuesta);
    }
    //Opcion 4
    public static void AutosTotales()
    {
        Console.Clear();
        PilaEnlazada[] pilas = [compactos, camionetas, vagonetas, camiones, autobuses];
        
        Titulo(10,1,"Autos totales");

        int i = 0;
        int contador = 0;
        PrintXY(5,2);

        foreach (PilaEnlazada pila in pilas)
        {
            Subtitulo(5, Top(1), $"{clasificaciones[i]}: ");
            PrintXY(20, Top(), pila.ContarElementos().ToString());
            i++;
            contador += pila.ContarElementos();
        }
        Correcto(5, Top(2), "Total de autos ingresados: ");
        PrintXY(35, Top(), contador.ToString());
        
        Continuar(5,Top(3));
    }
    //Opcion 5
    public static void AutosRetirados()
    {
        bool respuesta;
        do
        {
            Console.Clear();
            PilaEnlazada[] pilasFundidas = [compactosFundidos, camionetasFundidas, vagonetasFundidas, camionesFundidos, autobusesFundidos];

            Titulo(10,1,"Autos fundidos");
            Instruccion(5,3, "Selecciona una categoría de autos para visualizar:");
            Lista(clasificaciones);

            Instruccion(5, Top(2), "> ");
            
            int opc = LeerNumero(1,5) - 1;  
            
            Subtitulo(15, Top(1), $"{clasificaciones[opc]}");
            pilasFundidas[opc].Enlistar(Top(1));

            respuesta = Pregunta(5, Top(3),"¿Desea desplegar otra categoría?"); 
        } while (respuesta);
    }
    //Opcion 6
    public static void Salir()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintXY(5, Top(3), "Presione ENTER para salir...");
        Console.ResetColor();
        Console.ReadKey();
        Console.WriteLine();
    }


    //Lógica
    public static bool Pregunta(int x, int y, string msg)
    {
        PrintXY(x, y);
        return Pregunta(msg);
    }
    
    public static bool Pregunta(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(msg + " (S/n): ");
        Console.ResetColor();

        string resp = "";
        int x = Left();
        int y = Top();

        do
        {
            PrintXY(x, y, Espacios(resp.Length));
            PrintXY(x, y);
            resp = Console.ReadLine().ToUpper();
        } while (resp != "S" && resp != "N");

        return resp.Equals("S");
    }
    //Validar que el número ingresado esté dentro del rango dado
    public static int LeerNumero(int min, int max)
    {
        int num;

        int x = Left();
        int y = Top();
        
        do
        {
            PrintXY(x, y);
            num = LeerNumero(); 
            if (num < min || num > max)
                BorrarLectura(x, y, num);
        } while (num < min || num > max);

        return num;
    }
    //Validar que lo ingresado se pueda convertir a número
    public static int LeerNumero()
    {
        bool repetir;
        int num;

        int x = Left();
        int y = Top();

        do
        {
            PrintXY(x, y);
            string lectura = Console.ReadLine();
            if(int.TryParse(lectura, out num))
                repetir = false;
            else
            {
                BorrarLectura(x, y, lectura);
                repetir = true;
            }
        } while (repetir);

        return num;
    }
    public static void Lista(string[] lista)
    {
        for (int i = 0; i < lista.Length; i++)
            PrintXY(5,i + 5,$"{i+1}. {lista[i]}");
    }

    //Opciones de diseño
    public static void Continuar(int x, int y){
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintXY(x, y, "Presione ENTER para continuar...");
        Console.ResetColor();
        Console.ReadKey();
    }
    public static void Instruccion(int x, int y, string texto){
        Console.ForegroundColor = ConsoleColor.Yellow;
        PrintXY(x, y, texto);
        Console.ResetColor();
    }
    public static void Titulo(int x, int y, string texto){
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintXY(x, y, texto);
        Console.ResetColor();
    }
    public static void Subtitulo(int x, int y, string texto){
        Console.ForegroundColor = ConsoleColor.Cyan;
        PrintXY(x, y, texto);
        Console.ResetColor();
    }
    public static void Correcto(int x, int y, string texto){
        Console.ForegroundColor = ConsoleColor.Green;
        PrintXY(x, y, texto);
        Console.ResetColor();
    }
    public static void Error(int x, int y, string texto){
        Console.ForegroundColor = ConsoleColor.Red;
        PrintXY(x, y, texto);
        Console.ResetColor();
    }

    //Posicionamiento de cursor
    public static void PrintXY(int x, int y){
        Console.SetCursorPosition(x,y);
    }
    public static void PrintXY(int x, int y, string text){
        Console.SetCursorPosition(x,y);
        Console.Write(text);
    }
    public static int Top(){
        return Console.CursorTop;
    }
    public static int Top(int filas){
        return Console.CursorTop + filas;
    }
    public static int Left(){
        return Console.CursorLeft;
    }
    public static int Left(int columnas){
        return Console.CursorLeft + columnas;
    }
    public static string Espacios(int cant)
    {
        return new string(' ', cant);
    }
    public static void BorrarLectura(int x, int y, string lectura)
    {
        PrintXY(x, y, Espacios(lectura.Length));
    }
    public static void BorrarLectura(int x, int y, int num)
    {
        PrintXY(x, y, Espacios(num.ToString().Length));
    }
}






//Método para fundir auto deprecado
    // int opc;
    // Nodo eliminado;
    // do{
    //     PrintXY(7, y);
    //     opc = LeerNumero(1,5) - 1; 
    //     BorrarLectura("                                        ", 5, 10);
        
    //     if(pilas[opc].ContarElementos() != 0)
    //         break;
    //     Error(5, y - 3, $"No hay autos en la categoría {clasificaciones[opc]}");
    //     BorrarLectura(" ", 7, y);
    // } while(true);
    // BorrarLectura("                                        ", 5, 10);
    // eliminado = pilas[opc].Peek();
    
    // PrintXY(5, Console.CursorTop + 3, $"Se fundirá {clasificacionesSingular[opc]} \"{eliminado.Valor2}\" con código \"{eliminado.Valor1}\" en la posición {pilas[opc].ContarElementos()}");
    // respuesta = Pregunta("¿Está seguro?", 5, Console.CursorTop - 1);
    // if(respuesta)
    // {
    //     pilas[opc].Pop();
    //     Correcto(5, Console.CursorTop, $"Se fundió el auto \"{eliminado.Valor2}\"");
    //     pilasFundidas[opc].Push(eliminado.Valor1, eliminado.Valor2);
    // }
    // else
    //     Correcto(5, Console.CursorTop, $"No se fundió el auto \"{eliminado.Valor2}\"");