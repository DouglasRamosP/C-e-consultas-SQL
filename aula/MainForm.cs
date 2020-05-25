/*
 * Created by SharpDevelop.
 * User: Wariston Pereira
 * Date: 11/05/2020
 * Time: 20:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MySql.Data;
using System.Data;
using MySql.Data.MySqlClient;


namespace aula
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        void Button1Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder str = new MySqlConnectionStringBuilder();
            str.Server = "remotemysql.com";
            str.UserID = "269CpcWeCz";
            str.Password = "cfW77mMFx4";
            str.Database = "269CpcWeCz";

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = str.ConnectionString;

            con.Open();

            MySqlCommand com = new MySqlCommand();
            com.Connection = con;
            if (comboBox1.Text == "uf")
            {
                com.CommandText = "SELECT * FROM estados WHERE uf LIKE'" + textBox1.Text + "%'";

            }
            else if (comboBox1.Text == "id_estado")
            {
                com.CommandText = "SELECT * FROM estados WHERE id_estado LIKE'" + textBox1.Text + "%'";

            }
            else if (comboBox1.Text == "nome")
            {
                com.CommandText = "SELECT * FROM estados WHERE nome LIKE'" + textBox1.Text + "%'";
            }
            else
            {
                com.CommandText = "SELECT * FROM estados ";
            }

            // Usada para comandos que não possuem retorno
            // com.ExecuteNonQuery();

            // Carrega o resultado da consulta para o reader
            MySqlDataReader dr = com.ExecuteReader();

            // Tabela virtual
            DataTable dt = new DataTable();

            // Carrega dados do reader para tabela virtual
            dt.Load(dr);

            // Atribuição dos dados ao grid
            dataGridView1.DataSource = dt;

            con.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }    
    
}
