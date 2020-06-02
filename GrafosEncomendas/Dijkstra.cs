using GrafosEncomendas.Entidades;
using GrafosEncomendas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrafosEncomendas
{
    public class Dijkstra : IDijkstra
    {
        private readonly List<Aresta> _arestas;
        private List<Nodo> _nodosResolvidos;
        private List<Nodo> _nodosNaoResolvidos;
        private Dictionary<Nodo, Nodo> _antecessores;
        private Dictionary<Nodo, int> _distancia;

        public Dijkstra(DadosGrafo grafo)
        {
            _arestas = new List<Aresta>(grafo.Arestas);
        }

        public void ExecutarHeuristica(Nodo origem)
        {
            _nodosResolvidos = new List<Nodo>();
            _nodosNaoResolvidos = new List<Nodo>();
            _distancia = new Dictionary<Nodo, int>();
            _antecessores = new Dictionary<Nodo, Nodo>();

            _distancia.Add(origem, 0);

            _nodosNaoResolvidos.Add(origem);
            while (_nodosNaoResolvidos.Count > 0)
            {
                Nodo node = BuscarMenor(_nodosNaoResolvidos);
                _nodosResolvidos.Add(node);
                _nodosNaoResolvidos.Remove(node);
                ObterDistanciasMinimas(node);
            }
        }

        public Percurso ObterRota(Nodo nodoDestino)
        {
            LinkedList<Nodo> caminho = new LinkedList<Nodo>();
            int distancia = 0;
            Nodo aux = nodoDestino;

            if (!_antecessores.TryGetValue(aux, out _))
            {
                return null;
            }
            caminho.AddLast(aux);
            while (_antecessores.TryGetValue(aux, out _))
            {
                distancia += _arestas.FindLast(a => a.Origem.Equals(_antecessores[aux]) && a.Destino.Equals(aux)).Valor;
                aux = _antecessores[aux];
                caminho.AddLast(aux);

            }
            return new Percurso(caminho.Reverse().ToList(), distancia);
        }

        private void ObterDistanciasMinimas(Nodo nodo)
        {
            List<Nodo> nodosAdjacentes = ObterNodosVizinhos(nodo);

            foreach (Nodo nodoDestino in nodosAdjacentes)
            {
                if (BuscaMenorDistancia(nodoDestino) > BuscaMenorDistancia(nodo)
                        + ObterDistancia(nodo, nodoDestino))
                {
                    _distancia.Add(nodoDestino, BuscaMenorDistancia(nodo)
                            + ObterDistancia(nodo, nodoDestino));
                    _antecessores.Add(nodoDestino, nodo);
                    _nodosNaoResolvidos.Add(nodoDestino);
                }
            }
        }

        private int ObterDistancia(Nodo nodo, Nodo nodoDestino)
        {
            foreach (Aresta aresta in _arestas)
            {
                if (aresta.Origem.Equals(nodo)
                        && aresta.Destino.Equals(nodoDestino))
                {
                    return aresta.Valor;
                }
            }
            return 0;
        }

        private List<Nodo> ObterNodosVizinhos(Nodo nodo)
        {
            List<Nodo> vizinhos = new List<Nodo>();
            foreach (Aresta aresta in _arestas)
            {
                if (aresta.Origem.Equals(nodo)
                        && !Resolvido(aresta.Destino))
                {
                    vizinhos.Add(aresta.Destino);
                }
            }
            return vizinhos;
        }

        private Nodo BuscarMenor(List<Nodo> nodos)
        {
            Nodo minimo = null;
            foreach (Nodo nodo in nodos)
            {
                if (minimo == null)
                {
                    minimo = nodo;
                }
                else
                {
                    if (BuscaMenorDistancia(nodo) < BuscaMenorDistancia(minimo))
                    {
                        minimo = nodo;
                    }
                }
            }
            return minimo;
        }

        private bool Resolvido(Nodo nodo)
        {
            return _nodosResolvidos.Contains(nodo);
        }

        private int BuscaMenorDistancia(Nodo destino)
        {
            if (_distancia.TryGetValue(destino, out int d))
            {
                return d;
            }
            else
            {
                return int.MaxValue;
            }
        }
    }
}
