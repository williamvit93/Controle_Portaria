using System;
using System.Collections.Generic;
using WaTecnologia.ControlePortaria.Domain;
using System.Data;

namespace WaTecnologia.ControlePortaria.Repository
{
    public class EncomendasRepository
    {
        private ConexaoDados conexao;
        public EncomendasRepository()
        {
            conexao = new ConexaoDados();
        }

        public void Inserir(EncomendaModel encomenda)
        {
            var con = conexao.AbrirConexao();
            con.Open();
            try
            {

                var command = con.CreateCommand();
                command.CommandText = $@"INSERT INTO ENCOMENDAS
                                    (NomeRemetente, NumApartamento, Torre, DataRecebimento, Ativo, StatusEntrega)
                                    VALUES
                                    (@NomeRemetente,
                                    @NumApartamento,
                                    @Torre, 
                                    @DataRecebimento, 
                                    @Ativo, 
                                    @StatusEntrega)";

                command.Parameters.Add(nameof(encomenda.NomeRemetente), SqlDbType.VarChar).Value = encomenda.NomeRemetente;
                command.Parameters.Add(nameof(encomenda.NumApartamento), SqlDbType.Int).Value = encomenda.NumApartamento;
                command.Parameters.Add(nameof(encomenda.Torre), SqlDbType.VarChar).Value = encomenda.Torre;
                command.Parameters.Add(nameof(encomenda.DataRecebimento), SqlDbType.DateTime).Value = encomenda.DataRecebimento;
                command.Parameters.Add(nameof(encomenda.Ativo), SqlDbType.Bit).Value = encomenda.Ativo;
                command.Parameters.Add(nameof(encomenda.StatusEntrega), SqlDbType.Bit).Value = encomenda.StatusEntrega;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.FecharConexao(con);
            }

        }

