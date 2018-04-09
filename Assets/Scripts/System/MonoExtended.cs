using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all game objects
public abstract class MonoExtended : MonoBehaviour {

    EventManager eventManager;
    Dictionary<EVENT_TYPE, EventDelegate> eventDelegateList = new Dictionary<EVENT_TYPE, EventDelegate>();      // Record for destroy
    Dictionary<EVENT_TYPE, EventDelegateWithMessage> eventDelegateWithMessageList = new Dictionary<EVENT_TYPE, EventDelegateWithMessage>();

    protected GameManager gameManager;

    protected float timeScale = 1;
    protected float deltaTime;

    protected virtual void Awake() {
        eventManager = EventManager.GetInstance();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    protected virtual void Update() {
        switch (gameManager.gameState) {

            case 0:
                // Game paused
                break;

            case 1:
                // Running
                deltaTime = Time.deltaTime * timeScale;
                GameUpdate();
                break;

            case 2:
                // End
                break;
        }
    }

    // Game loop with a flexiable time scale
    protected abstract void GameUpdate();

    // Register and send events
    protected void RegisterEvent(EVENT_TYPE eventType, EventDelegate handler) {
        eventManager.Register(eventType, handler);
        eventDelegateList.Add(eventType, handler);
    }

    protected void RegisterEvent(EVENT_TYPE eventType, EventDelegateWithMessage handler) {
        eventManager.Register(eventType, handler);
        eventDelegateWithMessageList.Add(eventType, handler);
    }

    protected void SendEvent(EVENT_TYPE eventType) {
        eventManager.Send(eventType);
    }

    protected void SendEvent(EVENT_TYPE eventType, EventMessage message) {
        eventManager.Send(eventType, message);
    }

    // Clear all registed events
    protected virtual void OnDestroy() {
        foreach (EVENT_TYPE eventType in eventDelegateList.Keys) {
            eventManager.Unregister(eventType, eventDelegateList[eventType]);
        }
        foreach (EVENT_TYPE eventType in eventDelegateWithMessageList.Keys) {
            eventManager.Unregister(eventType, eventDelegateWithMessageList[eventType]);
        }
    }

    // Lazy man's log
    protected void L(object message) {
        Debug.Log(message.ToString());
    }
}
