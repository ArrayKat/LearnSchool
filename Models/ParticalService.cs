using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LernSchool.Models
{
    public partial class Service
    {
        string PathImage => "/Assets/Услуги_школы/" + MainImagePath;
        public bool isVisibleMainCost => Discount == null ? false : true;
        public double CostResult => Discount==null ? Cost : (double)(Cost - (Cost * Discount));
        public int DurationInMinutes => DurationInSeconds / 60;

        public int DiscountInt => (int)(Discount !=null ? Discount * 100 : 0);

    }
}
