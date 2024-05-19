namespace API_DSCS2_WEBBANGIAY.Areas.admin.Models
{
    public class ResetPasswordParams
    {
        public string newPassword { get; set; }
        public string oldPassword { get; set; }
        public string Token { get; set; }
        public string tenTaiKhoan { get; set; }
    }
}
