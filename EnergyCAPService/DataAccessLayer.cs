using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EnergyCAPService
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
        protected static readonly string sqlGetBuildings = @"SELECT [BuildingID], [BuildingCode], [BuildingName], [BuildingMemo] FROM [tblBuilding] ORDER BY [BuildingName]";

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
        /// SQL script to retrive the details for a particular building.
        /// </summary>
        protected static readonly string sqlGetBuidlingDetails = @"SELECT [BuildingID], [BuildingCode], [BuildingName], [BuildingMemo] FROM [tblBuilding] " +
            "WHERE [tblBuilding].[buildingID] = @buildingID";

        /// <summary>
        /// SQL script to update the details of a particular building.
        /// </summary>
        protected static readonly string sqlUpdateBuildingDetails = @"UPDATE [tblBuilding] SET [BuildingCode] = @BuildingCode, [BuildingName] = @BuildingName, " +
            " [BuildingMemo] = @BuildingMemo WHERE [tblBuilding].[buildingID] = @buildingID";

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
        /// <param name="parameters">The building ID.</param>
        /// <returns>A DataTable containing the query results.</returns>
        public static DataTable getMeters(params SqlParameter[] parameters)
        {
            return executeQuery(sqlGetMeters, parameters);
        }

        /// <summary>
        /// Queries the database for the current list of buildings.
        /// </summary>
        /// <param name="parameters">The meter ID.</param>
        /// <returns>A DataTable containing the query results.</returns>
        public static DataTable getBills(params SqlParameter[] parameters)
        {
            return executeQuery(sqlGetBills, parameters);
        }

        /// <summary>
        /// Queries the database for a single building details, given the building ID.
        /// </summary>
        /// <param name="buildingID">The building ID.</param>
        /// <returns>A DataTable containing the query results.</returns>
        public static DataTable getBuildingDetails(params SqlParameter[] parameters)
        {
            return executeQuery(sqlGetBuidlingDetails, parameters);
        }

        /// <summary>
        /// Queries the database for a single building name, given the building ID.
        /// </summary>
        /// <param name="buildingID">The building ID.</param>
        /// <returns>A string containing the query results.</returns>
        public static string getBuildingName(params SqlParameter[] parameters)
        {
            return executeScalarQuery(sqlGetBuildingName, parameters);
        }

        /// <summary>
        /// Queries the database for a single building name, given the building ID.
        /// </summary>
        /// <param name="buildingID">The building ID.</param>
        /// <returns>A string containing the query results.</returns>
        public static string getMeterName(params SqlParameter[] parameters)
        {
            return executeScalarQuery(sqlGetMeterName, parameters);
        }

        /// <summary>
        /// Updates values for a particular building in the buildings table.
        /// </summary>
        /// <param name="parameters">The building ID.</param>
        /// <returns>The number of rows affected. Should always be 1 if only one building is affected.</returns>
        public static int updateBuildingDetails(params SqlParameter[] parameters)
        {
            return executeNonQuery(sqlUpdateBuildingDetails, parameters);
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

        /// <summary>
        /// Executes the selected SQL query in order to modify rows in a database table (i.e. DELETE or UPDATE).
        /// </summary>
        /// <param name="queryString">The query string to execute.</param>
        /// <param name="paramsArray">SQL query parameters.</param>
        /// <returns>The number of rows affected.</returns>
        protected static int executeNonQuery(string queryString, params SqlParameter[] paramsArray)
        {
            // Initialize the DB connection
            SqlConnection connection = new SqlConnection(connectionStr);

            // Init return value
            int numRowsAffected = 0;

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
                // Execute the command
                numRowsAffected = (int)sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string test = ex.Message;
            }
            finally
            {
                // Cleanup
                sqlCommand.Dispose();
                connection.Close();
            }

            // Return the number of rows affected
            return numRowsAffected;
        }
    }
}