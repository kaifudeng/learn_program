﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wrox.ProCSharp.Entities;

namespace RacersModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["Formula1v2Entities"].ConnectionString;
            var connection = new EntityConnection(connectionString);
            await connection.OpenAsync();
            EntityCommand command = connection.CreateCommand();
            command.CommandText =
                "SELECT VALUE it FROM [Formula1v2Entities].[Racers] AS it " +
                "WHERE it.Nationality =@Country";
            command.Parameters.AddWithValue("Country", "Austria");
            DbDataReader reader = await command.ExecuteReaderAsync(
                CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection);
            while (await reader.ReadAsync())
            {
                label1.Text += "\n" + reader["Country"];
            }
            reader.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            /*using (var data = new Formula1v2Entities())
            {
                DbSqlQuery<Racer> racers = data.Racers.SqlQuery(
                    "SELECT * FROM Racers WHERE nationality=@Country",
                    new SqlParameter("country",country));
            }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Linq天下第一
            using (var data = new Formula1v2Entities())
            {
                var racers = from r in data.Racers
                             where r.Wins > 40
                             orderby r.Wins descending
                             select r;
                foreach (Racers r in racers)
                {
                    label1.Text += "\n" + r.FirstName;
                    label2.Text += "\n" + r.LastName;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (var data = new Formula1v2Entities())
            {
                var query = from r in data.Racers
                            from rr in data.RaceResults
                            where rr.Position <= 3 && rr.Position >= 1 &&
                            r.Nationality == "Switzerland"
                            group r by r.Id into g
                            let podium = g.Count()
                            orderby podium descending
                            select new
                            {
                                Racer = g.FirstOrDefault(),
                                Podium = podium
                            };
                foreach (var r in query)
                {
                    label1.Text += "\n" + r.Racer.FirstName + " " + r.Racer.LastName;
                    label2.Text += "\n" + r.Podium;
                }
            }
        }
    }
}
