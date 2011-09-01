using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EnergyCAP
{
    /// <summary>
    /// Data access layer that handles transactions between the database and the web layer.
    /// </summary>
    public class DataAccessLayer
    {
        /// <summary>
        /// Connection string.
        /// </summary>
        protected static string connectionStr
        {
            get { return ConfigurationManager.ConnectionStrings["energycapConnectionString"].ConnectionString; }
        }

        /// <summary>
        /// SQL script to retrieve the list of buildings and associated data from the database.
        /// </summary>
        protected static readonly string sqlGetBuildings = @"SELECT [BuildingID], [BuildingCode], [BuildingName] FROM [tblBuilding] ORDER BY [BuildingName]";

        /// <summary>
        /// SQL script to retrieve the list of meters and associated data from the database, given a building ID.
        /// </summary>
        protected static readonly string sqlGetMeters = @"SELECT [MeterInfoID], [MeterCode], [MeterName], [MeterSerial] FROM [tblMeterInfo] " + 
            "WHERE [tblMeterInfo].[buildingID] = @buildingID ORDER BY [MeterCode]";

        /// <summary>
        /// SQL script to retrieve the list of bills and associated data from the database, given a meter ID.
        /// </summary>
        protected static readonly string sqlGetBills = @"SELECT [BillMtrID], [MtrCost], [MtrUse], [MtrBDem], [MtrADem], [MtrStartDate], [MtrEndDate], " +
            "[ReportYear], [ReportMonth] FROM [tblBillMtr] WHERE [tblBillMtr].[MeterInfoID] = @MeterInfoID ORDER BY [BillMtrID]";

        /// <summary>
        /// SQL script to retrieve a single building name given the ID.
        /// </summary>
        protected static readonly string sqlGetBuildingName = @"SELECT [BuildingName] FROM [tblBuilding] WHERE [buildingID] = @buildingID";

        /// <summary>
        /// SQL script to retrieve a single meter name given the ID.
        /// </summary>
        protected static readonly string sqlGetMeterName = @"SELECT [MeterName] FROM [tblMeterInfo] WHERE [MeterInfoID] = @MeterInfoID";

        /// <summary>
        /// Prevents instantiation.
        /// </summary>
        private DataAccessLayer() { }

        /// <summary>
        /// Queries the database for the current list of buildings.
        /// </summary>
        /// <returns>A DataTable containing the query results.</returns>
        public static DataTable getBuildings()
        {
            return executeQuery(sqlGetBuildings, null);
        }

        /// <summary>
        /// Queries the database for the current list of buildings.
        /// </summary>
        /// <returns>A DataTable containing the query results.</returns>
        public static DataTable getMeters(params SqlParameter[] buildingID)
        {
            return executeQuery(sqlGetMeters, buildingID);
        }

        /// <summary>
        /// Queries the database for the current list of buildings.
        /// </summary>
        /// <returns>A DataTable containing the query results.</returns>
        public static DataTable getBills(params SqlParameter[] meterID)
        {
            return executeQuery(sqlGetBills, meterID);
        }

        /// <summary>
        /// Queries the database for a single building name, given the building ID.
        /// </summary>
        /// <param name="buildingID">The building ID.</param>
        /// <returns>A string containing the query results.</returns>
        public static string getBuildingName(params SqlParameter[] buildingID)
        {
            return executeScalarQuery(sqlGetBuildingName, buildingID);
        }

        /// <summary>
        /// Queries the database for a single building name, given the building ID.
        /// </summary>
        /// <param name="buildingID">The building ID.</param>
        /// <returns>A string containing the query results.</returns>
        public static string getMeterName(params SqlParameter[] meterID)
        {
            return executeScalarQuery(sqlGetMeterName, meterID);
        }

        /// <summary>
        /// Executes the selected SQL query in order to receive a result table.
        /// </summary>
        /// <param name="queryString">The query string to execute.</param>
        /// <param name="paramsArray">SQL query parameters.</param>
        /// <returns>A DataTable containing the query results.</returns>
        protected static DataTable executeQuery(string queryString, params SqlParameter[] paramsArray)
        {
            // Initialize the DB connection
            SqlConnection connection = new SqlConnection(connectionStr);

            // Initialize the command
            SqlCommand sqlCommand = new SqlCommand(queryString, connection);
            DataTable dt = new DataTable();

            // Open the connection
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }

            // Add the parameters to the command
            if (paramsArray != null)
            {
                foreach (SqlParameter param in paramsArray)
                {
                    sqlCommand.Parameters.Add(param);
                }
            }

            try
            {
                // Execute the query
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Cleanup
                sqlCommand.Dispose();
                connection.Close();
            }
        }

        /// <summary>
        /// Executes the selected SQL query in order to retrieve a single result.
        /// </summary>
        /// <param name="queryString">The query string to execute.</param>
        /// <param name="paramsArray">SQL query parameters.</param>
        /// <returns>A string containing the query results.</returns>
        protected static String executeScalarQuery(string queryString, params SqlParameter[] paramsArray)
        {
            // Initialize the DB connection
            SqlConnection connection = new SqlConnection(connectionStr);

            // Init result string
            string result = string.Empty;

            // Initialize the command
            SqlCommand sqlCommand = new SqlCommand(queryString, connection);
            DataTable dt = new DataTable();

            // Open the connection
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }

            // Add the parameters to the command
            if (paramsArray != null)
            {
                foreach (SqlParameter param in paramsArray)
                {
                    sqlCommand.Parameters.Add(param);
                }
            }

            try
            {
                // Execute the query
                result = (String)sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Cleanup
                sqlCommand.Dispose();
                connection.Close();
            }

            return result;
        }
    }
}