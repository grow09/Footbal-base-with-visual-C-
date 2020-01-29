using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace footbal
{
    public partial class best : Form
    {
        public best() // вивод данних з бд в датагрід
        {
            InitializeComponent();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();

            string query = "SELECT name, surname, age, country, avg_goal, count_goal, count_match, club FROM PLAYER";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while(reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }

            reader.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // внесення змін в данних
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();

            string query = "TRUNCATE `player`;";

            MySqlCommand deleting = new MySqlCommand(query, db.getConnection());

            MySqlDataReader reader = deleting.ExecuteReader();

            db.closeConnection();
            
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                string name = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                string surname = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                int age = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                string country = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                double avg_goal = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                int count_match = Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                int count_goal = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                string club = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);

                MySqlCommand command = new MySqlCommand("INSERT INTO `football`.`player` (`id`, `name`, `surname`, `age`, `country`, `avg_goal`, `count_goal`, `count_match`, `club`) VALUES(DEFAULT, @add_name, @add_surname, @add_age, @add_country, @add_avg_goal, @add_count_goal, @add_count_match, @add_club); SET SQL_SAFE_UPDATES = 0; delete from player where age=0;", db.getConnection());

                command.Parameters.Add("@add_name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@add_surname", MySqlDbType.VarChar).Value = surname;
                command.Parameters.Add("@add_age", MySqlDbType.Int16).Value = age;
                command.Parameters.Add("@add_country", MySqlDbType.VarChar).Value = country;
                command.Parameters.Add("@add_avg_goal", MySqlDbType.Double).Value = avg_goal;
                command.Parameters.Add("@add_count_goal", MySqlDbType.Int16).Value = count_goal;
                command.Parameters.Add("@add_count_match", MySqlDbType.Int16).Value = count_match;
                command.Parameters.Add("@add_club", MySqlDbType.VarChar).Value = club;

                adapter.SelectCommand = command;
                adapter.Fill(table);
            }
        }

        string cluber;

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();

            string query = "SELECT club, count(club) as cnt FROM PLAYER group by club order by count(club) asc;";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                cluber = reader[0].ToString();
            }
 
            reader.Close();

            string query2 = "SELECT name, surname, age, country, avg_goal, count_goal, count_match, club FROM PLAYER where club ='" + cluber + "'";

            MySqlCommand command2 = new MySqlCommand(query2, db.getConnection());

            MySqlDataReader reader2 = command2.ExecuteReader();

            List<string[]> data2 = new List<string[]>();

            while (reader2.Read())
            {
                data2.Add(new string[8]);

                data2[data2.Count - 1][0] = reader2[0].ToString();
                data2[data2.Count - 1][1] = reader2[1].ToString();
                data2[data2.Count - 1][2] = reader2[2].ToString();
                data2[data2.Count - 1][3] = reader2[3].ToString();
                data2[data2.Count - 1][4] = reader2[4].ToString();
                data2[data2.Count - 1][5] = reader2[5].ToString();
                data2[data2.Count - 1][6] = reader2[6].ToString();
                data2[data2.Count - 1][7] = reader2[7].ToString();
            }

            reader2.Close();

            foreach (string[] s in data2)
                dataGridView1.Rows.Add(s);
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();

            string query = "SELECT name, surname, age, country, avg_goal, count_goal, count_match, club FROM PLAYER where country ='" + textBox1.Text+"';";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }

            reader.Close();

            foreach (string[] s in data)
            dataGridView1.Rows.Add(s);
            dataGridView1.Refresh();  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();

            string query = "SELECT name, surname, age, country, avg_goal, count_goal, count_match, club FROM PLAYER where club='" + textBox2.Text + "';";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }

            reader.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BestPlayer newForm = new BestPlayer();
            newForm.Show();
        }
    }
}
