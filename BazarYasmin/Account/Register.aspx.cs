using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using BazarYasmin.Models;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace BazarYasmin.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                string code = manager.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");
                 
                 //Configuración del Mensaje
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                    mail.From = new MailAddress("bazaryasmin.1@gmail.com", "BazarYasmin", Encoding.UTF8);
                    //Aquí ponemos el asunto del correo
                    mail.Subject = "Confirmar cuenta BazarYasmin";
                    //Aquí ponemos el mensaje que incluirá el correo
                    mail.Body = "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.";
                    //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                    mail.To.Add(Email.Text);
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));
                
                mail.IsBodyHtml = true;
                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                                           //Especificamos las credenciales con las que enviaremos el mail
                    SmtpServer.Credentials = new System.Net.NetworkCredential("bazaryasmin.1@gmail.com", "guason6423");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                 
                 signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                 IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}
