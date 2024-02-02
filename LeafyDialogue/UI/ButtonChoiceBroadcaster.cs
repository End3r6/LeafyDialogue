using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoiceBroadcaster : MonoBehaviour
{
    public string choiceBranchName { get; set; }

    public void BroadcastName()
    {
        Messenger<string>.Broadcast("ChoiceMade", choiceBranchName);
    }
}
