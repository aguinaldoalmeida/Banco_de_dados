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
    public partial class pesquisar : _default
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }

        protected new void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtpesquisa.Text == "")
            {
                Listar(-10);
                return;
            }

            int id = Utils.Tools.validaInt(txtpesquisa.Text, "Pesquisa", lblResultado);
            if (id == -1) return;

            Listar(id);
        }

        public void Listar(int idt)
        {
            List<Buscar> listaBusca = new List<Buscar>();
            string query;

            using (SqlConnection conn = Sql.OpenConnection())
            {
                // Cria um comando para selecionar registros da tabela, trazendo todas as pessoas que nasceram depois de 1/1/1900

                
                if(idt == -10)
                {
                    query = "SELECT Id, Nome, Email, Nascimento, Peso, Endereco FROM tbPessoa ORDER BY Id ASC";
                }
                else
                {
                    query = "SELECT Id, Nome, Email, Nascimento, Peso, Endereco FROM tbPessoa WHERE Id = @id ORDER BY Id ASC";
                }                

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Esse valor poderia vir de qualquer outro lugar, como uma TextBox...
                    cmd.Parameters.AddWithValue("@id", idt);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Obtém os registros, um por vez

                        while (reader.Read() == true)
                        {
                            int id = reader.GetInt32(0);
                            string nome = reader.GetString(1);
                            string email = reader.GetString(2);
                            DateTime nascimento = reader.GetDateTime(3);
                            double peso = reader.GetDouble(4);
                            string endereco = reader.GetString(5);

                            Buscar b = new Buscar(nome, endereco, email, nascimento,(int) peso, id);

                            listaBusca.Add(b);                            
                        }
                    }
                }
            }

            Repeater1.DataSource = listaBusca;
            Repeater1.DataBind();
        }
    }
}