using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all game objects
public class ExtendedMono : MonoBehaviour {

    EventManager eventManager;
    Dictionary<string, EventDelegate> eventDelegateList = new Dictionary<string, EventDelegate>();      // Record for destroy
    Dictionary<string, EventDelegateWithMessage> eventDelegateWithMessageList = new Dictionary<string, EventDelegateWithMessage>();

    protected float timeScale = 1;
    protected bool gamePaused = false;

    protected virtual void Awake() {
        eventManager = EventManager.GetInstance();
    }

    void Update() {
        if (gamePaused == false)
            GameUpdate(Time.deltaTime * timeScale);
    }

    // Game loop with a flexiable time scale
    protected virtual void GameUpdate(float deltaTime) {
    }

    // Register and send events
    protected void RegisterEvent(string eventType, EventDelegate handler) {
        eventManager.Register(eventType, handler);
        eventDelegateList.Add(eventType, handler);
    }

    protected void RegisterEvent(string eventType, EventDelegateWithMessage handler) {
        eventManager.Register(eventType, handler);
        eventDelegateWithMessageList.Add(eventType, handler);
    }

    protected void SendEvent(string eventType) {
        eventManager.Send(eventType);
    }

    protected void SendEvent(string eventType, EventMessage message) {
        eventManager.Send(eventType, message);
    }

    // Clear all registed events
    protected virtual void OnDestroy() {
        foreach (string eventType in eventDelegateList.Keys) {
            eventManager.Unregister(eventType, eventDelegateList[eventType]);
        }
        foreach (string eventType in eventDelegateWithMessageList.Keys) {
            eventManager.Unregister(eventType, eventDelegateWithMessageList[eventType]);
        }
    }

    // Lazy man's log
    protected void L(object message) {
        Debug.Log(message.ToString());
    }
}
