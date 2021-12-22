using System;
using MediatR;
using ToDo.API.ModelRead;

namespace ToDo.API.Queries
{
    public class GetTodoQuery : IRequest<GetTodoQueryResult>
    {
        public int id { get; set; }
    }

    public class GetTodoQueryResult
    {
        public TodoRead[] todo { get; set; }
    }
}
