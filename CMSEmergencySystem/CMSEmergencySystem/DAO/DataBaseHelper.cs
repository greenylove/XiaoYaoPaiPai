
using CMSEmergencySystem.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CMSEmergencySystem
{
    public class DataBaseHelper
    {
        private ConnectionStringSettings settings;

        public DataRow loginUser(string userName, string Password)
        {

            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataRow userRow;
            string sqlText = "SELECT departmentID FROM Database1.dbo.CredentialDB WHERE Username=@userName AND userPW=@Password";

            Command.Parameters.Add("@userName", SqlDbType.VarChar, 100);
            Command.Parameters["@userName"].Value = userName;
            Command.Parameters.Add("@Password", SqlDbType.VarChar, 100);
            Command.Parameters["@Password"].Value = Password;

            Command.CommandText = sqlText;

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            SqlConnection Connection = new SqlConnection(connectionString);

            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(ds, "UserData");
            Connection.Close();

            if (ds.Tables["UserData"].Rows.Count != 0)
            {
                //Return the DataRow that contains the user information
                //so that the web form logic can check the user's role id.
                return ds.Tables["UserData"].Rows[0];
            }
            else
            {
                //Create an empty DataRow
                userRow = ds.Tables["UserData"].Rows.Add();
                //Set the empty DataRow's SystemUserRecordId 
                //field with a value of 0
                userRow["departmentId"] = 0;
                //Return the empty DataRow to the calling program
                return userRow;

            }

        } // end of login

        public DataTable getSearchIncident(string Query)
        {
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            
            Command.Parameters.Add("@Query", SqlDbType.VarChar, 100);
            Command.Parameters["@Query"].Value = Query;

            string sqlText = "SELECT * FROM Database1.dbo.IncidentManager " +
                             "WHERE IncidentID LIKE '%' + @Query + '%'" +
                             " OR incidentType LIKE '%' + @Query + '%'" +
                             " OR reporterName LIKE '%' + @Query + '%'" +
                             " OR Location LIKE '%' + @Query + '%'" +
                             " OR postalCode LIKE '%' + @Query + '%'" +
                             " OR mainDispatch LIKE '%' + @Query + '%'";



            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            SqlConnection Connection = new SqlConnection(connectionString);

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(ds, "searchResult");
            Connection.Close();
            return ds.Tables["searchResult"];
        }

        public DataTable getAllLocation()
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "SELECT * FROM Database1.dbo.IncidentManager";

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(DS, "getAllLocation");
            Connection.Close();
            return DS.Tables["getAllLocation"];

        }

        public DataTable getAllIncident()
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataSet Ds = new DataSet();

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);
            string sqlText = "SELECT * FROM  Database1.dbo.IncidentManager";

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(Ds, "allIncident");
            Connection.Close();
            return Ds.Tables["allIncident"];

        } // end of getAllIncident

        public DataTable getAllPendingIncident()
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataSet Ds = new DataSet();

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);
            string sqlText = "SELECT * FROM  Database1.dbo.IncidentManager Where Status = 'Pending' OR Status = 'Unresolved' OR Status IS NULL";

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(Ds, "Id");
            Connection.Close();
            return Ds.Tables["Id"];

        } // end of getAllPendingIncident


        public DataTable getAllResolvedIncident()
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataSet Ds = new DataSet();

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);
            string sqlText = "SELECT * FROM  Database1.dbo.IncidentManager Where Status = 'Resolved'";

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(Ds, "Id");
            Connection.Close();
            return Ds.Tables["Id"];

        } // end of getAllResolvedIncident


        public int updateIncidentStatus(int IncidentID, string Status)
        {

            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            int numOfRecordAffected = 0;

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);
            string sqlText = "UPDATE Database1.dbo.IncidentManager SET Status=@Status WHERE IncidentID=@IncidentID";

            Command.CommandText = sqlText;
            Command.Connection = Connection;

            Command.Parameters.Add("@IncidentID", SqlDbType.VarChar, 100);
            Command.Parameters["@IncidentID"].Value = IncidentID;

            Command.Parameters.Add("@Status", SqlDbType.VarChar, 100);
            Command.Parameters["@Status"].Value = Status;

            Connection.Open();
            numOfRecordAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return numOfRecordAffected;

        } // end of updateIncidentStatus


        public IncidentItem getOneIncident(int IncidentID)
        {
            //IncidentItem i;
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);
            string sqlText = "SELECT * FROM Database1.dbo.IncidentManager WHERE IncidentID=@IncidentID";


            Command.Parameters.Add("@IncidentID", SqlDbType.Int);
            Command.Parameters["@IncidentID"].Value = IncidentID;

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(ds, "getOneIncident");
            Connection.Close();
            DataTable oneIncident = ds.Tables["getOneIncident"];
            DateTime dateTime = Convert.ToDateTime(oneIncident.Rows[0]["dateTime"].ToString());
            string convertDateTime = dateTime.ToString();
            string reportPerson = oneIncident.Rows[0]["reporterName"].ToString();
            string typeOfIncident = oneIncident.Rows[0]["incidentType"].ToString();
            string location = oneIncident.Rows[0]["Location"].ToString();
            string mainDispatch = oneIncident.Rows[0]["mainDispatch"].ToString();
            string contactNo = oneIncident.Rows[0]["reportContact"].ToString();
            string postalCode = oneIncident.Rows[0]["postalCode"].ToString();
            string description = oneIncident.Rows[0]["incidentDesc"].ToString();
            string dt = oneIncident.Rows[0]["dateTime"].ToString();
            int newIncidentID = int.Parse(oneIncident.Rows[0]["incidentID"].ToString());
            // float lat = float.Parse(ds.Tables["Latitude"].ToString());
            //float lng = float.Parse(ds.Tables["Longitutde"].ToString());


            IncidentItem i = new IncidentItem(reportPerson, typeOfIncident, location, mainDispatch, contactNo
            , postalCode, description, 0, 0);
            i.DateTime = convertDateTime;
            i.NewIncidentID = newIncidentID;

            // i = loadItem(ds);
            return i;
            //return ds.Tables["Id"];
        }
        public IncidentItem loadItem(DataSet ds)
        {
            string reportPerson = ds.Tables["reporterName"].ToString();
            string typeOfIncident = ds.Tables["incidentType"].ToString();
            string location = ds.Tables["Location"].ToString();
            string mainDispatch = ds.Tables["mainDispatch"].ToString();
            string contactNo = ds.Tables["reportContact"].ToString();
            string postalCode = ds.Tables["postalCode"].ToString();
            string description = ds.Tables["incidentDesc"].ToString();
            string dt = ds.Tables["dateTime"].ToString();
            int newIncidentID = int.Parse(ds.Tables["incidentID"].ToString());
            float lat = float.Parse(ds.Tables["Latitude"].ToString());
            float lng = float.Parse(ds.Tables["Longitutde"].ToString());
            IncidentItem i = new IncidentItem(typeOfIncident, reportPerson, location, mainDispatch
           , contactNo, postalCode, description, lat, lng);
            return i;
        }
        public int AddSupportTypeDB(int IncidentID, int DepartmentID)
        {
            SqlCommand Command = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "INSERT INTO Database1.dbo.SupportType (IncidentID, DepartmentID) VALUES(@IncidentID, @DepartmentID)";

            Command.Parameters.Add("@IncidentID", SqlDbType.VarChar, 100);
            Command.Parameters["@IncidentID"].Value = IncidentID;

            Command.Parameters.Add("@DepartmentID", SqlDbType.VarChar, 100);
            Command.Parameters["@DepartmentID"].Value = DepartmentID;

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            SqlConnection Connection = new SqlConnection(connectionString);

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

            return DepartmentID;

        } // end of AddSupportType

        public DataTable getAllPendingIncidentDB()
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);
            string sqlText = "SELECT * FROM  Database1.dbo.IncidentManager Where Status = 'Pending' OR Status = 'Unresolved' OR Status IS NULL";

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(ds, "Id");
            Connection.Close();
            return ds.Tables["Id"];

        } // end of getAllPendingIncident
        public DataTable getAllResolvedIncidentDB()
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);
            string sqlText = "SELECT * FROM  Database1.dbo.IncidentManager Where Status = 'Resolved'";

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(ds, "Id");
            Connection.Close();
            return ds.Tables["Id"];

        } // end of getAllPendingIncident


        public void deleteOneIncident(int IncidentID)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);

            string sqlText = "DELETE FROM Database1.dbo.IncidentManager WHERE IncidentID=@IncidentID";
            Command.CommandText = sqlText;
            Command.Connection = Connection;

            Command.Parameters.Add("@IncidentID", SqlDbType.Int);
            Command.Parameters["@IncidentID"].Value = IncidentID;


            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }


        public DataTable getOneSupportType(int IncidentID)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "SELECT departmentName FROM Database1.dbo.SupportName " +
                             "JOIN Database1.dbo.SupportType " +
                             "ON Database1.dbo.SupportName.departmentID = Database1.dbo.SupportType.departmentID " +
                             "WHERE Database1.dbo.SupportType.IncidentID = @IncidentID";

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);

            Command.Parameters.Add("@IncidentID", SqlDbType.Int);
            Command.Parameters["@IncidentID"].Value = IncidentID;

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(DS, "SupportType");
            Connection.Close();
            return DS.Tables["SupportType"];

        }


        public DataTable getAllCategoryData()
        {

            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "SELECT * FROM Database1.dbo.CategoryList";

            Command.CommandText = sqlText;
            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(ds, "CategoryData");
            Connection.Close();
            return ds.Tables["CategoryData"];

        }

        public void addStatusLog(int IncidentID, string statusMessage)
        {

            SqlCommand Command = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "INSERT INTO Database1.dbo.StatusLog (IncidentID, statusMessage) VALUES(@IncidentID,@statusMessage)";

            Command.Parameters.Add("@IncidentID", SqlDbType.VarChar, 100);
            Command.Parameters["@IncidentID"].Value = IncidentID;
            Command.Parameters.Add("@statusMessage", SqlDbType.VarChar, 100);
            Command.Parameters["@statusMessage"].Value = statusMessage;

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            SqlConnection Connection = new SqlConnection(connectionString);

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        } // end of insertHobbies

        public int Create_Incident(IncidentItem i)
        {
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            int IncidentID = 0;
            string sqlText = "INSERT INTO Database1.dbo.IncidentManager (incidentType, reporterName, reportContact, Location, postalCode, mainDispatch, incidentDesc, Latitude, Longitude) OUTPUT INSERTED.IncidentID VALUES(@incidentType, @reporterName, @reportContact, @Location, @postalCode, @mainDispatch, @incidentDesc, @latitude, @longitude)";

            Command.Parameters.Add("@incidentType", SqlDbType.VarChar, 100);        //incidentType
            Command.Parameters["@incidentType"].Value = i.TypeOfIncident;

            Command.Parameters.Add("@reporterName", SqlDbType.VarChar, 100);        //reporterName
            Command.Parameters["@reporterName"].Value = i.ReportPerson;

            Command.Parameters.Add("@reportContact", SqlDbType.VarChar, 100);       //reportContact
            Command.Parameters["@reportContact"].Value = i.ContactNo;

            Command.Parameters.Add("@Location", SqlDbType.VarChar, 100);            //Location 
            Command.Parameters["@Location"].Value = i.Location;

            Command.Parameters.Add("@postalCode", SqlDbType.VarChar, 100);          //postalCode
            Command.Parameters["@postalCode"].Value = i.PostalCode;

            Command.Parameters.Add("@mainDispatch", SqlDbType.VarChar, 100);        //mainDispatch
            Command.Parameters["@mainDispatch"].Value = i.MainDispatch;

            Command.Parameters.Add("@incidentDesc", SqlDbType.VarChar, 100);        //description
            Command.Parameters["@incidentDesc"].Value = i.Description;

            Command.Parameters.Add("@latitude", SqlDbType.Float, 100);             //latitude
            Command.Parameters["@latitude"].Value = i.Latitude;

            Command.Parameters.Add("@longitude", SqlDbType.Float, 100);            //longitude
            Command.Parameters["@longitude"].Value = i.Longitude;

            Command.CommandText = sqlText;

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            SqlConnection Connection = new SqlConnection(connectionString);

            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            IncidentID = (int)Command.ExecuteScalar();
            Connection.Close();

            return IncidentID;
        }

        public void AddSupportType(int IncidentID, int DepartmentID)
        {
            SqlCommand Command = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "INSERT INTO Database1.dbo.SupportType (IncidentID, DepartmentID) VALUES(@IncidentID, @DepartmentID)";

            Command.Parameters.Add("@IncidentID", SqlDbType.VarChar, 100);
            Command.Parameters["@IncidentID"].Value = IncidentID;

            Command.Parameters.Add("@DepartmentID", SqlDbType.VarChar, 100);
            Command.Parameters["@DepartmentID"].Value = DepartmentID;

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            SqlConnection Connection = new SqlConnection(connectionString);

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        } // end of AddSupportType


        public DataTable getOneStatusLog(int IncidentID)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "SELECT statusMessage, dateTime FROM Database1.dbo.StatusLog " +
                             "WHERE IncidentID = @IncidentID";

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);

            Command.Parameters.Add("@IncidentID", SqlDbType.Int);
            Command.Parameters["@IncidentID"].Value = IncidentID;

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(DS, "Status");
            Connection.Close();
            return DS.Tables["Status"];

        }

        public void addMapLocation(int IncidentID, float Latitude, float Longitude)
        {
            SqlCommand Command = new SqlCommand();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "INSERT INTO Database1.dbo.MapManager (IncidentID, Latitude, Longitude) VALUES(@IncidentID, @Latitude, @Longitude)";

            Command.Parameters.Add("@IncidentID", SqlDbType.Int);
            Command.Parameters["@IncidentID"].Value = IncidentID;
            Command.Parameters.Add("@Longitude", SqlDbType.Float, 100);
            Command.Parameters["@Longitude"].Value = Longitude;
            Command.Parameters.Add("@Latitude", SqlDbType.Float, 100);
            Command.Parameters["@Latitude"].Value = Latitude;
            Command.CommandText = sqlText;

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            SqlConnection Connection = new SqlConnection(connectionString);

            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Command.ExecuteScalar();
            Connection.Close();


        } // end of addMapLocation

        public DataTable getOneMapLocation(string IncidentID)
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "SELECT * FROM Database1.dbo.MapManager " +
                             "WHERE IncidentID = @IncidentID";

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);

            Command.Parameters.Add("@IncidentID", SqlDbType.Int);
            Command.Parameters["@IncidentID"].Value = IncidentID;

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(DS, "getOneMapLocation");
            Connection.Close();
            return DS.Tables["getOneMapLocation"];

        }

            public DataTable getAllBombShelter()
        {
            SqlConnection Connection = new SqlConnection();
            SqlCommand Command = new SqlCommand();
            DataSet DS = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            string sqlText = "SELECT * FROM Database1.dbo.BombShelter";

            settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            string connectionString = settings.ConnectionString;
            Connection = new SqlConnection(connectionString);

            Command.CommandText = sqlText;
            Command.Connection = Connection;
            Adapter.SelectCommand = Command;

            Connection.Open();
            Adapter.Fill(DS, "getAllBombShelter");
            Connection.Close();
            return DS.Tables["getAllBombShelter"];

        }

    }
}