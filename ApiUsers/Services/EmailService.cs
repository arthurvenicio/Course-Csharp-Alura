using System;
using ApiUsers.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ApiUsers.Services
{
    public class EmailService
    {

        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void sendEmail(string[] emails, string linkDeAtivação, int userId, string code)
        {
            Message message = new Message(emails, linkDeAtivação, userId, code);
            var emailMessage = generateEmailBody(message);
            Send(emailMessage);
        }

        private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailService:SmtpServer"), 
                        _configuration.GetValue<int>("EmailService:Port"), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailService:From"), 
                        _configuration.GetValue<string>("EmailService:Password"));
                    client.Send(emailMessage);
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage generateEmailBody(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailService:Name"), 
                _configuration.GetValue<string>("EmailService:From")));
            emailMessage.To.AddRange(message.Destination);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) {Text = this.PegarTemplate(message.Content)};

            return emailMessage;
        }
        
        public string PegarTemplate(String mensagem)
        {
            string template = string.Empty;
            template =
                $"<!DOCTYPE html>" +
                "<html>" +
                "<head>" +
                "</head>" +
                "<body style = " + "background-color: #f8f788" + ">" +
                "<h2><b> Contato</b></h2>" +
                "<p> Olá usuário</p>" +
                "<p> Segue abaixo o link para verificação da conta!. </p>" +
                $"<p>{mensagem}</p>" +
                $"</body>" +
                "</html> ";

            return template;
        }
    }
}