        public List<EncomendaModel> Listar()
        {
            var encomendas = new List<EncomendaModel>();
            var con = conexao.AbrirConexao();
            con.Open();
            try
            {
                var command = con.CreateCommand();
                command.CommandText = $@"Select * from Encomendas";

                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        EncomendaModel encomenda = new EncomendaModel();

                        encomenda.Id = Convert.ToInt32(dataReader["Id"]);
                        encomenda.NomeRemetente = dataReader["NomeRemetente"].ToString();
                        encomenda.NomeRetirada = dataReader["NomeRetirada"].ToString();
                        encomenda.DocRetirada = dataReader["DocRetirada"].ToString();
                        encomenda.NumApartamento = Convert.ToInt32(dataReader["NumApartamento"]);
                        encomenda.Torre = dataReader["Torre"].ToString();
                        encomenda.DataRecebimento = Convert.ToDateTime(dataReader["DataRecebimento"]);
                        encomenda.Ativo = Convert.ToBoolean(dataReader["Ativo"]);
                        encomenda.StatusEntrega = string.IsNullOrEmpty(dataReader["StatusEntrega"].ToString()) ? false : Convert.ToBoolean(dataReader["StatusEntrega"]);
                        encomenda.DataEntrega = string.IsNullOrEmpty(dataReader["DataEntrega"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dataReader["DataEntrega"]);

                        encomendas.Add(encomenda);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.FecharConexao(con);
            }

            return encomendas;
        }

        public EncomendaModel BuscarPorId(int id)
        {
            var encomenda = new EncomendaModel();
            var con = conexao.AbrirConexao();
            con.Open();
            try
            {
                var command = con.CreateCommand();
                command.CommandText = $@"Select * from Encomendas Where Id = {id}";

                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        encomenda.Id = Convert.ToInt32(dataReader["Id"]);
                        encomenda.NomeRemetente = dataReader["NomeRemetente"].ToString();
                        encomenda.NomeRetirada = dataReader["NomeRetirada"].ToString();
                        encomenda.DocRetirada = dataReader["DocRetirada"].ToString();
                        encomenda.NumApartamento = Convert.ToInt32(dataReader["NumApartamento"]);
                        encomenda.Torre = dataReader["Torre"].ToString();
                        encomenda.DataRecebimento = Convert.ToDateTime(dataReader["DataRecebimento"]);
                        encomenda.Ativo = Convert.ToBoolean(dataReader["Ativo"]);
                        encomenda.StatusEntrega = string.IsNullOrEmpty(dataReader["StatusEntrega"].ToString()) ? false : Convert.ToBoolean(dataReader["StatusEntrega"]);
                        encomenda.DataEntrega = string.IsNullOrEmpty(dataReader["DataEntrega"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dataReader["DataEntrega"]);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.FecharConexao(con);
            }

            return encomenda;
        }

        public List<EncomendaModel> FiltrarPorParametros(EncomendaModel parametros)
        {
            var encomendas = new List<EncomendaModel>();
            var con = conexao.AbrirConexao();
            con.Open();
            try
            {
                var command = con.CreateCommand();
                command.CommandText = $@"
                                        SELECT * FROM Encomendas
                                        Where 
	                                        (@NomeRemetente IS NULL OR @NomeRemetente ='' OR NomeRemetente like '%' + @NomeRemetente + '%')
	                                        AND (@NumApartamento = 0 OR NumApartamento = @NumApartamento)
	                                        AND (@Torre IS NULL OR @TORRE='' OR Torre = @Torre)


                                        ";
                command.Parameters.Add(nameof(parametros.NomeRemetente), SqlDbType.VarChar).Value = string.IsNullOrEmpty(parametros.NomeRemetente) ? "":parametros.NomeRemetente;
                command.Parameters.Add(nameof(parametros.NumApartamento), SqlDbType.Int).Value = parametros.NumApartamento;
                command.Parameters.Add(nameof(parametros.Torre), SqlDbType.VarChar).Value = string.IsNullOrEmpty(parametros.Torre) ? "" : parametros.Torre;

                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        EncomendaModel encomenda = new EncomendaModel();

                        encomenda.Id = Convert.ToInt32(dataReader["Id"]);
                        encomenda.NomeRemetente = dataReader["NomeRemetente"].ToString();
                        encomenda.NomeRetirada = dataReader["NomeRetirada"].ToString();
                        encomenda.DocRetirada = dataReader["DocRetirada"].ToString();
                        encomenda.NumApartamento = Convert.ToInt32(dataReader["NumApartamento"]);
                        encomenda.Torre = dataReader["Torre"].ToString();
                        encomenda.DataRecebimento = Convert.ToDateTime(dataReader["DataRecebimento"]);
                        encomenda.Ativo = Convert.ToBoolean(dataReader["Ativo"]);
                        encomenda.StatusEntrega = string.IsNullOrEmpty(dataReader["StatusEntrega"].ToString()) ? false : Convert.ToBoolean(dataReader["StatusEntrega"]);
                        encomenda.DataEntrega = string.IsNullOrEmpty(dataReader["DataEntrega"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dataReader["DataEntrega"]);

                        encomendas.Add(encomenda);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.FecharConexao(con);
            }

            return encomendas;
        }

            

        



        public void Remover(int id)
        {
            var con = conexao.AbrirConexao();
            con.Open();
            try
            {

                var command = con.CreateCommand();
                command.CommandText = $@"UPDATE ENCOMENDAS
                                        SET ATIVO = 0
                                        WHERE Id = @Id )";

                command.Parameters.Add("Id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.FecharConexao(con);
            }
        }

        public void Editar(EncomendaModel encomenda)
        {
            var con = conexao.AbrirConexao();
            con.Open();
            try
            {

                var command = con.CreateCommand();
                command.CommandText = $@"UPDATE ENCOMENDAS
                                    SET NomeRemetente = @NomeRemetente,
                                    NumApartamento = @NumApartamento,
                                    Torre = @Torre,
                                    DataRecebimento = @DataRecebimento,
                                    Ativo = @Ativo,
                                    DocRetirada = @DocRetirada,
                                    NomeRetirada = @NomeRetirada,
                                    DataEntrega = @DataEntrega,
                                    StatusEntrega = @StatusEntrega
                                    WHERE Id = @Id";

                command.Parameters.Add(nameof(encomenda.NomeRemetente), SqlDbType.VarChar).Value = encomenda.NomeRemetente;
                command.Parameters.Add(nameof(encomenda.NumApartamento), SqlDbType.Int).Value = encomenda.NumApartamento;
                command.Parameters.Add(nameof(encomenda.Torre), SqlDbType.VarChar).Value = encomenda.Torre;
                command.Parameters.Add(nameof(encomenda.DataRecebimento), SqlDbType.DateTime).Value = encomenda.DataRecebimento;
                command.Parameters.Add(nameof(encomenda.Ativo), SqlDbType.Bit).Value = encomenda.Ativo;
                command.Parameters.Add(nameof(encomenda.DocRetirada), SqlDbType.VarChar).Value = encomenda.DocRetirada;
                command.Parameters.Add(nameof(encomenda.NomeRetirada), SqlDbType.VarChar).Value = encomenda.NomeRetirada;
                command.Parameters.Add(nameof(encomenda.DataEntrega), SqlDbType.DateTime).Value = encomenda.DataEntrega;
                command.Parameters.Add(nameof(encomenda.StatusEntrega), SqlDbType.Bit).Value = encomenda.StatusEntrega;
                command.Parameters.Add(nameof(encomenda.Id), SqlDbType.Int).Value = encomenda.Id;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.FecharConexao(con);
            }
        }
    }
}
