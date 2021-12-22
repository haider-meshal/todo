namespace ToDo.API.Events;
    public class ToDoUpdatedEvent : Event
    {
        public int id { get; set; }
        public string todo { get; set; }

        public ToDoUpdatedEvent(int id, string todo){
          this.id = id;
          this.todo = todo;
        }
    }
