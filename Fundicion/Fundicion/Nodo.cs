public class Nodo
{
    public object Valor1 { get; set; }
    public object Valor2 { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(object valor1, object valor2)
    {
        Valor1 = valor1;
        Valor2 = valor2;
        Siguiente = null;
    }
}
