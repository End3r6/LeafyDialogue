using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueBranch
{
    public List<DialogueLeaf> leaves = new List<DialogueLeaf>();
    public DialogueLeaf currentLeaf {get; set;}
}
