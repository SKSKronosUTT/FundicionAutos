public class PilaEnlazada : ListaEnlazada
{
    public PilaEnlazada() : base()
    {
    }
    public void Push(object valor1, object valor2)
    {
        this.AgregarAlFinal(valor1, valor2);
    }
    public void Pop()
    {
        this.EliminarIndice(this.ContarElementos()-1);
    }
    public Nodo Peek()
    {
        return this.BuscarIndice(this.ContarElementos()-1);
    }
}