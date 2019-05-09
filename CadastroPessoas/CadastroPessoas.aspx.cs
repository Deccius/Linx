using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CadastroPessoas
{
    public partial class CadastroPessoas : System.Web.UI.Page
    {
        List<Pessoa> ListaPessoa = new List<Pessoa>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGravaPessoa_Click(object sender, EventArgs e)
        {
            ListaPessoa = this.ViewState["Lista"] as List<Pessoa>;

            if (ListaPessoa == null)
            {
                ListaPessoa = new List<Pessoa>();
            }

            if (btnGravaPessoa.Text == "Editar")
            {
                EditaLinha();
            }

            else
            {
                Pessoa dbPessoa = new Pessoa();

                dbPessoa.Nome = txtNomePessoa.Text;
                dbPessoa.DtNascto = DateTime.Parse(txtDtNascto.Text);
                dbPessoa.Idade = DateTime.Now.Year - dbPessoa.DtNascto.Year;

                if (DateTime.Now.Month < dbPessoa.DtNascto.Month || (DateTime.Now.Month == dbPessoa.DtNascto.Month && DateTime.Now.Day < dbPessoa.DtNascto.Day))
                {
                    dbPessoa.Idade--;
                }

                dbPessoa.Dinheiro = Decimal.Parse(txtVrDinheiro.Text);

                ListaPessoa.Add(dbPessoa);
                gvPessoas.DataSource = ListaPessoa;
                gvPessoas.DataBind();

                PegaValorMax();
                PegaValorMin();

            }

            this.ViewState["Lista"] = ListaPessoa;

            btnLimpa_Click(null, null);
        }

        protected void btnLimpa_Click(object sender, EventArgs e)
        {
            Utilities.ResetAllControls(pnlPrincipal);
        }

        protected void gvPessoas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ListaPessoa = this.ViewState["Lista"] as List<Pessoa>;
            ListaPessoa.RemoveAt(e.RowIndex);
            gvPessoas.DataSource = ListaPessoa;
            gvPessoas.DataBind();

            PegaValorMax();
            PegaValorMin();

            this.ViewState["Lista"] = ListaPessoa;
        }

        protected void gvPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNomePessoa.Text = gvPessoas.SelectedDataKey["Nome"].ToString();
            DateTime data = DateTime.Parse(gvPessoas.SelectedDataKey["DtNascto"].ToString());
            txtDtNascto.Text = data.ToString("dd/MM/yyyy");
            txtVrDinheiro.Text = gvPessoas.SelectedDataKey["Dinheiro"].ToString();
            btnGravaPessoa.Text = "Editar";
            lblEdita.Text = gvPessoas.SelectedIndex.ToString();
        }

        protected void EditaLinha()
        {
            ListaPessoa = this.ViewState["Lista"] as List<Pessoa>;

            var dbPessoa = new Pessoa();

            int Index = int.Parse(lblEdita.Text);
            dbPessoa.Nome = txtNomePessoa.Text;
            dbPessoa.DtNascto = DateTime.Parse(txtDtNascto.Text);
            dbPessoa.Idade = DateTime.Now.Year - dbPessoa.DtNascto.Year;

            if (DateTime.Now.Month < dbPessoa.DtNascto.Month || (DateTime.Now.Month == dbPessoa.DtNascto.Month && DateTime.Now.Day < dbPessoa.DtNascto.Day))
            {
                dbPessoa.Idade--;
            }

            dbPessoa.Dinheiro = Decimal.Parse(txtVrDinheiro.Text);

            ListaPessoa.RemoveAt(Index);
            ListaPessoa.Insert(Index, dbPessoa);

            gvPessoas.DataSource = ListaPessoa;
            gvPessoas.DataBind();

            this.ViewState["Lista"] = ListaPessoa;

            btnGravaPessoa.Text = "Gravar";
            PegaValorMax();
            PegaValorMin();
        }

        protected void ValidaCampos()
        {
            if (string.IsNullOrEmpty(txtNomePessoa.Text))
            {
                lblErroNome.Visible = true;
                return;
            }
        }

        protected void PegaValorMax()
        {

            decimal maxValue = -1;
            int i = 0;
            int MaxIndex = 0;
            string Nome = string.Empty;
            /* see it is assumed that the gridview column contains a number greater than or equal to 0*/
            foreach (GridViewRow item in gvPessoas.Rows)
            {
                if (decimal.Parse(item.Cells[2].Text) > maxValue)
                {
                    maxValue = decimal.Parse(item.Cells[2].Text);
                    MaxIndex = i;
                    Nome = item.Cells[0].Text;
                }

                i++;
            }

            lblDinheiroMax.Text = "Pessoa com mais dinheiro: " + Nome + " Valor: R$" + maxValue;
        }

        protected void PegaValorMin()
        {

            decimal minValue = -1;
            int i = 0;
            string Nome = string.Empty;
            /* see it is assumed that the gridview column contains a number greater than or equal to 0*/
            foreach (GridViewRow item in gvPessoas.Rows)
            {
                if (decimal.Parse(item.Cells[2].Text) < minValue && i > 0)
                {
                    minValue = decimal.Parse(item.Cells[2].Text);
                    Nome = item.Cells[0].Text;
                }
                else if (i <= 0)
                {
                    minValue = decimal.Parse(item.Cells[2].Text);
                    Nome = item.Cells[0].Text;
                }

                i++;
            }

            lblDinheiroMin.Text = "Pessoa com menos dinheiro: " + Nome + " Valor: R$" + minValue;
        }

    }
}