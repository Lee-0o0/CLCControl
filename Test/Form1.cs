using CLCControl.Forms;
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CLCMessageBox.ShowMessageBox("MessaOf course I could count the number of NewLines and add: Newlines * LineHeight, and then -given that I manage to put 60 chars per line, just divide the number of c提供在使用指定大小创建文本初始边框时\r\n，使用指定的字体和格式说明绘制的指定文本的大小（以像素为单位）。\nhars and add as many LineHeight pixels as needed.ge Type Message Type Message Type Message Type Message Type Message Type Message Type Message Type Message Type Message Type Message Type Message Type Message Type Message Type ", CLCMessageBox.MessageType.SUCCESS);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CLCMessageBox.ShowMessageBox("info", CLCMessageBox.MessageType.INFO,CLCMessageBox.MessageBoxPosition.PARENT_RIGHT_BOTTOM,this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CLCMessageBox.ShowMessageBox("warn", CLCMessageBox.MessageType.WARN, CLCMessageBox.MessageBoxPosition.PARENT_CENTER,this);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CLCMessageBox.ShowMessageBox("error", CLCMessageBox.MessageType.ERROR,CLCMessageBox.MessageBoxPosition.PARENT_LEFT_TOP,this);
        }
    }
}
