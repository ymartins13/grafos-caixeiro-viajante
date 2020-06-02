using GrafosEncomendas.Entidades;

namespace GrafosEncomendas.Interfaces
{
    public interface IDijkstra
    {
        void ExecutarHeuristica(Nodo origem);
        Percurso ObterRota(Nodo nodoDestino);
    }
}
