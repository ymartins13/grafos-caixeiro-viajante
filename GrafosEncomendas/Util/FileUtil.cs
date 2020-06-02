using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GrafosEncomendas.Util
{
    public static class FileUtil
    {
        public static string ReadFileTxt(string arquivo)
        {
            if (File.Exists(arquivo) && Path.HasExtension(".txt"))
            {
                return File.ReadAllText(arquivo);
            }

            return null;
        }
        public static string[] ReadLinesFileTxt(string arquivo)
        {
            if (File.Exists(arquivo) && Path.HasExtension(".txt"))
            {   
                return File.ReadAllLines(arquivo);
            }

            return null;
        }

        public static string WriteFileTxt(string caminho, string conteudo)
        {
            File.WriteAllText(caminho, conteudo, Encoding.UTF8);

            return Path.GetFullPath(caminho);
        }
    }
}
