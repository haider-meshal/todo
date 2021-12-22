using System;
using MediatR;

namespace ToDo.API.Commands
{
    public class CreateTodoCommand : IRequest<CreateTodoCommandResult>
    {
        public string todo { get; set; }
        //0: todo, 1: doing, 2: done
        public int status { get; set; }

        public CreateTodoCommand(string todo){
          this.todo = todo;
        }
    }

    public class CreateTodoCommandResult
    {
        public string result { get; set; }
    }
}
