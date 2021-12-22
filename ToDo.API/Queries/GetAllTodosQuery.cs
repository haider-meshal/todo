using System;
using MediatR;
using ToDo.API.ModelRead;

namespace ToDo.API.Queries
{
    public class GetAllTodosQuery : IRequest<GetAllTodosQueryResult>
    {

    }

    public class GetAllTodosQueryResult
    {
        public TodoRead[] todos { get; set; }
    }
}
