using CLCControls.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Model
{
    public class Phone
    {
        [ColumnStyle(Visible = false)]
        public object Tagptr => this;

        [ColumnStyle(HeaderText = "品牌")]
        public string Brand { get; set; }

        [ColumnStyle(HeaderText = "型号")]
        public string PhoneModel { get; set; }

        [ColumnStyle(HeaderText = "价格")]
        public decimal Price { get; set; }
    }
}
