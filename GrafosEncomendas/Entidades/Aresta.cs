namespace GrafosEncomendas.Entidades
{
    public class Aresta
    {
        public Nodo Destino { get; set; }
        public Nodo Origem { get; set; }
        public int Valor { get; set; }

        public Aresta(Nodo origem, Nodo destino, int valor)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }
    }
}
