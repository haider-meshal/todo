using MediatR;

namespace ToDo.API.Events
{
   public class Event : INotification
   {
       public Guid EventId;
       public int Version;
       public Event() {
           EventId = Guid.NewGuid();
       }
   }
}

