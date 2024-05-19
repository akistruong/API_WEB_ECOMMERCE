using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Utils.Mail.TemplateHandle
{
    public class RatingStar
    {
        private readonly IHostingEnvironment _HostEnvironment;
        private readonly PhieuNhapXuat _body;

        public RatingStar(IHostingEnvironment hostEnvironment,PhieuNhapXuat body)
        {
            _HostEnvironment = hostEnvironment;
            this._body = body;
        }
        public async Task<string> RenderBody(string link)
        {
            string webRootPath = _HostEnvironment.WebRootPath;
            string contentRootPath = _HostEnvironment.ContentRootPath;
            string path = Path.Combine(webRootPath, "Templates/RatingStar/RatingStar.html");
            string StringData = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                StringData = await reader.ReadToEndAsync();
            }
            StringData = StringData.Replace("{products}", await renderProduct2HTML(_body)) ?? "";
            StringData = StringData.Replace("{link}", link);
            return StringData;
        }
        public async Task<string> renderProduct2HTML(PhieuNhapXuat body)
        {
            var productHTMLs = "";
            string contentRootPath = _HostEnvironment.ContentRootPath;
            string webRootPath = _HostEnvironment.WebRootPath;
            string path = Path.Combine(webRootPath, "Templates/RatingStar/productsBody.html");
            string StringData = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                StringData = await reader.ReadToEndAsync();
            }

            foreach (var product in body.ChiTietNhapXuats)
            {
                String StringTemp = StringData ?? "";

                StringTemp = StringTemp.Replace("{name}", product.SanPhamNavigation.TenSanPham ?? "");
                StringTemp = StringTemp.Replace("{qty}", product.SoLuong.ToString() ?? "0");
                StringTemp = StringTemp.Replace("{shifee}", FormatCurrency.Vnd(body?.Phiship ?? 0));
                StringTemp = StringTemp.Replace("{price}", FormatCurrency.Vnd(product?.DonGia ?? 0));
                StringTemp = StringTemp.Replace("{colorProp}", product?.SanPhamNavigation?.IDColor?.ToString());
                StringTemp = StringTemp.Replace("{size}", product?.SanPhamNavigation?.IDSize?.ToString());
                StringTemp = StringTemp.Replace("{img}", product?.img ?? "");
                productHTMLs += StringTemp;
            }
            return productHTMLs;
        }
    }
}
