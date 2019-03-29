using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KDBProject
{
    public partial class FormKDBProject : Form
    {
        public FormKDBProject()
        {
            InitializeComponent();
        }

         private void btnGonder_Click(object sender, EventArgs e)
        {
            IKDBConfigurationRepository a = new KDBConfigurationRepositoryFromMongo();


            string selectedSignType = cbKDBOSignType.SelectedItem.ToString();
            SignType signType;

            if (selectedSignType == "Bes")
                signType = SignType.Bes;
            else
                signType = SignType.Archival;



            string selectedSaverType = cbKDBOSaverType.SelectedItem.ToString();
            KDBOSaverType saverType;
            if (selectedSaverType == "DB")
                saverType = KDBOSaverType.DB;
            else
                saverType = KDBOSaverType.FTP;



            string selectedArchiveSaver = cbKDBArchiveSaverType.SelectedItem.ToString();
            KDBArchiveSaverType arcSaverType;
            if (selectedArchiveSaver == "DB")
                arcSaverType = KDBArchiveSaverType.DB;
            else
                arcSaverType = KDBArchiveSaverType.FTP;


            List<string> enterSerial = new List<string>();

            foreach (string k in lstSerialNumbers.Items)
                enterSerial.Add(k);




            List<string> enterKdbNoList = new List<string>();

            foreach (string m in lstKdbNoList.Items)
                enterKdbNoList.Add(m);



            List<string> enterVersionList = new List<string>();

            foreach (string n in lstVersionList.Items)
                enterVersionList.Add(n);



            a.Write(int.Parse(txtKDBTimeoutAsSeconds.Text), signType, saverType, arcSaverType, cbSaveKDBO.Checked, enterSerial, enterKdbNoList, enterVersionList, cbKdbArchivation.Checked, txtDefaultVersion.Text);

            MessageBox.Show("Veritabanına Kaydedildi");
        }

        private void btnSerialCikar_Click(object sender, EventArgs e)
        {
            if (lstSerialNumbers.SelectedIndex != -1)
                lstSerialNumbers.Items.Remove(lstSerialNumbers.SelectedItem);
            else
                MessageBox.Show("Çıkarılacak elemanı seçin");
        }

        private void btnSerialEkle_Click(object sender, EventArgs e)
        {
            lstSerialNumbers.Items.Add(txtSerialNumbers.Text);

          
            
        }

        private void btnNoListEkle_Click(object sender, EventArgs e)
        {
            lstKdbNoList.Items.Add(txtKdbNoList.Text);
        }

        private void btnNoListCikar_Click(object sender, EventArgs e)
        {
            if (lstKdbNoList.SelectedIndex != -1)
                lstKdbNoList.Items.Remove(lstKdbNoList.SelectedItem);
            else
                MessageBox.Show("Çıkarılacak elemanı seçin");
        }

        private void btnVersionListEkle_Click(object sender, EventArgs e)
        {
            lstVersionList.Items.Add(txtVersionList.Text);
        }

        private void btnVersionListCikar_Click(object sender, EventArgs e)
        {
            if (lstVersionList.SelectedIndex != -1)
                lstVersionList.Items.Remove(lstVersionList.SelectedItem);
            else
                MessageBox.Show("Çıkarılacak elemanı seçin");
        }
    }
}
