using System;
using System.IO;
using System.Net;
using System.Web;

namespace Web_CMS.Helpers
{
    public class Ftp
    {
        private string ftp;
        private string usuario;
        private string senha;

        public Ftp()
        {
            ftp = "xxxxxx";
            usuario = "xxxxxx";
            senha = "xxxxxx";
        }

        public Boolean DeletarArquivo(string nome, string diretorio)
        {
            try {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + diretorio + nome);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(usuario, senha);
                request.UsePassive = false;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.WriteLine("Delete status: {0}", response.StatusDescription);
                response.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public Boolean UploadArquivo(HttpPostedFileBase file, string nome, string diretorio)
        {
            
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + diretorio + nome);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                request.Credentials = new NetworkCredential(usuario, senha);
                request.UsePassive = false;

                byte[] fileContents = new byte[file.ContentLength];
                file.InputStream.Position = 0;
                file.InputStream.Read(fileContents, 0, file.ContentLength);
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GerarNome(string extensao)
        {
            return DateTime.Now.ToString().Replace(":", "").Replace("/", "").Replace(" ", "") + extensao;
        }
    }
}