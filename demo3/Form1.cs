﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace demo3
{
    public partial class Form1 : Form
    {
        db_connection DataBase = new db_connection();

        int selectedrow;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            createcolumns();
            refreshdatagrid(dataGridView1);
            dataGridView1_CellContentClick(this.dataGridView1, new DataGridViewCellEventArgs(0,0));
        }

        private void createcolumns()
        {
            dataGridView1.Columns.Add("ProductType", "Тип");
            dataGridView1.Columns.Add("Title", "Название");
            dataGridView1.Columns.Add("Articul", "Артикул");
            dataGridView1.Columns.Add("Cost", "Цена");
            dataGridView1.Columns.Add("Material", "Материал");
        }

        private void readsinglerow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), record.GetString(4));
        }

        private void refreshdatagrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            String querystring = $"select * from MY_PRODUCT";

            SqlCommand command = new SqlCommand(querystring, DataBase.getConnection());

            DataBase.OpenConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                readsinglerow(dgw, reader);
            }
            reader.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrow = e.RowIndex;

            if (e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedrow];

                label1.Text = row.Cells[0].Value.ToString();
                label2.Text = row.Cells[1].Value.ToString();
                label9.Text = row.Cells[2].Value.ToString();
                label4.Text = row.Cells[3].Value.ToString();
                label8.Text = row.Cells[4].Value.ToString();
                label18.Text = dataGridView1.Rows[1].Cells[0].Value.ToString();
                label17.Text = dataGridView1.Rows[1].Cells[1].Value.ToString();
                label10.Text = dataGridView1.Rows[1].Cells[2].Value.ToString();
                label15.Text = dataGridView1.Rows[1].Cells[3].Value.ToString();
                label11.Text = dataGridView1.Rows[1].Cells[4].Value.ToString();
                label27.Text = dataGridView1.Rows[2].Cells[0].Value.ToString();
                label26.Text = dataGridView1.Rows[2].Cells[1].Value.ToString();
                label19.Text = dataGridView1.Rows[2].Cells[2].Value.ToString();
                label24.Text = dataGridView1.Rows[2].Cells[3].Value.ToString();
                label20.Text = dataGridView1.Rows[2].Cells[4].Value.ToString();

            }

            dataGridView1.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.ShowDialog();
        }
    }
}
