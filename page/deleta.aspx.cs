using AulaBancoDados.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AulaBancoDados.page
{
    public partial class deleta : _default
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            int id = 0;

            if (IsPostBack == false)
            {
                id = Utils.Tools.validaInt(Request.QueryString["id"], "ID", lblResultado);
                if (id == -1) return;
                Listar(id);
            }
            else
            {
                // O usuário clicou em um botão, ou realizou alguma ação!
            }
        }

        public void Listar(int idt)
        {
            using (SqlConnection conn = Sql.OpenConnection())
            {
                // Cria um comando para selecionar registros da tabela, trazendo todas as pessoas que nasceram depois de 1/1/1900
                using (SqlCommand cmd = new SqlCommand("SELECT Nome FROM tbPessoa WHERE Id = @id ", conn))
                {
                    // Esse valor poderia vir de qualquer outro lugar, como uma TextBox...
                    cmd.Parameters.AddWithValue("@id", idt);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Obtém os registros, um por vez

                        if (reader.Read() == true)
                        {
                            msg.InnerHtml = "Você tem Certeza que Deseja Apagar o(a)" +  reader.GetString(0) +"?";
                        }
                        else
                        {
                            lblResultado.Text = "Registro não Encontrado";
                        }
                    }
                }
            }
        }

        protected void BtnSim_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = Sql.OpenConnection())
            {
                // Cria um comando para atualizar um registro da tabela
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbPessoa WHERE Id = @id", conn))
                {
                    int id = Utils.Tools.validaInt(Request.QueryString["id"], "ID",lblResultado);
                    if (id == -1) return;

                    cmd.Parameters.AddWithValue("@id", id);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        lblResultado.Text = "Erro ao deletarr";
                        sucesso.Visible = false;
                        pergunta.Visible = false;
                    }
                    else
                    {
                        sucesso.Visible = true;
                        pergunta.Visible = false;
                    }
                }
            }
        }

        protected void BtnNao_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            string URL = string.Format("altera.aspx?id={0}",
                                Uri.EscapeDataString(id));
            Response.Redirect(URL);
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }
    }
}