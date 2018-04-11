using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UglyChinook
{
    class Program
    {
        static void Main(string[] args)
        {
//            Insert("레드벨벳");

            Delete(276);
            return;

//            List<Artist> artists = GetAllArtists2();
            List<Artist> artists = GetByName2("The");
            foreach (Artist artist in artists)
            {
                Console.WriteLine($"{artist.ArtistId} : {artist.Name}");
            }
        }

        private static List<Artist> GetAllArtists()
        {
            const string connectionString = "Data Source=10.10.14.100,1433;Initial Catalog=Chinook;User ID=vr;Password=vr"; 

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "select * from Artist";

            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            // reader 객체
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // reader 값을 읽는 코드
            List<Artist> artists = new List<Artist>();
            while (reader.Read())
            {
                int artistId = reader.GetInt32(0);
                string name = reader.GetString(1);

                Artist artist = new Artist();
                artist.ArtistId = artistId;
                artist.Name = name;

                artists.Add(artist);
            }

            reader.Close();

            return artists;
        }

        private static List<Artist> GetByName(string name)
        {
            const string connectionString = "Data Source=10.10.14.100,1433;Initial Catalog=Chinook;User ID=vr;Password=vr"; 

            SqlConnection connection = new SqlConnection(connectionString);

            string sql = $"select * from Artist where Name like '%{name}%'";

            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            // reader 객체
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // reader 값을 읽는 코드
            List<Artist> artists = new List<Artist>();
            while (reader.Read())
            {
                Artist artist = new Artist();
                artist.ArtistId = reader.GetInt32(0);;
                artist.Name = reader.GetString(1);

                artists.Add(artist);
            }

            reader.Close();

            return artists;
        }

        private static List<Artist> GetAllArtists2()
        {
            const string connectionString = "Data Source=10.10.14.100,1433;Initial Catalog=Chinook;User ID=vr;Password=vr"; 

            SqlConnection connection = new SqlConnection(connectionString);

            string procedure = "Artist_GetAll";

            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;

            // reader 객체
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // reader 값을 읽는 코드
            List<Artist> artists = new List<Artist>();
            while (reader.Read())
            {
                int artistId = reader.GetInt32(0);
                string name = reader.GetString(1);

                Artist artist = new Artist();
                artist.ArtistId = artistId;
                artist.Name = name;

                artists.Add(artist);
            }

            reader.Close();

            return artists;
        }

        private static List<Artist> GetByName2(string name)
        {
            const string connectionString = "Data Source=10.10.14.100,1433;Initial Catalog=Chinook;User ID=vr;Password=vr"; 

            SqlConnection connection = new SqlConnection(connectionString);

            string procedure = "Artist_GetByName";

            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            parameter.Value = name;
            command.Parameters.Add(parameter);
//            command.Parameters.Add(name);

            // reader 객체
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            // reader 값을 읽는 코드
            List<Artist> artists = new List<Artist>();
            while (reader.Read())
            {
                Artist artist = new Artist();
                artist.ArtistId = reader.GetInt32(0);;
                artist.Name = reader.GetString(1);

                artists.Add(artist);
            }

            reader.Close();

            return artists;
        }

        private static void Insert(string name)
        {
            const string connectionString = "Data Source=10.10.14.100,1433;Initial Catalog=Chinook;User ID=vr;Password=vr"; 

            SqlConnection connection = new SqlConnection(connectionString);

            string procedure = "Artist_Insert";

            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            parameter.Value = name;
            command.Parameters.Add(parameter);
//            command.Parameters.Add(name);

            // reader 객체
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }

        private static void Update(int artistId, string name)
        {
            const string connectionString = "Data Source=10.10.14.100,1433;Initial Catalog=Chinook;User ID=vr;Password=vr"; 

            SqlConnection connection = new SqlConnection(connectionString);

            string procedure = "Artist_Update";

            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter nameParam = new SqlParameter("@Name", SqlDbType.NVarChar);
            nameParam.Value = name;
            command.Parameters.Add(nameParam);

            SqlParameter artistIdParam = new SqlParameter("@ArtistId", SqlDbType.Int);
            artistIdParam.Value = artistId;
            command.Parameters.Add(artistIdParam);

//            command.Parameters.Add(name);

            // reader 객체
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }

        private static void Delete(int artistId)
        {
            const string connectionString = "Data Source=10.10.14.100,1433;Initial Catalog=Chinook;User ID=vr;Password=vr"; 

            SqlConnection connection = new SqlConnection(connectionString);

            string procedure = "Artist_Delete";

            SqlCommand command = new SqlCommand(procedure, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter artistIdParam = new SqlParameter("@ArtistId", SqlDbType.Int);
            artistIdParam.Value = artistId;
            command.Parameters.Add(artistIdParam);

//            command.Parameters.Add(name);

            // reader 객체
            connection.Open();
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
