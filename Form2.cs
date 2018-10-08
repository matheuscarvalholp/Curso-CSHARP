using exemploentityframework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        SamaeEntities samae = new SamaeEntities();
        ALMOXARIFADO aLMOXARIFADO = new ALMOXARIFADO();
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCodigo.Text = codigo;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = samae.ALMOXARIFADO.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);
                aLMOXARIFADO = samae.ALMOXARIFADO.Where(x=> x.Codigo  == codigo).First();
              aLMOXARIFADO.Quantidade =  aLMOXARIFADO.Quantidade - Convert.ToInt32(txtBaixa.Text);
                samae.SaveChanges();
                dataGridView1.DataSource = samae.ALMOXARIFADO.ToList();
                Form1 form = new Form1();
                form.Show();
                this.Hide();

            }
        }
    }
}
