using System.Collections.Generic;

public class EventManager {

    static EventManager instance = null;

    public static EventManager GetInstance() {
        if (instance == null)
            instance = new EventManager();
        return instance;
    }

    Dictionary<string, EventDelegate> eventDelegateList = new Dictionary<string, EventDelegate>();
    Dictionary<string, EventDelegateWithMessage> eventDelegateWithMessageList = new Dictionary<string, EventDelegateWithMessage>();

    public void Register(string eventType, EventDelegate handler) {
        if (eventDelegateList.ContainsKey(eventType))
            eventDelegateList[eventType] += handler;
        else
            eventDelegateList.Add(eventType, handler);
    }

    public void Register(string eventType, EventDelegateWithMessage handler) {
        if (eventDelegateWithMessageList.ContainsKey(eventType))
            eventDelegateWithMessageList[eventType] += handler;
        else
            eventDelegateWithMessageList.Add(eventType, handler);
    }

    public void Send(string eventType) {
        if (eventDelegateList.ContainsKey(eventType))
            eventDelegateList[eventType]();
    }

    public void Send(string eventType, EventMessage message) {
        if (eventDelegateList.ContainsKey(eventType))
            eventDelegateWithMessageList[eventType](message);
    }

    public void Unregister(string eventType, EventDelegate handler) {
        eventDelegateList[eventType] -= handler;
        if (eventDelegateList[eventType] == null)
            eventDelegateList.Remove(eventType);
    }

    public void Unregister(string eventType, EventDelegateWithMessage handler) {
        eventDelegateWithMessageList[eventType] -= handler;
        if (eventDelegateWithMessageList[eventType] == null)
            eventDelegateWithMessageList.Remove(eventType);
    }
}
