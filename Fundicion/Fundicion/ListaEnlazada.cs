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

    public Nodo BuscarIndice(int indice){
        if (indice == 0)
            return primero;

        //Se va a recorrer la lista hasta encontrar el indice
        Nodo actual = primero;
        for (int i = 0; i < indice; i++)
            actual = actual.Siguiente;
        return actual;
    }

    // Método para contar elementos
    public int ContarElementos()
    {
        return contador;
    }
}