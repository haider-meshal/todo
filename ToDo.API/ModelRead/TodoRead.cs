namespace ToDo.API.ModelRead
{
    public class TodoRead{
        public int id { get; set; }
        public string todo { get; set; }
        public int status { get; set; }

        public TodoRead(){
        }

        public TodoRead(int id, string todo, int status){
          this.id = id;
          this.todo = todo;
          this.status = status;
        }
    }
}
