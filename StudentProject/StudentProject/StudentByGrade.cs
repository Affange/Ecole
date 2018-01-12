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

namespace StudentProject
{
    public partial class StudentByGrade : Form
    {
        public StudentByGrade()
        {
            InitializeComponent();
        }

        private void cboListGrade_Click(object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(@"Data Source=PC\SQLEXPRESS; Initial Catalog=ecole; Integrated Security=true;");
            Connexion.Open();
            SqlDataAdapter da = new SqlDataAdapter("select gradeid,gradename from grade", Connexion);
            DataSet ds = new DataSet();
            da.Fill(ds, "temp");

            cboListGrade.DataSource = ds.Tables["temp"];
            cboListGrade.ValueMember = ds.Tables["temp"].Columns[0].ToString();
            cboListGrade.DisplayMember = ds.Tables["temp"].Columns[1].ToString();          
            Connexion.Close();
            LoadData();


        }
        public void LoadData()
        {
            SqlConnection Connexion = new SqlConnection(@"Data Source=PC\SQLEXPRESS; Initial Catalog=ecole; Integrated Security=true;");
            //Remplir le datagrid
            SqlDataAdapter dg = new SqlDataAdapter("select * from student where gradeId ='" + cboListGrade.SelectedValue +"' ", Connexion);
            DataTable dt = new DataTable();
            dg.Fill(dt);
           
             dataGridView1.Rows.Clear();
             foreach (DataRow item in dt.Rows)
              {
                  int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value =item["Id"].ToString();
                 dataGridView1.Rows[n].Cells[1].Value = item["RegisterNumber"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Firstname"].ToString();
                 dataGridView1.Rows[n].Cells[3].Value = item["Lastname"].ToString();
                 dataGridView1.Rows[n].Cells[4].Value = item["BirthDate"].ToString();
                 dataGridView1.Rows[n].Cells[5].Value = item["PhoneNumber"].ToString();
             }
        }
        private void cboListGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void StudentByGrade_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSearchList_Click(object sender, EventArgs e)
        {
            SqlConnection Connexion = new SqlConnection(@"Data Source=PC\SQLEXPRESS; Initial Catalog=ecole; Integrated Security=true;");
            //Remplir le datagrid
            SqlDataAdapter dg = new SqlDataAdapter("select * from student where gradeid ='" + txtSearchList.Text + "' ", Connexion);
            DataTable dt = new DataTable();
            dg.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
              {
                  int n = dataGridView1.Rows.Add();
                 dataGridView1.Rows[n].Cells[0].Value = item["Id"].ToString();
                 dataGridView1.Rows[n].Cells[1].Value = item["RegisterNumber"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Firstname"].ToString();
                 dataGridView1.Rows[n].Cells[3].Value = item["Lastname"].ToString();
                 dataGridView1.Rows[n].Cells[4].Value = item["BirthDate"].ToString();
                 dataGridView1.Rows[n].Cells[5].Value = item["PhoneNumber"].ToString();
              }

        }

        private void cboListGrade_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }
    }
    
}
