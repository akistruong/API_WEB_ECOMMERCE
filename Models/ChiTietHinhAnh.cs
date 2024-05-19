using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

#nullable disable

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class ChiTietHinhAnh
    {
        public string MaSanPham { get; set; }

        public int IDSanPham { get; set; }
        public int IdHinhAnh { get; set; }
        public string IdMaMau { get; set; }
        private IFormFile? file;
        public virtual MauSac MauSacNavigation { get; set; }
        public virtual HinhAnh IdHinhAnhNavigation { get; set; }
        public virtual SanPham MaSanPhamNavigation { get; set; }
        public IFormFile GetFile()
        {
            return this.file;
        }
        public void SetFile(IFormFile file )
        {
            this.file = file;
        }
    }
}
