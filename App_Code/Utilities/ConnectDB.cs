using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Diagnostics;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Collections;

    /// <summary>
    /// Maneja las funciones básicas de base de datos CRUD y la conexión
    /// </summary>
    public class ConnectDB
    {
        TextWriterTraceListener myTraceListener = new TextWriterTraceListener("trace1.log", "myTraceListener");

        /// <summary>
        /// Obtiene la cadena de conexión del app.config
        /// </summary>
        /// <returns>Una conexión lista para ser usada</returns>
        public OleDbConnection getConnectionString()
        {
            Decryption dec = new Decryption();
            OleDbConnection connection = new OleDbConnection();
            //Obtiene la cadena de conexión y la desencripta
            connection.ConnectionString = dec.decryption(ConfigurationManager.ConnectionStrings["tests"].ToString());
            return connection;
        }

        /// <summary>
        /// Ejecuta consulta de select
        /// </summary>
        /// <param name="query">La consulta</param>
        /// <returns>Datatable con el resultadao</returns>
        public System.Data.DataTable executeQuery(String query)
        {
            DataTable table = new DataTable();
            OleDbConnection connection = getConnectionString();
            using (connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(query, connection);
                    table.Load(command.ExecuteReader());
                    return table;
                }
                catch (Exception ex)
                {
                    
                    myTraceListener.WriteLine("Ocurrió un error durante la consulta a la base de datos " + ex.ToString());
                    return table;
                }
                finally
                {
                    myTraceListener.Flush();
                    myTraceListener.Dispose();
                }
            }
        }

        /// <summary>
        /// Revisa si la consulta devuelve algún valor
        /// </summary>
        /// <param name="query">consulta a realizar</param>
        /// <returns>Verdadero si devuelve algún valor</returns>
        public Boolean returnValue(String query)
        {
            OleDbConnection connection = getConnectionString();
            using (connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(query, connection);
                    if (command.ExecuteReader().HasRows)
                    {
                       
                        return true;
                    }
                    else
                    {
                       
                        return false;
                    }
                }
                catch (Exception ex)
                {
                   
                    myTraceListener.WriteLine("Ocurrió un error durante la consulta a la base de datos " + ex.ToString());
                    return false;
                }
                finally
                {
                    myTraceListener.Flush();
                    myTraceListener.Dispose();
                }

            }
        }


        /// <summary>
        /// Realiza consulta que devuelve un solo valor
        /// </summary>
        /// <param name="query">Consulta a realizar</param>
        /// <returns>El valor obtenido con la consulta</returns>
        public object executeScalar(string query)
        {
            OleDbConnection connection = getConnectionString();
            using (connection)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(query, connection);
                    return command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    
                    myTraceListener.WriteLine("Ocurrió un error durante la consulta a la base de datos " + ex.ToString());
                    return false;
                }
                finally
                {
                    myTraceListener.Flush();
                    myTraceListener.Dispose();
                }
            }
        }

        /// <summary>
        /// Realiza una actualización a la base de datos utilizando transacciones
        /// </summary>
        /// <param name="query"></param>
        /// <returns>numero de filas afectadas</returns>
        public int transactInsertOrUpdate(ArrayList queryList)
        {
            OleDbConnection connection = getConnectionString();
            OleDbTransaction transaction = null;
            OleDbCommand command;
            int rowsAffected = 0;
            String result = "";
            using (connection)
            {
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    foreach (String query in queryList)
                    {
                        command = new OleDbCommand(query, connection);
                        command.Transaction = transaction;
                        rowsAffected += command.ExecuteNonQuery();
                        result = query;

                    }
                    transaction.Commit();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                  
                    myTraceListener.WriteLine("Ocurrió un error durante la consulta a la base de datos " + ex.ToString());
                    try
                    {
                        transaction.Rollback();
                        myTraceListener.WriteLine("Rollbacked" + result);
                    }
                    catch
                    {
                        myTraceListener.WriteLine("Es posible no se hubiere efectuado el rollback");
                        //Transacción ya no está activa

                    }
                    return rowsAffected;
                }
                finally
                {
                    myTraceListener.Flush();
                    myTraceListener.Dispose();
                }
            }


        }

        /// <summary>
        /// Convierte un string en un array para poder ser utilizado en el método transactInsertOrUpdate
        /// </summary>
        /// <param name="query">Cadena a agregar</param>
        /// <returns>El array con la cadena agregada</returns>
        public ArrayList convertToArray(String query) 
        {
            ArrayList array = new ArrayList();
            array.Add(query);
            return array;
        }

    }

