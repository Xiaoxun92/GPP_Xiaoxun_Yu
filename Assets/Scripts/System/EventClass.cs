// Base classes for event system

public delegate void EventDelegate();
public delegate void EventDelegateWithMessage(EventMessage message);

public class EventMessage{
}

public class EventMessageSingle<T> : EventMessage {
    public T value;
}
