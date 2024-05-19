using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_DSCS2_WEBBANGIAY.Utils.Mail.TemplateHandle
{
    public  class Confirm
    {
        private  readonly IHostingEnvironment _HostEnvironment;
        private readonly PhieuNhapXuat body;

        public Confirm(IHostingEnvironment hostEnvironment, PhieuNhapXuat phieuNhapXuat)
        {
            this.body = phieuNhapXuat;
            this._HostEnvironment = hostEnvironment;    
        }


        public async  Task<string> RenderBody( )
        {
            string webRootPath = _HostEnvironment.WebRootPath;
            string contentRootPath = _HostEnvironment.ContentRootPath;
            string path = Path.Combine(webRootPath, "Templates/Confirm1/Confirm1.html");
            string StringData = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                StringData = await reader.ReadToEndAsync();
            }
            StringData = StringData.Replace("{products}",await renderProduct2HTML())??"";
            StringData = StringData.Replace("{orderID}", body?.Id.ToString()??"");
            StringData = StringData.Replace("{shipfee}", FormatCurrency.Vnd(body?.Phiship??0));
            StringData = StringData.Replace("{discount}", FormatCurrency.Vnd(body?.TienDaGiam??0));
            StringData = StringData.Replace("{AddressDsc}", body?.DiaChiNavigation?.AddressDsc??"");
            StringData = StringData.Replace("{WardName}", body?.DiaChiNavigation?.WardName??"");
            StringData = StringData.Replace("{DistrictName}", body?.DiaChiNavigation?.DistrictName??"");
            StringData = StringData.Replace("{ProvinceName}", body?.DiaChiNavigation?.ProvinceName??"");
            StringData = StringData.Replace("{createdAT}", body?.createdAt.ToShortDateString()?? DateTime.Now.ToShortDateString());
            StringData = StringData.Replace("{totalPrice}", FormatCurrency.Vnd(body?.ThanhTien??0));
            StringData = StringData.Replace("{totalProducts}", FormatCurrency.Vnd(body.ChiTietNhapXuats.Sum(x=>x?.DonGia??0)) ?? "0");
            StringData = StringData.Replace("{GuessName}", body?.DiaChiNavigation?.Name??"");
            StringData = StringData.Replace("{Phone}", body?.DiaChiNavigation?.Phone??"");
            StringData = StringData.Replace("{PaymentMethod}", body?.PhuongThucThanhToan??"");
            return StringData;
        }
        public async Task<string> renderProduct2HTML()
        {
            var productHTMLs = "";
            string contentRootPath = _HostEnvironment.ContentRootPath;
            string webRootPath = _HostEnvironment.WebRootPath;
            string path = Path.Combine(webRootPath, "Templates/Confirm1/productsBody.html");
            string StringData = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                StringData =await reader.ReadToEndAsync();
            }

            foreach (var product in body.ChiTietNhapXuats)
            {
                String StringTemp = StringData ?? "";

                StringTemp = StringTemp.Replace("{name}", product.SanPhamNavigation.TenSanPham??"");
                StringTemp = StringTemp.Replace("{qty}", product.SoLuong.ToString()??"0");
                StringTemp = StringTemp.Replace("{shifee}", FormatCurrency.Vnd(body?.Phiship ?? 0));
                StringTemp = StringTemp.Replace("{price}",FormatCurrency.Vnd(product?.DonGia??0));
                StringTemp = StringTemp.Replace("{colorProp}", product?.SanPhamNavigation?.IDColor?.ToString());
                StringTemp = StringTemp.Replace("{size}",product?.SanPhamNavigation?.IDSize?.ToString());
                StringTemp = StringTemp.Replace("{img}", product?.img??"");
                productHTMLs += StringTemp;
            }
            return productHTMLs;
        }
    }
}
