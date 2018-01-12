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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void btnStudentAdd_Click(object sender, EventArgs e)
        {
            //Insert into student
            SqlConnection Connexion = new SqlConnection(@"Data Source=PC\SQLEXPRESS; Initial Catalog=ecole; Integrated Security=true;");
            Connexion.Open();
            SqlCommand Command = new SqlCommand("insert into student values('" + txtIdStudent.Text + "','" + txtStudentRegisterNumber.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" +txtBirthDate.Text + "','" + txtPhoneNumber.Text + "','" + cboGradeId.SelectedValue + "')", Connexion);
            Command.ExecuteNonQuery();
            Connexion.Close();

            LoadData();
        }

        private void cboGradeId_Click(object sender, EventArgs e)
        {
            // Remplir le combox box depuis la BD===table  
            SqlConnection Connexion = new SqlConnection(@"Data Source=PC\SQLEXPRESS; Initial Catalog=ecole; Integrated Security=true;");
            Connexion.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from grade",Connexion);
            DataSet ds = new DataSet();
            da.Fill(ds, "temp");

            cboGradeId.DataSource = ds.Tables["temp"];
            cboGradeId.ValueMember = ds.Tables["temp"].Columns[0].ToString();
            cboGradeId.DisplayMember = ds.Tables["temp"].Columns[1].ToString();

            Connexion.Close();
        }
        public void LoadData()
        {
            SqlConnection Connexion = new SqlConnection(@"Data Source=PC\SQLEXPRESS; Initial Catalog=ecole; Integrated Security=true;");
            //Remplir le datagrid
            SqlDataAdapter dg = new SqlDataAdapter("select * from student", Connexion);
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

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtIdStudent.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtStudentRegisterNumber.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtFirstName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtLastName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtBirthDate.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtPhoneNumber.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //cboGradeId.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }
    }
}
