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
using Phone.Entities;

namespace Phone.UIF
{
    public partial class AnaSehife : Form
    {
        BusinessLogicLayer Bll;
        public AnaSehife()
        {
            InitializeComponent();
            Bll = new BusinessLogicLayer();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int Result=Bll.newRecord(Guid.NewGuid(),Ad_txt.Text,soyad_txt.Text,telefon1_text.Text,telefon2_txt.Text,telefon3_txt.Text,adress_txt.Text,email_txt.Text,aciqlama_txt.Text);
            if (Result>0)
            {
                MessageBox.Show("Muveffeqiyyetle elave olundu");
                Fill();
            }
            else if (Result==-100)
            {
                MessageBox.Show("Eksik parametr");
            }
            else
            {
                MessageBox.Show("Elave etme emeliyyatinda xeta yarandi");
            }
        }

        private void Fill()
        {
            List<GuideRecord> guideRecords = Bll.GetGuideRecords();
            if (guideRecords!=null && guideRecords.Count>0)
            {
                listBox1.DataSource = guideRecords;
            }
        }

        private void AnaSehife_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            ListBox L= (ListBox)sender;
            GuideRecord selectedValue = (GuideRecord)L.SelectedItem;
            Ad_txt.Text = selectedValue._name;
            soyad_txt.Text = selectedValue._surname;
            telefon1_text.Text = selectedValue._phoneNumber1;
            telefon2_txt.Text = selectedValue._phoneNumber2;
            telefon3_txt.Text = selectedValue._phoneNumber3;
            adress_txt.Text = selectedValue._adress;
            email_txt.Text = selectedValue._emailAdress;
            aciqlama_txt.Text = selectedValue._text;
            groupBox2.Text = "Guide record update";

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!=null)
            {
                GuideRecord g = (GuideRecord)listBox1.SelectedItem;
                int result = Bll.updateRecord(g._ID, Ad_txt.Text, soyad_txt.Text, telefon1_text.Text, telefon2_txt.Text, telefon3_txt.Text, adress_txt.Text, email_txt.Text, aciqlama_txt.Text);

                if (result>0)
                {
                    MessageBox.Show("Qeyd yenilendi");
                    Fill();
                }
                else if (result==-100)
                {
                    MessageBox.Show("Eksik parametr xetasi");
                }
                else
                {
                    MessageBox.Show("Xeta bas verdi");
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Guid DeletedId = ((GuideRecord)listBox1.SelectedItem)._ID;
            int result = Bll.deleteRecord(DeletedId);
            if (result>0)
            {
                MessageBox.Show("Silindi");
                Fill();
            }
            else
            {
                MessageBox.Show("Her hansi 1 xeta yarandi");
            }
        }
    }
}
