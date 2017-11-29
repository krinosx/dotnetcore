using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace DOTNETMVC.Models
{
    public class CotacaoDAO
    {
        public string ConnectionString { get; set; }

        public CotacaoDAO(){

            string user = Environment.GetEnvironmentVariable("DATABASE_USER");
            string pass = Environment.GetEnvironmentVariable("DATABASE_PASS");
            string host = Environment.GetEnvironmentVariable("DATABASE_HOST");
            string basename = Environment.GetEnvironmentVariable("DATABASE_BASE");

            this.ConnectionString = "server=" + host + ";port=3306;database="+ basename + ";user=" + user + ";password=" + pass;

            this.ConnectionString = ConnectionString;
        } 

        private MySqlConnection GetConnection(){
            return new MySqlConnection(this.ConnectionString);
        }


    public List<CotacaoModel> getCotacao(){
            List<CotacaoModel> cotacoes = new List<CotacaoModel>();

            using( MySqlConnection conn = GetConnection() ){

                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select codigo_negocio, preco_medio from mdt_cotacao_historica ",conn);
                using( MySqlDataReader reader = cmd.ExecuteReader() ) {
                    while( reader.Read() ){
                        cotacoes.Add( new CotacaoModel(){
                            price = reader.GetString("preco_medio"),
                            CodigoNegocio = reader.GetString("codigo_negocio")
                        });
                    }
                }
            }

            return cotacoes;
        }
    }
}