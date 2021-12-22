//using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace ToDo.API.ModelRead
{
    public interface ITodoReader{
        TodoRead[] GetAll();
        TodoRead[] Get(int id);
        void Create(string todo);
        void Remove(int id);
        void Update(int id, string todo);
        void UpdateStatus(int id, int status);
    }

    public class TodoReader: ITodoReader
    {
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private const string CONN_STRING = "Data Source=database.db;Version=3;New=True;Compress=True;";
        //"Data Source=:memory:";
        private const string QUERY = "SELECT Id, Todo, Status FROM todo";

        public TodoReader(){
            conn = new SQLiteConnection(CONN_STRING);
            conn.Open();
            cmd = new SQLiteCommand(conn);
            cmd.CommandText = "DROP TABLE IF EXISTS todo";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE todo(id INTEGER PRIMARY KEY,todo TEXT, status INT)";
            cmd.ExecuteNonQuery();
        }

        public TodoRead[] GetAll()
        {

            return conn.Query<TodoRead>(QUERY).ToArray();
        }

        public TodoRead[] Get(int id)
        {
             return Array.FindAll(conn.Query<TodoRead>(QUERY).ToArray(), element => element.id == id);
        }

        public void Create(string todo){
          SQLiteCommand cmd = new SQLiteCommand(conn);
          cmd.CommandText = "INSERT INTO todo(todo, status) VALUES(@todo, @status)";
          cmd.Parameters.AddWithValue("@todo", todo);
          cmd.Parameters.AddWithValue("@status", 0);
          cmd.Prepare();
          cmd.ExecuteNonQuery();
        }

        public void Remove(int id){
          SQLiteCommand cmd = new SQLiteCommand(conn);
          cmd.CommandText = "DELETE FROM todo WHERE id = @id";
          cmd.Parameters.AddWithValue("@id", id);
          cmd.Prepare();
          cmd.ExecuteNonQuery();
        }

        public void Update(int id, string todo){
          SQLiteCommand cmd = new SQLiteCommand(conn);
          cmd.CommandText = "UPDATE todo SET todo = @todo WHERE id = @id";
          cmd.Parameters.AddWithValue("@id", id);
          cmd.Parameters.AddWithValue("@todo", todo);
          cmd.Prepare();
          cmd.ExecuteNonQuery();
        }

        public void UpdateStatus(int id, int status){
          SQLiteCommand cmd = new SQLiteCommand(conn);
          cmd.CommandText = "UPDATE todo SET status = @status WHERE id = @id";
          cmd.Parameters.AddWithValue("@id", id);
          cmd.Parameters.AddWithValue("@status", status);
          cmd.Prepare();
          cmd.ExecuteNonQuery();
        }
    }
}
