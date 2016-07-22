using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// Contiene utilidades que se usan en toda la aplicación.
    /// </summary>
   public class Utility
    {
        /// <summary>
        /// Obtiene el nuevo índice
        /// </summary>
        /// <param name="field">Campo para el nuevo índice en la base de datos</param>
        /// <param name="table">Tabla que contiene el índice</param>
        /// <returns>El índice mayor más uno</returns>
        public string getNewIndex(string field, string table)
        {
            ConnectDB connection = new ConnectDB();
            int lastIndex;
            string query = "SELECT MAX(" + field + ") FROM " + table;
            string dbIndex = connection.executeScalar(query).ToString();
            if (int.TryParse(dbIndex, out lastIndex))
            {
                lastIndex += 1;
                return lastIndex.ToString();
            }
            else
                return lastIndex.ToString();

        }

        /// <summary>
        /// Obtiene la hora de una base de datos de oracle
        /// </summary>
        /// <returns>la fecha y hora actual</returns>
        public string getOraDate()
        {
            ConnectDB connection = new ConnectDB();
            string query = "SELECT TO_CHAR(SYSDATE, 'MM/DD/YYYY HH24:MI:SS') \"NOW\" FROM DUAL";
            string date = connection.executeScalar(query).ToString();
            return date;
        }

        /// <summary>
        /// Arregla la cadena para insertar fecha en base de datos oracle
        /// </summary>
        /// <returns>La cadena de la fecha</returns>
        public string fixDateForDB()
        {
            ConnectDB connection = new ConnectDB();
            string query = "SELECT TO_CHAR(SYSDATE, 'MM/DD/YYYY HH24:MI:SS') \"NOW\" FROM DUAL";
            string date = connection.executeScalar(query).ToString();
            string dateFixed = "TO_DATE('" + date + "','DD/MM/YYYY HH24:MI:SS'" + ")";
            return dateFixed;
        }

    }

