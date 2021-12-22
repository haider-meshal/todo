//using System.Data.SqlClient;
using MediatR;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using ToDo.API.Commands;
using ToDo.API.Events;

namespace ToDo.API.ModelWrite
{
    public interface ITodoWriter{
       void write(CreateTodoCommand command);
       void write(UpdateTodoCommand command);
       void write(RemoveTodoCommand command);
       void write(UpdateTodoStatusCommand command);
    }

    public class TodoWriter: ITodoWriter
    {
        private readonly IMediator mediator;
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private const string CONN_STRING = "Data Source=database.db;Version=3;New=True;Compress=True;";
        //"Data Source=:memory:";

        public TodoWriter(IMediator mediator){
            this.mediator = mediator;
            conn = new SQLiteConnection(CONN_STRING);
            conn.Open();
            cmd = new SQLiteCommand(conn);
            cmd.CommandText = "DROP TABLE IF EXISTS event_store";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"
                CREATE TABLE event_store(
                    id INTEGER PRIMARY KEY,
                    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
                    squence INTEGER,
                    version INTEGER,
                    name TEXT,
                    aggregate_id TEXT,
                    data TEXT,
                    aggregate TEXT)
            ";
            cmd.ExecuteNonQuery();
        }

        public void write(CreateTodoCommand cmd){

            this.mediator.Publish(new ToDoCreatedEvent(0,cmd.todo,cmd.status));
        }

        public void write(RemoveTodoCommand cmd){
            this.mediator.Publish(new ToDoRemovedEvent(cmd.id));
        }

        public void write(UpdateTodoCommand cmd){
            this.mediator.Publish(new ToDoUpdatedEvent(cmd.id,cmd.todo));
        }

        public void write(UpdateTodoStatusCommand cmd){
            this.mediator.Publish(new ToDoStatusUpdatedEvent(cmd.id,cmd.status));
        }
    }
}
