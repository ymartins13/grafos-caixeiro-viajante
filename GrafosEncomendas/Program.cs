using GrafosEncomendas.Entidades;
using GrafosEncomendas.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrafosEncomendas
{
    class Program
    {
        static void Main()
        {
            var trechos = FileUtil.ReadLinesFileTxt("trechos.txt");
            var encomendas = FileUtil.ReadLinesFileTxt("encomendas.txt");

            var grafo = GrafoUtil.MontarGrafo(trechos);

            var rotas = new StringBuilder();
            foreach (var encomenda in encomendas)
            {
                var valores = encomenda.Split(" ");
                if (valores.Length == 2)
                {
                    var nodoOrigem = grafo.Nodos.FirstOrDefault(x => x.Nome == valores[0]);
                    var nodoDestino = grafo.Nodos.FirstOrDefault(x => x.Nome == valores[1]);

                    Dijkstra dijkstra = new Dijkstra(grafo);

                    dijkstra.ExecutarHeuristica(nodoOrigem);

                    List<Nodo> percurso = dijkstra.ObterRota(nodoDestino);

                    int distanciaPercurso = dijkstra.ObterDistanciaTrajeto();

                    for (int i = 0; i < percurso.Count; i++)
                    {
                        rotas.Append($"{percurso[i].Nome} ");
                    }
                    rotas.Append($"{distanciaPercurso}");
                    rotas.Append("\n");
                }
            }

            Console.WriteLine(rotas.ToString());

            var caminho = FileUtil.WriteFileTxt("rotas.txt", rotas.ToString());
            Console.WriteLine($"Arquivo gerado com sucesso!! {caminho}");
            Console.ReadKey();
        }
    }
}
