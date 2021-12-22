namespace ToDo.API.Events
{
    public class ToDoRemovedEvent : Event
    {
        public int id { get; set; }

        public ToDoRemovedEvent(int id){
          this.id = id;
        }
    }
}
