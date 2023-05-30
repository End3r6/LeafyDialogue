using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class DialogueChoice
{
    [Tooltip("Text to display on option")]
    public string text;

    [Tooltip("The Index of the branch this choice leads to.")]
    public int branchID;
}
