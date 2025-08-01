using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;

namespace ZooApp
{
    public static class DatabaseHelper
    {
        // Default prefix for M2S_ tables; can be updated at login
        private static string currentTablePrefix = "M2S";

		// TODO: add your own connection string
        // Change this to your actual connection string
        public static string connectionString = "";

        // Used to switch between datasets (M2S, M21, etc.)
        public static void SetTablePrefix(string prefix)
        {
            currentTablePrefix = prefix;
        }

        // Returns a table name like "M2S_ANIMAL"
        public static string Table(string baseName)
        {
            return $"{currentTablePrefix}_{baseName}";
        }

        // Takes a DateTime class, and converts it to equivalent SQL string
        public static string ConvertDateTimeToSQLString(DateTime toConvert)
        {
            return toConvert.ToString("yyyy-MM-dd");
        }

        /**<summary>
         * Executes a Query on the database.
         * </summary>
         * <param name="query">The Query String.</param>
         * <param name="parameters">A list of OracleParameters. Can be null</param>
         * <returns>A DataTable containg query results.</returns>
         */
        public static DataTable ExecuteQuery(string query, OracleParameter[] parameters = null)
        {
            DataTable dt = new DataTable();

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }


        // Executes INSERT, UPDATE, or DELETE with parameters
        public static void ExecuteNonQuery(string query, OracleParameter[] parameters = null)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Tests if database connection is valid
        public static bool TestConnection()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
