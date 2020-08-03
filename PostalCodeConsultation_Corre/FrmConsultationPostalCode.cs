using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostalCodeConsultation_Corre
{
    public partial class FrmConsultationPostalCode : Form
    {
        public FrmConsultationPostalCode()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lblCep.Text))
            {
                using(var ws = new WSConsultationCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(txtCep.Text.Trim());
                        txtBairro.Text = endereco.bairro;
                        txtRua.Text = endereco.end;
                        txtCidade.Text = endereco.cidade;
                        txtEstado.Text = endereco.uf;
                        

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message,this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP Válido...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtBairro.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtRua.Text = string.Empty;

        }

    }
}
