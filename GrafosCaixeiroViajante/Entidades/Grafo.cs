using System.Collections.Generic;

namespace GrafosEncomendas.Entidades
{
    public class Grafo
    {
        public List<Nodo> Nodos { get; set; }
        public List<Aresta> Arestas { get; set; }

        public Grafo(List<Nodo> nodos, List<Aresta> arestas)
        {
            Nodos = nodos;
            Arestas = arestas;
        }

    }
}
