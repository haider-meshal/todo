using System;
using MediatR;
using ToDo.API.ModelWrite;

namespace ToDo.API.Commands
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreateTodoCommandResult>
    {
          private ITodoWriter modelWriter;

          public CreateTodoCommandHandler(ITodoWriter modelWriter){
            this.modelWriter = modelWriter;
          }

          public Task<CreateTodoCommandResult> Handle(CreateTodoCommand request, CancellationToken cancellationToken){
            this.modelWriter.write(request);
            return Task.FromResult
            (
               new CreateTodoCommandResult {
                  result = "Added to EventStore: CreateTodoEvent"
               }
            );
          }
    }

    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, UpdateTodoCommandResult>
    {
          private ITodoWriter modelWriter;

          public UpdateTodoCommandHandler(ITodoWriter modelWriter){
            this.modelWriter = modelWriter;
          }

          public Task<UpdateTodoCommandResult> Handle(UpdateTodoCommand request, CancellationToken cancellationToken){
            this.modelWriter.write(request);
            return Task.FromResult
            (
               new UpdateTodoCommandResult {
                  result = "Added to EventStore: UpdateTodoEvent"
               }
            );
          }
    }

    public class RemoveTodoCommandHandler : IRequestHandler<RemoveTodoCommand, RemoveTodoCommandResult>
    {

          private ITodoWriter modelWriter;

          public RemoveTodoCommandHandler(ITodoWriter modelWriter){
            this.modelWriter = modelWriter;
          }
          public Task<RemoveTodoCommandResult> Handle(RemoveTodoCommand request, CancellationToken cancellationToken){
            this.modelWriter.write(request);
            return Task.FromResult
            (
               new RemoveTodoCommandResult {
                  result = "Added to EventStore: RemoveTodoEvent"
               }
            );
          }
    }

    public class UpdateTodoStatusCommandHandler : IRequestHandler<UpdateTodoStatusCommand, UpdateTodoStatusCommandResult>
    {
          private ITodoWriter modelWriter;

          public UpdateTodoStatusCommandHandler(ITodoWriter modelWriter){
            this.modelWriter = modelWriter;
          }

          public Task<UpdateTodoStatusCommandResult> Handle(UpdateTodoStatusCommand request, CancellationToken cancellationToken){
            this.modelWriter.write(request);
            return Task.FromResult
            (
               new UpdateTodoStatusCommandResult
               {
                  result = "Added to EventStore: UpdateTodoStatusEvent"
               }
            );
          }
    }
}
