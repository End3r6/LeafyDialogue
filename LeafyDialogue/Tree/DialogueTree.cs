using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTree : MonoBehaviour
{
    public List<DialogueBranch> branches = new List<DialogueBranch>();

    public DialogueBranch currentBranch {get; set;}
}
