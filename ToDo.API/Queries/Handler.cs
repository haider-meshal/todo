using System;
using MediatR;
using ToDo.API.ModelRead;

namespace ToDo.API.Queries
{
    public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, GetAllTodosQueryResult>
    {
          private ITodoReader modelReader;

          public GetAllTodosQueryHandler(ITodoReader modelReader){
              this.modelReader = modelReader;
          }

          public Task<GetAllTodosQueryResult> Handle(GetAllTodosQuery request, CancellationToken cancellationToken){
            return Task.FromResult
            (
               new GetAllTodosQueryResult {
                  todos = this.modelReader.GetAll()
               }
            );
          }
    }

    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, GetTodoQueryResult>
    {
          private ITodoReader modelReader;

          public GetTodoQueryHandler(ITodoReader modelReader){
              this.modelReader = modelReader;
          }

          public Task<GetTodoQueryResult> Handle(GetTodoQuery request, CancellationToken cancellationToken){
            return Task.FromResult
            (
               new GetTodoQueryResult {
                  todo = this.modelReader.Get(request.id)
               }
            );
          }
    }
}
