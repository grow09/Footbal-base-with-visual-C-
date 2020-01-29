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
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            int age = int.Parse(textBox3.Text);
            string country = textBox4.Text;
            string club = textBox5.Text;
//            double avg_goal = double.Parse(textBox6.Text);
            int count_match = int.Parse(textBox7.Text);
            int count_goal = int.Parse(textBox8.Text);
            double avg_goal = (double)count_goal / (double)count_match;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `football`.`player` (`id`, `name`, `surname`, `age`, `country`, `avg_goal`, `count_goal`, `count_match`, `club`) VALUES(DEFAULT, @add_name, @add_surname, @add_age, @add_country, @add_avg_goal, @add_count_goal, @add_count_match, @add_club);", db.getConnection());
            
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
}
