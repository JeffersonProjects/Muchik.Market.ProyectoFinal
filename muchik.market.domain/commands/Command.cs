using muchik.market.domain.events;

namespace muchik.market.domain.commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command() 
        {
            Timestamp = DateTime.Now;
        }
    }
}
