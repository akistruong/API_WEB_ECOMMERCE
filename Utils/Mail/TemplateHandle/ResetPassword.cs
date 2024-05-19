using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Utils.Mail.TemplateHandle
{
    public class ResetPassword
    {
        private readonly IHostingEnvironment _HostEnvironment;

        public ResetPassword(IHostingEnvironment hostEnvironment)
        {
            _HostEnvironment = hostEnvironment;
        }

        public async Task<string> RenderBody(string link)
        {
            string webRootPath = _HostEnvironment.WebRootPath;
            string contentRootPath = _HostEnvironment.ContentRootPath;
            string path = Path.Combine(webRootPath, "Templates/ResetPassword/ResetPassword.html");
            string StringData = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                StringData = await reader.ReadToEndAsync();
            }

            StringData = StringData.Replace("{url}", link);
            return StringData;
        }
    }
}
