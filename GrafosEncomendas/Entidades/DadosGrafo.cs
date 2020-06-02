using System.Collections.Generic;

namespace GrafosEncomendas.Entidades
{
    public class DadosGrafo
    {
        public List<Nodo> Nodos { get; set; }
        public List<Aresta> Arestas { get; set; }

        public DadosGrafo(List<Nodo> nodos, List<Aresta> arestas)
        {
            Nodos = nodos;
            Arestas = arestas;
        }

    }
}
