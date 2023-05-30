using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoiceBroadcaster : MonoBehaviour
{
    public int choiceBranchIndex { get; set; }

    public void Broadcast()
    {
        Messenger<int>.Broadcast("ChoiceMade", choiceBranchIndex);
    }
}
