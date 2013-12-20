using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data;

namespace FestivalLib.Model
{
    public class Database
    {
        //stap 0: info ophalen uit app.config

        private static ConnectionStringSettings ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MijnConnectionString"];
            }
        }

        //stap 1: Connectie leggen met de database
        public static DbConnection GetConnection()
        {
            DbConnection con = DbProviderFactories.GetFactory(ConnectionString.ProviderName).CreateConnection();
            con.ConnectionString = ConnectionString.ConnectionString;
            con.Open();
            return con;
        }
        //stap 2: connectie sluiten met de database
        public static void RelaseConnection(DbConnection con)
        {
            if (con != null)
            {
                con.Close();
                con = null;
            }
        }
        //stap 3: Command opstellen (boodschapenlijstje) <---- SQL string + Parameters
        //keyword params -----> als er geen parameters zijn hoeft er niets doorgegeven te worden (enkel een sql string)
        private static DbCommand BuildCommand(String sql, params DbParameter[] parameters)
        {
            DbCommand command = GetConnection().CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return command;
        }
        //stap 3A: aanmaken van een parameter
        public static DbParameter AddParameter(String naam, object value)
        {
            DbParameter parameter = DbProviderFactories.GetFactory(ConnectionString.ProviderName).CreateParameter();
            parameter.ParameterName = naam;
            parameter.Value = value;
            return parameter;
        }
        //stap 4A: SELECT-statements: info ophalen
        public static DbDataReader GetData(string sql, params DbParameter[] parameters)
        {
            //boodschappenlijstje aanmaken met methode van hierboven
            DbCommand command = BuildCommand(sql, parameters);
            DbDataReader reader = null;
            try
            {
                //datareader opvragen. als de reader alle informatie doorlopen heeft, wordt automatisch 
                //de connectie gesloten
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                if (reader != null) reader.Close();
                if (command != null) RelaseConnection(command.Connection);
                throw ex; //fout doorgeven aan de aanroepende methode
            }
        }


        //stap 4B: INSERT/DELETE/UPDATE: Database gaan manipuleren
        public static int ModifyData(String sql, params DbParameter[] parameters)
        {
            DbCommand command = BuildCommand(sql, parameters);
            try
            {
                int aantalGewijzigdeRijen = command.ExecuteNonQuery();
                return aantalGewijzigdeRijen;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (command != null) RelaseConnection(command.Connection);
                throw ex;
            }

        }
        /*******************uitbreiding: transacties **************/

        //stap 5: Transactie aanmaken
        public static DbTransaction BeginTransaction()
        {
            DbConnection con = null;
            try
            {
                //connectie opvragen
                con = GetConnection();
                //connectie instellen
                return con.BeginTransaction();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        //stap6: command binnen een transactie aanmaken

        private static DbCommand BuildCommand(DbTransaction trans, String sql, params DbParameter[] parameters)
        {
            DbCommand command = BeginTransaction().Connection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = sql;
            command.Transaction = trans;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return command;
        }

        //stap 7A: select binnen een transactie
        public static DbDataReader GetData(DbTransaction trans ,string sql, params DbParameter[] parameters)
        {
            //boodschappenlijstje aanmaken met methode van hierboven
            DbCommand command = BuildCommand(trans,sql, parameters);
            DbDataReader reader = null;
            try
            {
                //datareader opvragen. als de reader alle informatie doorlopen heeft, wordt automatisch 
                //de connectie gesloten
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                if (reader != null) reader.Close();
                if (command != null) RelaseConnection(command.Connection);
                throw ex; //fout doorgeven aan de aanroepende methode
            }
        }


        public static int ModifyData(DbTransaction trans, String sql, params DbParameter[] parameters)
        {
            DbCommand command = BuildCommand(trans, sql, parameters);
            try
            {
                int aantalGewijzigdeRijen = command.ExecuteNonQuery();
                return aantalGewijzigdeRijen;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (command != null) RelaseConnection(command.Connection);
                throw ex;
            }
        }



    }
}
