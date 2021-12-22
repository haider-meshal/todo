using System;
using MediatR;

namespace ToDo.API.Commands
{
    public class UpdateTodoCommand : IRequest<UpdateTodoCommandResult>
    {
        public int id { get; set; }
        public string todo { get; set; }

        public UpdateTodoCommand(int id, string todo){
          this.id = id;
          this.todo = todo;
        }
    }

    public class UpdateTodoCommandResult
    {
        public string result { get; set; }
    }
}
