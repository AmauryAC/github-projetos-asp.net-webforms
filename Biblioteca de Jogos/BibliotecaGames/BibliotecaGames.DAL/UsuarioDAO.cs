using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaGames.Entities;
using System.Data.SqlClient;

namespace BibliotecaGames.DAL
{
    public class UsuarioDAO
    {
        public Usuario ObterUsuarioPeloUsuarioESenha(string nomeUsuario, string senha)
        {
            try
            {
                var command = new SqlCommand();

                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM Usuario WHERE usuario = @usuario AND senha = @senha";

                command.Parameters.AddWithValue("@usuario", nomeUsuario);
                command.Parameters.AddWithValue("@senha", senha);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                Usuario usuario = null;

                while(reader.Read())
                {
                    usuario = new Usuario();

                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NomeUsuario = reader["usuario"].ToString();
                    usuario.Senha = reader["senha"].ToString();
                    usuario.Perfil = Convert.ToChar(reader["perfil"]);
                }

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
