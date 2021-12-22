using MediatR;
using ToDo.API.ModelRead;

namespace ToDo.API.Events
{
    public class Handler :
        INotificationHandler<ToDoCreatedEvent>,
        INotificationHandler<ToDoRemovedEvent>,
        INotificationHandler<ToDoStatusUpdatedEvent>,
        INotificationHandler<ToDoUpdatedEvent>
    {
        private ITodoReader modelReader;

        public Handler(ITodoReader modelReader){
          this.modelReader = modelReader;
        }

        public Task Handle(ToDoCreatedEvent @event, CancellationToken cancellationToken)
        {
            this.modelReader.Create(@event.todo);
            return Task.CompletedTask;
        }

        public Task Handle(ToDoRemovedEvent @event, CancellationToken cancellationToken)
        {
            this.modelReader.Remove(@event.id);
            return Task.CompletedTask;
        }

        public Task Handle(ToDoStatusUpdatedEvent @event, CancellationToken cancellationToken)
        {
            this.modelReader.UpdateStatus(@event.id, @event.status);
            return Task.CompletedTask;
        }

        public Task Handle(ToDoUpdatedEvent @event, CancellationToken cancellationToken)
        {
            this.modelReader.Update(@event.id, @event.todo);
            return Task.CompletedTask;
        }
    }
}
