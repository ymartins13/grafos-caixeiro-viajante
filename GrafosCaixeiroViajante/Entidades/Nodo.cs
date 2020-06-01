namespace GrafosCaixeiroViajante
{
    public class Nodo
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public Nodo(string id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
