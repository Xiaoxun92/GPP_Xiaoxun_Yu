using System.Collections.Generic;

public class EventManager {

    static EventManager instance = null;

    public static EventManager GetInstance() {
        if (instance == null)
            instance = new EventManager();
        return instance;
    }

    Dictionary<EVENT_TYPE, EventDelegate> eventDelegateList = new Dictionary<EVENT_TYPE, EventDelegate>();
    Dictionary<EVENT_TYPE, EventDelegateWithMessage> eventDelegateWithMessageList = new Dictionary<EVENT_TYPE, EventDelegateWithMessage>();

    public void Register(EVENT_TYPE eventType, EventDelegate handler) {
        if (eventDelegateList.ContainsKey(eventType))
            eventDelegateList[eventType] += handler;
        else
            eventDelegateList.Add(eventType, handler);
    }

    public void Register(EVENT_TYPE eventType, EventDelegateWithMessage handler) {
        if (eventDelegateWithMessageList.ContainsKey(eventType))
            eventDelegateWithMessageList[eventType] += handler;
        else
            eventDelegateWithMessageList.Add(eventType, handler);
    }

    public void Send(EVENT_TYPE eventType) {
        if (eventDelegateList.ContainsKey(eventType))
            eventDelegateList[eventType]();
    }

    public void Send(EVENT_TYPE eventType, EventMessage message) {
        if (eventDelegateList.ContainsKey(eventType))
            eventDelegateWithMessageList[eventType](message);
    }

    public void Unregister(EVENT_TYPE eventType, EventDelegate handler) {
        eventDelegateList[eventType] -= handler;
        if (eventDelegateList[eventType] == null)
            eventDelegateList.Remove(eventType);
    }

    public void Unregister(EVENT_TYPE eventType, EventDelegateWithMessage handler) {
        eventDelegateWithMessageList[eventType] -= handler;
        if (eventDelegateWithMessageList[eventType] == null)
            eventDelegateWithMessageList.Remove(eventType);
    }
}
