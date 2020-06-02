using System.Collections.Generic;

namespace GrafosEncomendas.Entidades
{
    public class Percurso
    {
        public List<Nodo> NodosPercurso { get; set; }
        public int Custo { get; set; }

        public Percurso(List<Nodo> nodosPercurso, int custo)
        {
            NodosPercurso = nodosPercurso;
            Custo = custo;
        }
    }
}
