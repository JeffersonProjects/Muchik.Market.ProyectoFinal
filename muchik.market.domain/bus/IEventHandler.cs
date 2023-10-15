using muchik.market.domain.events;

namespace muchik.market.domain.bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler { }
}
