using GrafosEncomendas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrafosEncomendas.Util
{
    public static class GrafoUtil
    {
        public static DadosGrafo MontarGrafo(string[] trechos)
        {
            var nodos = new List<Nodo>();
            var arestas = new List<Aresta>();

            if (trechos != null)
            {
                foreach (var trecho in trechos)
                {
                    var dados = trecho.Split(" ");
                    if (dados.Length == 3)
                    {
                        if (!nodos.Any(x => x.Nome == dados[0]))
                            nodos.Add(new Nodo(dados[0]));
                        if (!nodos.Any(x => x.Nome == dados[1]))
                            nodos.Add(new Nodo(dados[1]));

                        var nodoOrigem = nodos.First(x => x.Nome == dados[0]);
                        var nodoDestino = nodos.First(x => x.Nome == dados[1]);
                        int.TryParse(dados[2], out int custo);

                        arestas.Add(new Aresta(nodoOrigem, nodoDestino, custo));
                    }
                }
            }

            return new DadosGrafo(nodos, arestas);
        }
    }
}