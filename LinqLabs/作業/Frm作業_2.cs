using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            productPhotoTableAdapter1.Fill(awDataSet1.ProductPhoto);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            var q = from n in awDataSet1.ProductPhoto
                  select n;
            dataGridView1.DataSource = q.ToList();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from n in awDataSet1.ProductPhoto
                    where n.ModifiedDate >= dateTimePicker1.Value && n.ModifiedDate <= dateTimePicker2.Value 
                    select n;
            dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var q = from n in awDataSet1.ProductPhoto
                    where n.ModifiedDate.Year == Convert.ToInt32(comboBox3.SelectedItem)
                    orderby n.ModifiedDate
                    select n;

            dataGridView1.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string seaSon = comboBox2.Text;
            if (seaSon == "第一季")
            {
                var q = from n in awDataSet1.ProductPhoto
                        where n.ModifiedDate.Month < 4
                        orderby n.ModifiedDate
                        select n;

                dataGridView1.DataSource = q.ToList();
            }

            else if (seaSon == "第二季")
            {
                var q = from n in awDataSet1.ProductPhoto
                        where n.ModifiedDate.Month > 3 && n.ModifiedDate.Month < 7
                        orderby n.ModifiedDate
                        select n;

                dataGridView1.DataSource = q.ToList();
            }

            else if (seaSon == "第三季")
            {
                var q = from n in awDataSet1.ProductPhoto
                        where n.ModifiedDate.Month > 6 && n.ModifiedDate.Month < 10
                        orderby n.ModifiedDate
                        select n;

                dataGridView1.DataSource = q.ToList();
            }

            else //(seaSon == "第四季")
            {
                var q = from n in awDataSet1.ProductPhoto
                        where n.ModifiedDate.Month > 9 && n.ModifiedDate.Month < 13
                        orderby n.ModifiedDate
                        select n;

                dataGridView1.DataSource = q.ToList();
            }
        }
    }
}
