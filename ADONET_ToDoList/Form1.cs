using AdoNetHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET_ToDoList
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        private string BaglantiCumlesi = "Server=TRAINER; Database=TodoListDB_AdoNet; User Id=sa; Password=wissen";

        private void GetData()
        {
            lstGorevler.Items.Clear();

            Database db = new Database(BaglantiCumlesi);
            DataTable sonuc_tablo = db.GetTable("SELECT * FROM Gorevler", null);

            foreach (DataRow row in sonuc_tablo.Rows)
            {
                Gorev gorev = new Gorev();

                gorev.Id = (int)row["Id"];
                gorev.Konu = row["Konu"].ToString();
                gorev.Durum = (bool)row["Durum"];
                gorev.OlusturmaTarihi = (DateTime)row["OlusturmaTarihi"];

                if (row["GuncellemeTarihi"] == DBNull.Value)
                {
                    gorev.GuncellemeTarihi = null;
                }
                else
                {
                    gorev.GuncellemeTarihi = (DateTime?)row["GuncellemeTarihi"];
                }


                lstGorevler.Items.Add(gorev);
            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Database db = new Database(BaglantiCumlesi);

            string q = "INSERT INTO Gorevler (Konu, Durum, OlusturmaTarihi, GuncellemeTarihi) VALUES (@Konu, @Durum, @OlusturmaTarihi, @GuncellemeTarihi)";

            db.RunQuery(q, new SqlParameter("@Konu", txtGorev.Text), new SqlParameter("@Durum", rdbYapildi.Checked), new SqlParameter("@OlusturmaTarihi", DateTime.Now), new SqlParameter("@GuncellemeTarihi", DBNull.Value));
            GetData();
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            //GetData();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (lstGorevler.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen bir görev seçiniz.");
                return;
            }

            SqlConnection con = new SqlConnection(BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Gorevler SET Konu=@Konu, Durum=@Durum, OlusturmaTarihi=@OlusturmaTarihi, GuncellemeTarihi=@GuncellemeTarihi WHERE Id=@Id";

            Gorev seciligorev = lstGorevler.SelectedItem as Gorev;
            cmd.Parameters.AddWithValue("@Id", seciligorev.Id);

            cmd.Parameters.AddWithValue("@Konu", txtGorev.Text);
            cmd.Parameters.AddWithValue("@Durum", rdbYapildi.Checked);
            cmd.Parameters.AddWithValue("@OlusturmaTarihi", seciligorev.OlusturmaTarihi);
            cmd.Parameters.AddWithValue("@GuncellemeTarihi", DateTime.Now);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            GetData();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lstGorevler.SelectedIndex > -1)
            {
                SqlConnection con = new SqlConnection(BaglantiCumlesi);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Gorevler WHERE Id=@Id";

                Gorev seciligorev = (Gorev)lstGorevler.SelectedItem;
                cmd.Parameters.AddWithValue("@Id", seciligorev.Id);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                GetData();

            }
            else
            {
                MessageBox.Show("Lütfen bir görev seçiniz.");
            }
        }

        private void lstGorevler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGorevler.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen bir görev seçiniz.");
                return;
            }

            Gorev seciligorev = lstGorevler.SelectedItem as Gorev;
            txtGorev.Text = seciligorev.Konu;
            rdbYapildi.Checked = seciligorev.Durum;
            rdbYapilacak.Checked = !seciligorev.Durum;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database db = new Database("Server=TRAINER; Database=MusicBoxDB; User Id=sa; Password=wissen");

            DataTable dt = db.RunProc("SelectAllRowsTurler", null);

        }
    }
}
