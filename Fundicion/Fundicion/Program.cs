using System;
using System.Reflection.Emit;
//The type or namespace name 'PilaEnlazada' could not be found (are you missing a using directive or an assembly reference?)

class Program
{
    public static PilaEnlazada compactos = new PilaEnlazada();
    public static PilaEnlazada camionetas = new PilaEnlazada();
    public static PilaEnlazada vagonetas = new PilaEnlazada();
    public static PilaEnlazada camiones = new PilaEnlazada();
    public static PilaEnlazada autobuses = new PilaEnlazada();
    
    public static string[] clasificaciones = [
            "Compactos", 
            "Camionetas", 
            "Vagonetas",
            "Camiones",
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
        { opc = Menu();
        } while (opc != 6);
    }
    public static int Menu()
    {
        Console.Clear();
        Titulo(10,1,"Fundición de autos");

        PrintXY(5,3,"1. Ingresar auto");
        PrintXY(5,4,"2. Retirar auto");
        PrintXY(5,5,"3. Autos por calificación");
        PrintXY(5,6,"4. Autos totales");
        PrintXY(5,7,"5. Autos retirados");
        PrintXY(5,8,"6. Salir");
        Instruccion(5,10,"> ");

        int opc = LeerNumero(1, 6);

        //Menu
        switch (opc)
        {
            case 1: //IngresarAuto()
                break;
            case 2: RetirarAuto();
                break;
            case 3: AutosClasificacion(); break;
            case 4: AutosTotales(); break;
            case 5: AutosRetirados(); break;
            case 6: //Salir()
                break;
        }
        return opc;
    }
    //Opcion 1
    public static void IngresarAuto()
    {
        PilaEnlazada[] pilas=[compactos, camionetas,vagonetas,camiones,autobuses];
        Console.Clear();
        Titulo(10,1, "Ingrese un Auto");

        PrintXY(5, 2,"Tipo de Autos ");
        PrintXY(5,3,"1. Compactos");
        PrintXY(5,4,"2. Camionetas");
        PrintXY(5,5,"3. Vagonas");
        PrintXY(5,6,"4. Camiones");
        PrintXY(5,7,"5. Autobuses");
        
        PrintXY(5,8,"Ingrese el tipo de Auto: ");
        int opcion = LeerNumero(1,5);
        int indicePila =opcion -1;

        if(pilas[indicePila].ContarElementos()>= 10)
        {
            Console.Clear();
            //Error(5, 3, $La pila de [indicePila]);
        }
       
        Console.Clear();
        PrintXY(5,3, "Ingresa el codigo del Auto: ");
        
        PrintXY(5,3, "Ingresa la descripcion del Auto: ");
        
    }
    //Opcion 2
    public static void RetirarAuto()
    {
        Console.Clear();
        Titulo(10,1,"Retirar Auto");
        PilaEnlazada[] pilas = [compactos, camionetas, vagonetas, camiones, autobuses];
        PrintXY(5,3, "Ponte pila papi elige la pila jaja salu3");
        Lista(clasificaciones);
        int y = Console.CursorTop+1;
        
        PrintXY(5, y, ">");
        
        int opc;
        Nodo eliminado;
        do{
            opc = LeerNumero(1,5)-1;  
             
            if(pilas[opc].ContarElementos() != 0)
                break;
            
            BorrarLectura(" ", 5, y);
        } while(true);
        
        eliminado = pilas[opc].Peek();
        pilas[opc].Pop();

        Console.WriteLine($"     Sale manito ya salio el mofle {eliminado.Valor2}");

        Continuar(5,Console.CursorTop+3);
    }
    //Opcion 3
    public static void AutosClasificacion(){
        Console.Clear();
        PilaEnlazada[] pilas = [compactos, camionetas, vagonetas, camiones, autobuses];
        
        Titulo(10,1,"Autos por clasificación");
        int y = 3;
        int i = 0;
        foreach (PilaEnlazada pila in pilas)
        {
            Subtitulo(15,y+1, clasificaciones[i]);
            pila.Enlistar(y+2);
            y = Console.CursorTop + 1;
            i++;
        }
        
        Continuar(5,Console.CursorTop + 2);
    }
    //Opcion 4
    public static void AutosTotales()
    {
        Console.Clear();
        PilaEnlazada[] pilas = [compactos, camionetas, vagonetas, camiones, autobuses];
        
        Titulo(10,1,"Autos totales");
        int y = 2;
        int i = 0;
        foreach (PilaEnlazada pila in pilas)
        {
            Subtitulo(5,y+1, $"{clasificaciones[i]}: ");
            PrintXY(clasificaciones[i].Length + 7, y+1, pilas[i].ContarElementos().ToString());
            y++;
            i++;
        }
        
        Continuar(5,Console.CursorTop + 2);
    }
    //Opcion 5
    public static void AutosRetirados()
    {
        Console.Clear();
        Titulo(10,1, "Autos retirados");
        for (int i = 0; i < clasificaciones.Length; i++)
        {
            PrintXY(5, i + 3, $"{i+1}. {clasificaciones[i]}");
        }
        Continuar(5,Console.CursorTop + 2);
    }
    

    //Opciones de diseño
    public static bool Pregunta(string msg, int x, int y)
    {
        PrintXY(x, y);
        return Pregunta(msg);
    }
    
    public static bool Pregunta(string msg)
    {
        Console.Write(msg + " (S/n): ");

        string resp;
        int x = Console.CursorLeft;
        int y = Console.CursorTop;

        do
        {
            PrintXY(x, y);
            resp = Console.ReadLine().ToUpper();
            PrintXY(x, y, Espacios(resp.Length));
        } while (resp != "S" && resp != "N");

        return resp.Equals("S");
    }
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
        Console.ForegroundColor = ConsoleColor.Red;
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
        PrintXY(x,y,texto);
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
    public static string Espacios(int cant)
    {
        return new string(' ', cant);
    }

    public static int LeerNumero(int min, int max)
    {
        int num;
        do
        {
            num = LeerNumero(); 
            if (num < min || num > max)
            {
                BorrarLectura(num, Console.CursorLeft, Console.CursorTop-1);
            }
        } while (num < min || num > max);

        return num;
    }

    public static int LeerNumero()
    {
        bool repetir;
        int num;

        int x = Console.CursorLeft;
        int y = Console.CursorTop;

        do
        {
            PrintXY(x, y);
            string lectura = Console.ReadLine();
            if(int.TryParse(lectura, out num))
            {
                repetir = false;
            } else
            {
                BorrarLectura(lectura, x, y);
                repetir = true;
            }
        } while (repetir);

        return num;
    }

    public static void Lista(string[] lista)
    {
        for (int i = 0; i < lista.Length; i++)
        {
            Console.WriteLine($"{Espacios(5)}{i+1}. {lista[i]}");
        }
    }

    public static void BorrarLectura(string lectura, int x, int y)
    {
        PrintXY(x, y, Espacios(lectura.Length));
    }
    
    public static void BorrarLectura(int num, int x, int y)
    {
        PrintXY(x, y, Espacios(num.ToString().Length));
    }
}