using CLCControls.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Test.Model;

namespace Test
{
    public partial class Form1 : Form
    {
        Student[] students = new Student[]
        {
            new Student(){Name="张三", Gender = "男", Birthday = DateTime.Now, Phone = "18999002211"},
            new Student(){Name="李四", Gender = "男", Birthday = DateTime.Now, Phone = "28999002212"},
            new Student(){Name="王五", Gender = "女", Birthday = DateTime.Now, Phone = "38999002213"},
            new Student(){Name="赵六", Gender = "男", Birthday = DateTime.Now, Phone = "48999002214"},
            new Student(){Name="钱七", Gender = "女", Birthday = DateTime.Now, Phone = "58999002215"},
        };

        List<Student> list = new List<Student>()
        {
            new Student(){Name="张三", Gender = "男", Birthday = DateTime.Now, Phone = "18999002211"},
            new Student(){Name="李四", Gender = "男", Birthday = DateTime.Now, Phone = "28999002212"},
            new Student(){Name="王五", Gender = "女", Birthday = DateTime.Now, Phone = "38999002213"},
            new Student(){Name="赵六", Gender = "男", Birthday = DateTime.Now, Phone = "48999002214"},
            new Student(){Name="钱七", Gender = "女", Birthday = DateTime.Now, Phone = "58999002215"},
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clcComboBox1.CLCDataSource = list;
            clcComboBox1.CLCDisplayMember = "Name";

            clcComboBox2.CLCDataSource = students;
            clcComboBox2.CLCDisplayMember = "Name";

            clcComboBox3.CLCDataSource = students;
            clcComboBox3.CLCDisplayMember = "Name";

            clcComboBox4.QueryEvent += QueryStudents;
            clcComboBox4.CLCDisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clcComboBox3.CategoryName = "Name";
            Student s = (Student)clcComboBox3.SelectedItem;
            MessageBox.Show(s.Name + "-" + s.BirthdayString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<object> items = clcComboBox1.GetSelectedItem();
            string text = "";
            foreach(var i in items)
            {
                text += ((Student)i).Name + "\n";
            }
            MessageBox.Show(text);
        }


        private QueryResult QueryStudents(Dictionary<string,object> parameters)
        {
            QueryResult queryResult = new QueryResult();
            queryResult.Result = true;
            queryResult.PageSize = 10;
            queryResult.PageNum = (int)parameters["page"];
            queryResult.TotalSize = 100;
            queryResult.Data = new List<Student>()
            {
                new Student(){Name="张三", Gender = "男", Birthday = DateTime.Now, Phone = "18999002211"},
                new Student(){Name="李四", Gender = "男", Birthday = DateTime.Now, Phone = "28999002212"},
                new Student(){Name="王五", Gender = "女", Birthday = DateTime.Now, Phone = "38999002213"},
                new Student(){Name="赵六", Gender = "男", Birthday = DateTime.Now, Phone = "48999002214"},
                new Student(){Name="钱七", Gender = "女", Birthday = DateTime.Now, Phone = "58999002215"},
                new Student(){Name="钱七", Gender = "女", Birthday = DateTime.Now, Phone = "58999002215"},
                new Student(){Name="钱七", Gender = "女", Birthday = DateTime.Now, Phone = "58999002215"},
                new Student(){Name="钱七", Gender = "女", Birthday = DateTime.Now, Phone = "58999002215"},
            };
            queryResult.ElementType = typeof(Student);
            return queryResult;
        }

        private QueryResult QueryPhones(Dictionary<string, object> parameters)
        {
            QueryResult queryResult = new QueryResult();
            queryResult.Result = true;
            queryResult.PageSize = 10;
            queryResult.PageNum = 1;
            queryResult.TotalSize = 100;
            queryResult.Data = new List<Phone>()
            {
                new Phone(){Brand="华为",PhoneModel="Mate 30",Price=5000},
                new Phone(){Brand="苹果",PhoneModel="Mate 30",Price=5000},
                new Phone(){Brand="小米",PhoneModel="Mate 30",Price=5000},
                new Phone(){Brand="三星",PhoneModel="Mate 30",Price=5000},
            };
            queryResult.ElementType = typeof(Phone);
            return queryResult;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clcComboBox4.QueryEvent -= QueryStudents;
            clcComboBox4.QueryEvent += QueryPhones;
            clcComboBox4.CLCDisplayMember = "Brand";
        }
    }
}
