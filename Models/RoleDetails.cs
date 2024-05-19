namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class RoleDetails
    {

        public string RoleGroup { get; set; }
        public string RoleCode { get; set; }
        public string Type { get; set; } = "";
        public bool isActive { get; set; } = false;
        public virtual RoleGroup RoleGroupNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
