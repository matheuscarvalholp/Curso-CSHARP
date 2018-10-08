using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace exemploentityframework
{
    public partial class Form1 : Form
    {
        ALMOXARIFADO aLMOXARIFADO = new ALMOXARIFADO();
        SamaeEntities Almoxarifado = new SamaeEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string Codigo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string Produtos = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string Quantidade = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtId.Text = id;
            txtCod.Text = Codigo;
            txtProd.Text = Produtos;
            txtQntd.Text = Quantidade;


        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            aLMOXARIFADO.Codigo = Convert.ToInt32(txtCod.Text);
            aLMOXARIFADO.Produtos = txtProd.Text;
            aLMOXARIFADO.Quantidade = Convert.ToDouble(txtQntd.Text);
            if (txtId.Text != "")
            {   
                aLMOXARIFADO = Almoxarifado.ALMOXARIFADO.Find(Convert.ToInt32(txtId.Text));
                aLMOXARIFADO.Codigo = Convert.ToInt32(txtCod.Text);
                aLMOXARIFADO.Produtos = txtProd.Text;
                aLMOXARIFADO.Quantidade = Convert.ToInt32(txtQntd.Text);

            }
            else
            {
                Almoxarifado.ALMOXARIFADO.Add(aLMOXARIFADO);

            }
            Almoxarifado.SaveChanges();
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = Almoxarifado.ALMOXARIFADO.ToList();
            dataGridView1.Refresh();

        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = Almoxarifado.ALMOXARIFADO.ToList();
            dataGridView1.Refresh();
        }

     
        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = Almoxarifado.ALMOXARIFADO.ToList();
            dataGridView1.Refresh();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                aLMOXARIFADO = Almoxarifado.ALMOXARIFADO.Find(Convert.ToInt32(txtId.Text));
                Almoxarifado.ALMOXARIFADO.Remove(aLMOXARIFADO);
                Almoxarifado.SaveChanges();
                dataGridView1.DataSource = "";
                dataGridView1.DataSource = Almoxarifado.ALMOXARIFADO.ToList();
                dataGridView1.Refresh();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Almoxarifado.ALMOXARIFADO.ToList().OrderBy(x=>x.Codigo);
            dataGridView1.Refresh();
        }
    }
}