using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_DSCS2_WEBBANGIAY.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleDetails = new HashSet<RoleDetails>();
        }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string RoleDsc { get; set; }
        public string Type { get; set; } = "";
        public virtual ICollection<RoleDetails> RoleDetails { get; set; }
    }
}
