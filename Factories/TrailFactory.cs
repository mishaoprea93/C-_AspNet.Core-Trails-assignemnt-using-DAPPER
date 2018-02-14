using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using lost_in_woods.Models;
using MySql.Data.MySqlClient;

namespace lost_in_woods.Factories {
    public class TrailFactory {
        static string server = "localhost";
        static string db = "Trail"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection ($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
        public List<Trail> AllTrails(){
            using (IDbConnection dbConnection = Connection){
                string query="SELECT * FROM trails";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }
        public void AddNewTrail (Trail trail) {
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO trails (trailname,description,traillength,elevation,longitutde,latitude,created_at,updated_at) VALUES (@TrailName,@Description,@TrailLength,@Elevation,@Longitude,@Latitude,Now(),Now())";
                dbConnection.Open ();
                dbConnection.Execute (query,trail);
            }
        }

        public List<Trail> ShowOne(int id){
            using (IDbConnection dbConnection = Connection) {
                string query=$"SELECT * FROM trails WHERE id={id}";
                dbConnection.Open ();
                return dbConnection.Query<Trail>(query).ToList();
            }
        }
}
}