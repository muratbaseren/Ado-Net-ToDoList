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

        private string BaglantiCumlesi = "Server=[ServerName]; Database=[DbName]; User Id=[username]; Password=[password]";

        private void GetData()
        {
            lstGorevler.Items.Clear();

            SqlConnection con = new SqlConnection(BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Gorevler";

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Gorev gorev = new Gorev();

                gorev.Id = (int)reader["Id"];
                gorev.Konu = reader["Konu"].ToString();
                gorev.Durum = (bool)reader["Durum"];
                gorev.OlusturmaTarihi = (DateTime)reader["OlusturmaTarihi"];

                if (reader["GuncellemeTarihi"] == DBNull.Value)
                {
                    gorev.GuncellemeTarihi = null;
                }
                else
                {
                    gorev.GuncellemeTarihi = (DateTime?)reader["GuncellemeTarihi"];
                }


                lstGorevler.Items.Add(gorev);
            }

            con.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglantiCumlesi);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Gorevler (Konu, Durum, OlusturmaTarihi, GuncellemeTarihi) VALUES (@Konu, @Durum, @OlusturmaTarihi, @GuncellemeTarihi)";

            cmd.Parameters.AddWithValue("@Konu", txtGorev.Text);
            cmd.Parameters.AddWithValue("@Durum", rdbYapildi.Checked);
            cmd.Parameters.AddWithValue("@OlusturmaTarihi", DateTime.Now);
            cmd.Parameters.AddWithValue("@GuncellemeTarihi", DBNull.Value);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            GetData();


        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
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
    }
}
