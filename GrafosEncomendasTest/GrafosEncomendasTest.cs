using GrafosEncomendas;
using GrafosEncomendas.Entidades;
using GrafosEncomendas.Interfaces;
using GrafosEncomendas.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GrafosEncomendasTest
{
    [TestClass]
    public class GrafoUtilTest
    {
        readonly string[] trechosTestOk = new string[] { "SF LS 2", "LS LV 1", "LV LS 1", "SF LV 2", "LV SF 2", "LS RC 1", "RC LS 2", "SF WS 1", "WS SF 2", "LV BC 1", "BC LV 1" };
        readonly string[] trechosTestProblema = new string[] { "SF LS 2", "LS LV 1", "LV LS 1", "SF LV 2", "LV SF 2", "LS RC 1", "RC LS 2", "SF WS 1", "WS SF 2", "LV BC 1", "BC LV" };
        readonly string[] trechosTestVazio = new string[] { };

        #region GrafoUtil

        [TestMethod]
        public void GerarGrafico_Lista_Sucesso()
        {
            var result = GrafoUtil.MontarGrafo(trechosTestOk);
            Assert.AreEqual(6, result.Nodos.Count);
            Assert.AreEqual(11, result.Arestas.Count);
        }

        [TestMethod]
        public void GerarGrafico_ListaFaltandoDado_Sucesso()
        {
            var result = GrafoUtil.MontarGrafo(trechosTestProblema);
            Assert.AreEqual(6, result.Nodos.Count);
            Assert.AreEqual(10, result.Arestas.Count);
        }

        [TestMethod]
        public void GerarGrafico_ListaVazia_Sucesso()
        {
            var result = GrafoUtil.MontarGrafo(trechosTestVazio);
            Assert.AreEqual(0, result.Nodos.Count);
            Assert.AreEqual(0, result.Arestas.Count);
        }

        #endregion

        #region Dijkstra

        [TestMethod]
        public void ProcessarGrafo_Sucesso()
        {
            var grafo = GrafoUtil.MontarGrafo(trechosTestOk);

            var nodoOrigem = grafo.Nodos.FirstOrDefault(x => x.Nome == "LS");
            var nodoDestino = grafo.Nodos.FirstOrDefault(x => x.Nome == "BC");

            IDijkstra dijkstra = new Dijkstra(grafo);
            dijkstra.ExecutarHeuristica(nodoOrigem);
            var result = dijkstra.ObterRota(nodoDestino);

            Assert.AreEqual(3, result.NodosPercurso.Count);
            Assert.AreEqual(2, result.Custo);
        }

        #endregion
    }
}
