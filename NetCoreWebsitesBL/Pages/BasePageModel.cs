using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using NetCoreWebsitesBL.Common;

namespace NetCoreWebsitesBL.Pages
{
    public class BasePageModel : PageModel
    {
        public string? PageName { get; set; }
        public List<string> IdsLlamados = new List<string>();
        public List<string> IdsRepetidos = new List<string>();

        public void Initialize(string sPageName)
        {
            PageName = sPageName;

            if (HttpContext != null)
            {
                string PageUrl = HttpContext.Request.Host + HttpContext.Request.Path;
                // Aquí puedes añadir lógica para inicializar PageTitle y MetaDescription basada en tu lógica de negocio.
            }
        }

        public void SetUserSession(string username, string email)
        {
            HttpContext.Session.SetString("Username", username);
            HttpContext.Session.SetString("Email", email);
        }

        public void ClearUserSession()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Email");
        }

        public bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("Username"));
        }

        public IHtmlContent C(string Id, string DefaultValue)
        {
            bool YaExiste = IdsLlamados.Any(p => p == Id);
            if (YaExiste)
                IdsRepetidos.Add(Id);
            else
                IdsLlamados.Add(Id);

            // Simulación de obtener contenido de base de datos
            string contentValue = DefaultValue;

            if (!string.IsNullOrEmpty(contentValue))
            {
                return GetHtml(contentValue);
            }
            else
            {
                return GetHtml(DefaultValue);
            }
        }

        public static string GetString(IHtmlContent content)
        {
            using (var writer = new System.IO.StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        public static IHtmlContent GetHtml(string content)
        {
            HtmlContentBuilder result = new HtmlContentBuilder();
            result.AppendHtml(content);
            return result;
        }

        public static HtmlString GetHtmlComponent(string content)
        {
            return new HtmlString(content);
        }

        public void ProcessCookie(string EncryptedCookie, string PageUrl)
        {
            if (!string.IsNullOrEmpty(EncryptedCookie))
            {
                // Desencriptar los datos
                string DecryptedData = EncryptHelper.DecryptAes(EncryptedCookie);
                // Separar los datos desencriptados (programId y email)
                string[] Parts = DecryptedData.Split('|');
                int ProgramId = int.Parse(Parts[0]);
                string Email = Parts[1];
                // Llamar API (simulado)
                // CrmLeadsVisits.AddCrmLeadsVisits(Email, ProgramId, PageUrl);
            }
        }
    }
}
