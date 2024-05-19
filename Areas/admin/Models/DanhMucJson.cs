using API_DSCS2_WEBBANGIAY.Models;
using System.Collections.Generic;

namespace API_DSCS2_WEBBANGIAY.Areas.admin.Models
{
    public class Level2
    {
        public Level2()
        {
            Children = new List<DanhMuc> ();
        }
        public DanhMuc info { set; get; }
        public List<DanhMuc> Children { set; get; }
    }
    public class Level1 {
        public Level1()
        {
            Children = new List<Level2> ();
            info = new DanhMuc();
        }
        public DanhMuc info { set; get; }
        public List<Level2> Children { set; get; }
    }
    public class Menu {
        public  Menu()
        {
            Children = new List<Level1> ();
            info = new DanhMuc();
        }
        public DanhMuc info { set; get; }
        public List<Level1> Children { set; get; }
    }


}
