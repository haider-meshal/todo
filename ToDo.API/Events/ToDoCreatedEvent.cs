namespace ToDo.API.Events
{
    public class ToDoCreatedEvent : Event
    {
        public int id { get; set; }
        public string todo { get; set; }
        public int status { get; set; }

        public ToDoCreatedEvent(int id, string todo, int status){
          this.id = id;
          this.todo = todo;
          this.status = status;
        }
    }
}
