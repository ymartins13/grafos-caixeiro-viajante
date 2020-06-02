using System.IO;
using System.Text;

namespace GrafosEncomendas.Util
{
    public static class FileUtil
    {
        public static string ReadFileTxt(string arquivo)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, arquivo);
            if (File.Exists(path) && Path.HasExtension(".txt"))
            {
                return File.ReadAllText(path);
            }

            return null;
        }
        public static string[] ReadLinesFileTxt(string arquivo)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, arquivo);

            if (File.Exists(path) && Path.HasExtension(".txt"))
            {
                return File.ReadAllLines(path);
            }

            return null;
        }

        public static string WriteFileTxt(string caminho, string conteudo)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, caminho);

            File.WriteAllText(path, conteudo, Encoding.UTF8);

            return Path.GetFullPath(path);
        }
    }
}
