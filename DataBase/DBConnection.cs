using Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DataBase
{
    public class DBConnection : Connection
    {
        NpgsqlConnection conn;
        NpgsqlCommand getObjListDB;
        NpgsqlCommand addObjDB;
        NpgsqlCommand updObjDB;
        NpgsqlCommand delObjDB;
        NpgsqlCommand getObjDB;
        public DBConnection() { }

        public Obj GetElement(String Name)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            getObjDB = new NpgsqlCommand("SELECT FROM Objs WHERE \"name\"=@n", conn);
            conn.Open();
            getObjDB.Parameters.AddWithValue("n", Name);
            var reader =  getObjDB.ExecuteReader();
            Obj temp = null;
            while (reader.Read())
            {
                temp = new Obj((string)reader[0], (string)reader[1]);
                break;
            }
            reader.Close();
            conn.Close();
            return temp;
        }
        public void AddElement(Obj obj)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            addObjDB = new NpgsqlCommand("INSERT INTO Objs (name, enum) VALUES (@n, @p)", conn);
            conn.Open();
            addObjDB.Parameters.AddWithValue("n", obj.Name);
            addObjDB.Parameters.AddWithValue("p", obj.Enum);
            addObjDB.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdElement(Obj obj)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            updObjDB = new NpgsqlCommand("UPDATE Objs SET name = @n, enum = @p WHERE name = @n", conn);
            conn.Open();
            updObjDB.Parameters.AddWithValue("n", obj.Name);
            addObjDB.Parameters.AddWithValue("p", obj.Enum);
            updObjDB.ExecuteReader().Close();
            conn.Close();
        }

        public void DelElement(String Name)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            delObjDB = new NpgsqlCommand("DELETE FROM Objs WHERE \"name\"=@n", conn);
            conn.Open();
            delObjDB.Parameters.AddWithValue("n", Name);
            delObjDB.ExecuteReader().Close();
            conn.Close();
        }

        public List<Obj> GetList()
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=2891;Database=kop;");
            getObjListDB = new NpgsqlCommand("SELECT * FROM Objs", conn);
            conn.Open();
            var reader = getObjListDB.ExecuteReader();
            var result = new List<Obj>();
            while (reader.Read())
            {
                result.Add(new Obj(reader[0].ToString(), reader[1].ToString()));
            }
            reader.Close();
            conn.Close();
            return result;
        }
    }
}
