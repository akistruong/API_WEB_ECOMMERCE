using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public class RoleGroup
    {
        public RoleGroup()
        {
            RoleDetails = new HashSet<RoleDetails>();
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public string GroupName { get; set; }
        public string GroupDsc { get; set; }
        public virtual ICollection<RoleDetails> RoleDetails { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }


    }
}
