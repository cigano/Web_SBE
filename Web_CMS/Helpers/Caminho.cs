
namespace Web_CMS.Helpers
{
    public class Caminho
    {
        private static string bannerRotativo = "arquivos/BannerRotativo/";
        private static string corpoDocente = "arquivos/CorpoDocente/";
        private static string parceiro = "arquivos/Parceiro/";
        private static string curso = "arquivos/Curso/";
        private static string videoCurso = "arquivos/VideoCurso/";
        private static string livro = "arquivos/Livro/";
        
        public static string BannerRotativo()
        {
            return bannerRotativo;
        }

        public static string CorpoDocente()
        {
            return corpoDocente;
        }

        public static string Parceiro()
        {
            return parceiro;
        }

        public static string Curso()
        {
            return curso;
        }

        public static string VideoCurso()
        {
            return videoCurso;
        }

        public static string Livro()
        {
            return livro;
        }
    }
}