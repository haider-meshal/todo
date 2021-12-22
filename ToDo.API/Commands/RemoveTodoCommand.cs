using System;
using MediatR;

namespace ToDo.API.Commands
{
    public class RemoveTodoCommand : IRequest<RemoveTodoCommandResult>
    {
        public int id { get; set; }
    }

    public class RemoveTodoCommandResult
    {
        public string result { get; set; }
    }
}
