using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Dominio;
using Aplicacao;
using System.Text;

namespace Web_CMS.Helpers
{
    public class Email
    {
        string smtp;
        int smtp_porta;
        string email;
        string senha;
        string nome;
        List<String> destinarios;

        public Email()
        {
            smtp = "XXXXX";
            smtp_porta = 587;
            email = "XXXXX";
            senha = "XXXXX";
            nome = "XXXXX";
            destinarios = new List<string>();
            destinarios.Add("XXXXX");
        }


        /*public void ContatoSite(Contato contato)
        {
            var assunto ="-== Contato Site MAURICIO PUPO ==-";
            StringBuilder corpo = new StringBuilder();
            corpo.AppendLine("\nContato via site MAURICIO PUPO!\n\n");
            corpo.AppendLine("\nNome: " + contato.Nome);
            corpo.AppendLine("\nEmail: " + contato.Email);
            corpo.AppendLine("\nAssunto: " + contato.Assunto);
            corpo.AppendLine("\nMensagem: " + contato.Mensagem);
            enviar(corpo.ToString(), assunto);
        }*/



        private void enviar(String corpo, String assunto)
        {

            SmtpClient cliente = new SmtpClient(smtp, smtp_porta)
            {
                Credentials = new NetworkCredential(email,senha )
            };
            MailAddress remetente = new MailAddress(email);
            MailAddress destinatario = new MailAddress(destinarios.First(), nome);
            MailMessage mensagem = new MailMessage(remetente, destinatario);
            foreach (var desti in destinarios)
            {
                mensagem.To.Add(new MailAddress(desti));
            }
            
            mensagem.Body = corpo;
            mensagem.Subject = assunto;

            cliente.Send(mensagem);
        }
    }
}