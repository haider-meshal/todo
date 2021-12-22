namespace ToDo.API.Events
{
    public class ToDoStatusUpdatedEvent : Event
    {
        public int id { get; set; }
        public int status { get; set; }

        public ToDoStatusUpdatedEvent(int id, int status){
          this.id = id;
          this.status = status;
        }
    }
}
