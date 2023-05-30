using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueTree))]
public class DialogueReader : MonoBehaviour
{
    //The tree this reader will read
    [SerializeField] private DialogueTree tree;
    //The UI manager
    [SerializeField] private DialogueUIManager uiManager;

    //A Queue to keep track of the current branch's leaves.
    private Queue<DialogueLeaf> currentBranchLeaves = new Queue<DialogueLeaf>();
    //The current leaf on the current branch
    public DialogueLeaf currentLeaf { get; set; }

    //The function used by external triggers to start the dialogue.
    public void TraverseTree(int branchIndex)
    {
        //Set this reader to the uiManager.
        uiManager.currentReader = this;

        //Grab all of the branches in the current tree.
        foreach (var leaf in tree.branches[branchIndex].leaves)
        {
            currentBranchLeaves.Enqueue(leaf);
        }
        
        //Get the Next Leaf, in this case, it is the first one
        GetNextLeaf();
    }

    //The function used to trigger any animations inside of the leaf
    private void TriggerLeafAnimation(DialogueLeaf leaf)
    {
        foreach (var leafAnimation in leaf.animations)
        {
            leafAnimation.Trigger();
        }
    }

    //The function used to trigger any audio inside of the leaf
    private void TriggerLeafAudio(DialogueLeaf leaf)
    {
        foreach (var leafAudio in leaf.clips)
        {
            leafAudio.Trigger();
        }
    }

    //The function used to trigger any events inside of the leaf
    private void TriggerLeafEvents(DialogueLeaf leaf)
    {
        foreach (var leafEvent in leaf.events)
        {
            leafEvent.Trigger();
        }
    }

    //The function used to retreive the next leaf from the branch.
    public void GetNextLeaf()
    {
        //Checks if we have anymore leaves and if we don't, end the dialogue sequence.
        if(currentBranchLeaves.Count == 0)
        {
            uiManager.EndDialogueSession();

            return;
        }

        //Get The current leaf and send it to the manager
        currentLeaf = currentBranchLeaves.Dequeue();
        uiManager.currentLeaf = currentLeaf;

        //Start a dialogue session in the UI
        uiManager.StartDialogueSession();

        //Trigger various events if the current leaf has one.
        if(currentLeaf.events.Count > 0)
        {
            TriggerLeafEvents(currentLeaf);
        }

        //Trigger various audio if the current leaf has one.
        if(currentLeaf.clips.Count > 0)
        {
            TriggerLeafAudio(currentLeaf);
        }

        //Trigger various animations if the current leaf has one.
        if(currentLeaf.animations.Count > 0)
        {
            TriggerLeafAnimation(currentLeaf);
        }
    }
}
