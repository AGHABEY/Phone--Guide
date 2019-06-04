using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phone.BLL;
namespace Phone.UIF
{
    public partial class Form1 : Form
    {
        BusinessLogicLayer BLL;
        public Form1()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int result = BLL.userControl(textBox1.Text, textBox2.Text);
            if (result>0)
            {
                AnaSehife frm = new AnaSehife();
                frm.Show();
            }
            else if (result==-100)
            {
                MessageBox.Show("Melumatlari eksik daxil etmisiniz");
            }
            else
            {
                MessageBox.Show("cehd ugursuz oldu");
            }
        }
    }
}
