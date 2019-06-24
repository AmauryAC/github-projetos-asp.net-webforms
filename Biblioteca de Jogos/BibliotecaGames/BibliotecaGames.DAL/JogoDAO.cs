﻿using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.DAL
{
    public class JogoDAO
    {
        public List<Jogo> ObterTodosOsJogos()
        {
            try
            {
                var command = new SqlCommand();

                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM Jogo";

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                var jogos = new List<Jogo>();

                while (reader.Read())
                {
                    var jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = (reader["valorPago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valorPago"]));
                    jogo.DataCompra = (reader["dataCompra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["dataCompra"]));
                    jogo.Imagem = reader["imagem"].ToString();

                    jogos.Add(jogo);
                }

                return jogos;
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

        public Jogo ObterJogoPeloId(int id)
        {
            try
            {
                var command = new SqlCommand();

                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM Jogo WHERE id = @id";

                command.Parameters.AddWithValue("@id", id);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                Jogo jogo = null;

                while (reader.Read())
                {
                    jogo = new Jogo();

                    jogo.Id = Convert.ToInt32(reader["id"]);
                    jogo.Titulo = reader["titulo"].ToString();
                    jogo.ValorPago = (reader["valorPago"] == DBNull.Value ? (double?)null : Convert.ToDouble(reader["valorPago"]));
                    jogo.DataCompra = (reader["dataCompra"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["dataCompra"]));
                    jogo.Imagem = reader["imagem"].ToString();
                    jogo.IdEditor = Convert.ToInt32(reader["id_editor"]);
                    jogo.IdGenero = Convert.ToInt32(reader["id_genero"]);
                }

                return jogo;
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

        public int InserirJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();

                command.Connection = Conexao.connection;
                command.CommandText = @"INSERT INTO [dbo].[Jogo]
                                                   ([titulo]
                                                   ,[valorPago]
                                                   ,[dataCompra]
                                                   ,[id_editor]
                                                   ,[id_genero]
                                                   ,[imagem])
                                             VALUES
                                                   (@titulo,
                                                    @valorPago,
                                                    @dataCompra,
                                                    @id_editor,
                                                    @id_genero,
                                                    @imagem)";

                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@valorPago", jogo.ValorPago);
                command.Parameters.AddWithValue("@dataCompra", jogo.DataCompra);
                command.Parameters.AddWithValue("@id_editor", jogo.IdGenero);
                command.Parameters.AddWithValue("@id_genero", jogo.IdGenero);
                command.Parameters.AddWithValue("@imagem", jogo.Imagem);

                Conexao.Conectar();

                return command.ExecuteNonQuery();
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

        public int AlterarJogo(Jogo jogo)
        {
            try
            {
                var command = new SqlCommand();

                command.Connection = Conexao.connection;
                command.CommandText = @"UPDATE [dbo].[Jogo]
                                           SET [titulo] = @titulo,
                                               [valorPago] = @valorPago,
                                               [dataCompra] = @dataCompra,
                                               [id_editor] = @id_editor,
                                               [id_genero] = @id_genero
                                         WHERE id = @id";

                command.Parameters.AddWithValue("@titulo", jogo.Titulo);
                command.Parameters.AddWithValue("@valorPago", jogo.ValorPago);
                command.Parameters.AddWithValue("@dataCompra", jogo.DataCompra);
                command.Parameters.AddWithValue("@id_editor", jogo.IdGenero);
                command.Parameters.AddWithValue("@id_genero", jogo.IdGenero);
                //command.Parameters.AddWithValue("@imagem", jogo.Imagem);
                command.Parameters.AddWithValue("@id", jogo.Id);

                Conexao.Conectar();

                return command.ExecuteNonQuery();
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
