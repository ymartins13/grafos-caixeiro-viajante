namespace GrafosCaixeiroViajante
{
    public class Aresta
    {
        public string Id { get; set; }
        public Nodo Destino { get; set; }
        public Nodo Origem { get; set; }
        public int Valor { get; set; }

        public Aresta(string id, Nodo origem, Nodo destino, int peso)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Valor = peso;
        }
    }
}
