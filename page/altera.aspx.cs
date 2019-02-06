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
    public partial class altera : _default
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            int id = 0;

            if (IsPostBack == false)
            {                
                id = Utils.Tools.validaInt(Request.QueryString["id"], "ID",lblResultado);
                if (id == -1) return;
                Listar(id);
            }
            else
            {
                // O usuário clicou em um botão, ou realizou alguma ação!
            }
        }

        protected new void btnCriar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }

        public void Listar(int idt)
        {
            using (SqlConnection conn = Sql.OpenConnection())
            {
                // Cria um comando para selecionar registros da tabela, trazendo todas as pessoas que nasceram depois de 1/1/1900
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Email, Nascimento, Peso, Endereco FROM tbPessoa WHERE Id = @id ORDER BY Nome ASC", conn))
                {
                    // Esse valor poderia vir de qualquer outro lugar, como uma TextBox...
                    cmd.Parameters.AddWithValue("@id", idt);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Obtém os registros, um por vez

                        if (reader.Read() == true)
                        {
                            int id = reader.GetInt32(0);
                            string nome = reader.GetString(1);
                            string email = reader.GetString(2);
                            DateTime nascimento = reader.GetDateTime(3);
                            double peso = reader.GetDouble(4);
                            string endereco = reader.GetString(5);

                            txtnome.Text = nome;
                            txtemail.Text = email;
                            txtend.Text = endereco;
                            txtnasc.Text = nascimento.ToString("dd/MM/yyyy");
                            txtpeso.Text = peso.ToString();
                        }
                        else
                        {
                            lblResultado.Text = "Registro não Encontrado";
                        }
                    }
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            string nome = Utils.Tools.validaString(txtnome.Text, "Nome", lblResultado);
            string endereco = Utils.Tools.validaString(txtend.Text, "Endereco", lblResultado);
            string email = Utils.Tools.validaString(txtemail.Text, "Email", lblResultado);
            DateTime nascimento = Utils.Tools.validaDate(txtnasc.Text, "Nascimento", lblResultado);
            int peso = Utils.Tools.validaInt(txtpeso.Text, "Peso", lblResultado);

            if (nome == null) return;
            if (endereco == null) return;
            if (email == null) return;
            if (nascimento == default(DateTime)) return;
            if (peso == -1) return;


            using (SqlConnection conn = Sql.OpenConnection())
            {
                // Cria um comando para atualizar um registro da tabela
                using (SqlCommand cmd = new SqlCommand("UPDATE tbPessoa SET Nome=@nome, Endereco=@endereco, Email=@email, Nascimento=@nascimento, Peso=@peso WHERE Id=@id", conn))
                {
                    // Esses valores poderiam vir de qualquer outro lugar, como uma TextBox...
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@endereco", endereco);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@nascimento", nascimento);
                    cmd.Parameters.AddWithValue("@peso", peso);

                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        lblResultado.Text = "Erro ao salvar";
                    }
                    else
                    {
                        lblResultado.Text = "Atualizado com Sucesso!";
                    }
                }
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string nome = txtnome.Text;

            string URL = string.Format("deleta.aspx?id={0}&n={1}",
                                Uri.EscapeDataString(id), Uri.EscapeDataString(nome));
            Response.Redirect(URL);
        }
    }
}