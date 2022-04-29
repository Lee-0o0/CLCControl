using CLCControls.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Model
{
    public class Student
    {
        public delegate void ShowGreetingHandler();

        public event ShowGreetingHandler GreetingHander;


        [ColumnStyle(Visible = false)]
        public object Tagptr => this;

        [ColumnStyle(HeaderText = "姓名")]
        public string Name { get; set; }

        [ColumnIgnore]
        public DateTime Birthday { get; set; }

        [ColumnStyle(HeaderText = "出生日期")]
        public string BirthdayString
        {
            get
            {
                return Birthday.ToString("D");
            }
        }

        [ColumnStyle(HeaderText = "性别")]
        public string Gender { get; set; }

        [ColumnStyle(HeaderText = "联系电话")]
        public string Phone { get; set; }
    }
}
