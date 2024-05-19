using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Utils.Mail.TemplateHandle
{
    public class EmailVerify
    {

        private readonly IHostingEnvironment _HostEnvironment;

        public EmailVerify(IHostingEnvironment hostEnvironment)
        {
            _HostEnvironment = hostEnvironment;
        }

        public async Task<string> RenderBody(string link)
        {
            string webRootPath = _HostEnvironment.WebRootPath;
            string contentRootPath = _HostEnvironment.ContentRootPath;
            string path = Path.Combine(webRootPath, "Templates/EmailVerify/EmailVerify.html");
            string StringData = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                StringData = await reader.ReadToEndAsync();
            }

            StringData = StringData.Replace("{link}", link);
            return StringData;
        }
    }
}
