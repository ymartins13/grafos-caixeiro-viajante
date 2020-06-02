using GrafosEncomendas.Interfaces;
using GrafosEncomendas.Util;
using System;
using System.Linq;
using System.Text;

namespace GrafosEncomendas
{
    class Program
    {
        static void Main(string[] args)
        {
            var trechos = FileUtil.LerLinhasArquivoTxt(@"Dados\trechos.txt");
            var encomendas = FileUtil.LerLinhasArquivoTxt(@"Dados\encomendas.txt");

            var grafo = GrafoUtil.MontarGrafo(trechos);

            var rotas = new StringBuilder();
            foreach (var encomenda in encomendas)
            {
                var valores = encomenda.Split(" ");
                if (valores.Length == 2)
                {
                    var nodoOrigem = grafo.Nodos.FirstOrDefault(x => x.Nome == valores[0]);
                    var nodoDestino = grafo.Nodos.FirstOrDefault(x => x.Nome == valores[1]);

                    IDijkstra dijkstra = new Dijkstra(grafo);

                    dijkstra.ExecutarHeuristica(nodoOrigem);

                    var percurso = dijkstra.ObterRota(nodoDestino);

                    foreach (var nodo in percurso.NodosPercurso)
                    {
                        rotas.Append($"{nodo.Nome} ");
                    }
                    rotas.Append($"{percurso.Custo}");
                    rotas.Append("\n");
                }
            }

            Console.WriteLine(rotas.ToString());

            var caminho = FileUtil.EscreverArquivoTxt(@"Dados\rotas.txt", rotas.ToString());
            Console.WriteLine($"Arquivo de saída salvo em: {caminho}");
        }
    }
}
