using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();

            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }

        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            //this.nwDataSet1.Products.

            //Distinct()
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();

            this.dataGridView1.DataSource = files;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

        		
            // 數學不及格 ... 是誰 
            #endregion

        }

        private void button37_Click(object sender, EventArgs e)
        {
            //new {.....  Min=33, Max=34.}
            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |		

            //個人 所有科的  sum, min, max, avg


        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            this.dataGridView1.DataSource = files;

            var q = from w in files
                    where w.CreationTime.Year == 2019
                    select w;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            this.dataGridView1.DataSource = files;

            var q = from w in files
                    where w.Length >= 1000000
                    select w;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            this.dataGridView1.DataSource = this.nwDataSet1.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q1 = from o in nwDataSet1.Orders
                     where o.OrderDate.Year == Convert.ToInt32(comboBox1.SelectedItem)
                     select new
                     {
                         o.OrderID,
                         //o.CustermerID,
                         o.EmployeeID,
                         o.OrderDate,
                         //o.RequireDate,
                         //f.ShippedDate,
                         //o.ShipVisa,
                         o.Freight,
                         o.ShipName,
                         o.ShipAddress,
                         o.ShipCity,
                         //f.ShipRegion,
                         //f.ShipPostalCode,
                         o.ShipCountry,
                     };
            this.dataGridView1.DataSource = q1.ToList();
            //====================================================================

            var q2 = from od in nwDataSet1.Order_Details
                     join o in nwDataSet1.Orders
                     on od.OrderID equals o.OrderID
                     where o.OrderDate.Year == Convert.ToInt32(comboBox1.SelectedItem)
                     select od;


            this.dataGridView1.DataSource = q2.ToList();

            //土法煉鋼法
            //this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);


            //if (comboBox1.Text == "1996") 
            //{
            //    var q = from w in nwDataSet1.Orders
            //            where w.OrderDate.Year == 1996
            //            select w;

            //    this.dataGridView1.DataSource = q.ToList();

            //    this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);

            //    var b = from w in nwDataSet1.Order_Details
            //            where w.OrdersRow.OrderDate.Year == 1996
            //            select w;

            //    this.dataGridView2.DataSource = b.ToList();


            //}

            //else if (comboBox1.Text == "1997")
            //{
            //    var q = from w in nwDataSet1.Orders
            //            where w.OrderDate.Year == 1997
            //            select w;

            //    this.dataGridView1.DataSource = q.ToList();

            //    this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);

            //    var b = from w in nwDataSet1.Order_Details
            //            where w.OrdersRow.OrderDate.Year == 1997
            //            select w;

            //    this.dataGridView2.DataSource = b.ToList();
            //}

            //else if (comboBox1.Text == "1998")
            //{
            //    var q = from w in nwDataSet1.Orders
            //            where w.OrderDate.Year == 1998
            //            select w;

            //    this.dataGridView1.DataSource = q.ToList();

            //    this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);

            //    var b = from w in nwDataSet1.Order_Details
            //            where w.OrdersRow.OrderDate.Year == 1998
            //            select w;

            //    this.dataGridView2.DataSource = b.ToList();
            //}


        }
    }
}
