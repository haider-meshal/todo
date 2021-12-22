using System;
using MediatR;

namespace ToDo.API.Commands
{
    public class UpdateTodoStatusCommand : IRequest<UpdateTodoStatusCommandResult>
    {
        public int id { get; set; }
        public int status { get; set; }
    }

    public class UpdateTodoStatusCommandResult
    {
        public string result { get; set; }
    }
}
