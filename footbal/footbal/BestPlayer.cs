using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace footbal
{
    public partial class BestPlayer : Form
    {
        public BestPlayer()
        {
            InitializeComponent();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();

            string query = "SELECT name, surname, age, country, count_goal, count_match, club FROM PLAYER where avg_goal = (select max(avg_goal) from player)";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>(); 
            
            while (reader.Read())
            {
                label2.Text = reader[0].ToString();
                label3.Text = reader[1].ToString();
                label4.Text = "Вік " + reader[2].ToString();
                label5.Text = reader[3].ToString();
                label8.Text = reader[4].ToString();
                label7.Text = reader[5].ToString();
                label6.Text = reader[6].ToString();
            }

            reader.Close();

        }

        private void BestPlayer_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
