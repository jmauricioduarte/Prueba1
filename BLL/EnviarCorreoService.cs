using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using DAL;
using Entity;

namespace BLL
{
    public class EnviarCorreoService
    {

        public MailMessage DatosCorreo(Persona persona)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(persona.Correo.ToString()));
            email.From = new MailAddress("hoteltierralinda01@gmail.com");
            email.Subject = "Jose Mauricio Duarte Gelvez";
            email.Body = persona.Nombre +" su Pulsacion es de "+ persona.Pulsaciones;
            email.Attachments.Add(new Attachment(@"C:\Users\Mauricio ge\source\repos\Pulsaciones\PulsacionesGUI\bin\Debug\informe.pdf")); 
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            return email;
        }

        public SmtpClient ConfigurarCorreoGmail()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587; //456
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("hoteltierralinda01@gmail.com", "hoteltierralinda123456");

            return smtp;
        }


        public string EnviarCorreo(Persona persona)
        {
            try
            {
                MailMessage email = DatosCorreo(persona);
                SmtpClient smtp = ConfigurarCorreoGmail();
                smtp.Send(email);
                email.Dispose();
                return "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                return "Error enviando correo electrónico: " + ex.Message;
            }
        }
    }
}

