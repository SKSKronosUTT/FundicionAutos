using System;

public class ListaEnlazada
{
    private Nodo primero;
    private int contador;

    public ListaEnlazada()
    {
        primero = null;
        contador = 0;
    }

    // Método para agregar al final
    public void AgregarAlFinal(object valor1, object valor2)
    {
        Nodo nuevoNodo = new Nodo(valor1, valor2);
        if (primero == null)
        {
            primero = nuevoNodo;
        }
        else
        {
            Nodo actual = primero;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
        contador++;
    }

    public void Enlistar(int y){
        if(primero == null) {
            Program.Error(10,y + 1, "Lista vacia!");
            return;
        }
        Nodo actual = primero;
        
        Program.Subtitulo(8,y,"Código");
        Program.Subtitulo(25,y,"Descripcion");
        y++;
        Program.PrintXY(8,y,"------");
        Program.PrintXY(25,y,"-----------");
        y++;
        int contador = 0;
        while (actual != null)
        {
            Program.PrintXY(5,contador + y,$"{contador + 1}. {actual.Valor1}");
            Program.PrintXY(25,contador + y,actual.Valor2.ToString());
            actual = actual.Siguiente;
            contador++;
        }
    }

    // Método para eliminar por valor
    public void EliminarPorValor(object valor)
    {
        if (primero == null)
        {
            Console.WriteLine("Lista vacía. No se puede eliminar ningún elemento.");
            return;
        }
        
        if (primero.Valor1.ToString().Equals(valor.ToString()))
        {
            primero = primero.Siguiente;
            contador--;
            Console.WriteLine($"El Auto '{valor}' ha sido eliminado correctamente.");
            return;
        }

        Nodo actual = primero;
        while (actual.Siguiente != null && !actual.Siguiente.Valor1.ToString().Equals(valor.ToString()))
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente != null)
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            contador--;
            Console.WriteLine($"El Auto '{valor}' ha sido eliminado correctamente.");
        }
        else
        {
            Console.WriteLine($"No se encontró ningún Auto con el nombre '{valor}'.");
        }
    }

    public void EliminarIndice(int indice){
        if (indice >= 0 && indice < contador)
        {
            if (indice == 0)
            {
                if (primero != null)
                {
                    primero = primero.Siguiente;
                    contador--;
                }
                return;
            }

            //Recorrer la lista para encontrar 
            Nodo actual = primero;
            for (int i = 0; i < indice - 1; i++)
                actual = actual.Siguiente;
            if (actual.Siguiente != null)
                actual.Siguiente = actual.Siguiente.Siguiente;
            contador--;
        }
        else{
            Console.Write("Índice fuera de rango");
            return;
        }
    }

    // Método para buscar por valor
    public Nodo BuscarPorValor(object valor)
    {
        if (primero == null)
        {
            return null;
        }
        
        Nodo actual = primero;
        
        while (actual != null)
        {
            if (actual.Valor1.ToString().Equals(valor.ToString()))
            {
                return actual;
            }
            actual = actual.Siguiente;
        }
        
        return null;
    }

    public Nodo BuscarIndice(int indice){
        if (indice == 0)
            return primero;

        //Se va a recorrer la lista hasta encontrar el indice
        Nodo actual = primero;
        for (int i = 0; i < indice; i++)
            actual = actual.Siguiente;
        return actual;
    }
    
    // Método para eliminar toda la lista
    public void EliminarLista()
    {
        primero = null;
        contador = 0;
    }

    // Método para contar elementos
    public int ContarElementos()
    {
        return contador;
    }
}