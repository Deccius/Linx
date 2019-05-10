using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace CadastroPessoas
{
    public class PessoasConexao : Conexao
    {
        public bool Inserir(Pessoa pessoa)
        {
            using (var conexao = base.conexao)
            {
                string query = (@"INSERT INTO TBPESSOA (ID, NOME, DATANASCIMENTO, IDADE, DINHEIRO)
                               VALUES (@Nome, @DataNascimento, @Idade, @Dinheiro)");

                
                SqlCommand cmd = new SqlCommand(query.ToString(), conexao);

                cmd.Parameters.AddWithValue("Id", pessoa.Id);
                cmd.Parameters.AddWithValue("Nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("DataNascimento", pessoa.DtNascto);
                cmd.Parameters.AddWithValue("Idade", pessoa.Idade);
                cmd.Parameters.AddWithValue("Dinheiro", pessoa.Dinheiro);

                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Atualizar(Pessoa pessoa)
        {
            using (var conexao = base.conexao)
            {
                string query = (@"UPDATE TBPESSOA SET ID=@ID, NOME=@NOME, DATANASCIMENTO=@DATANASCIMENTO, IDADE=@IDADE, DINHEIRO=@DINHEIRO)
                               VALUES (@Nome, @DataNascimento, @Idade, @Dinheiro)");


                SqlCommand cmd = new SqlCommand(query.ToString(), conexao);

                cmd.Parameters.AddWithValue("@Id", pessoa.Id);
                cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", pessoa.DtNascto);
                cmd.Parameters.AddWithValue("@Idade", pessoa.Idade);
                cmd.Parameters.AddWithValue("@Dinheiro", pessoa.Dinheiro);

                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Excluir(Pessoa pessoa)
        {
            using (var conexao = base.conexao)
            {
                string query = "DELETE FROM TBPESSOA WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(query, conexao);

                cmd.Parameters.AddWithValue("@Id", pessoa.Id);
                
                var result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool Buscar(Pessoa pessoa)
        {
            using (var conexao = base.conexao)
            {
                string query = "SELECT * FROM TBPESSOA WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(query, conexao);

                cmd.Parameters.AddWithValue("@Id", pessoa.Id);

                SqlDataReader reader;

                reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    pessoa.Id = int.Parse(reader[0].ToString());
                    pessoa.Nome = reader[1].ToString();
                    pessoa.DtNascto = DateTime.Parse(reader[2].ToString());
                    pessoa.Idade = int.Parse(reader[3].ToString());
                    pessoa.Dinheiro = Decimal.Parse(reader[4].ToString());

                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

    }
}