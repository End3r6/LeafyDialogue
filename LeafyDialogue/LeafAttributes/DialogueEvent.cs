using System.Collections;
using System.Collections.Generic;

using UnityEngine;


[System.Serializable]
public class DialogueEvent
{
    // public enum EventTriggerTime : ushort
    // {
    //     Start = 0,
    //     End = 1
    // }
    // public EventTriggerTime triggerTime = EventTriggerTime.Start;
    public string message;

    public void Trigger()
    {
        Messenger.Broadcast(message);
    }
}
