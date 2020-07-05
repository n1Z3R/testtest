using MySql.Data.MySqlClient;
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

namespace test
{
    public partial class Form1 : Form
    {
        public static MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }
     
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;

        private void Form1_Load(object sender, EventArgs e)
        {
            string server = "localhost";
            string database = "test";
            string uid = "root";
            string password = "admin";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection cn = new MySqlConnection(connectionString);
            cn.Open();
            cmd.CommandText = "select * from yml_last";
            cmd.Connection = cn;
            dr = cmd.ExecuteReader();

            lst.Columns.Clear();
            lst.Items.Clear();
            lst.View = View.Details;

            for (int i = 0; i < dr.FieldCount; i++)
            {
                lst.Columns.Add(dr.GetName(i));
            }
            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr[0].ToString());
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    lv.SubItems.Add(dr[i].ToString());
                }
                lst.Items.Add(lv);
            }
            cn.Close();
        }
        
    }
}
        
