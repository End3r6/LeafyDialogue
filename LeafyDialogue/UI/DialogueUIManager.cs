using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DialogueUIManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueGroup;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject choiceButton;
    
    [SerializeField] private TMP_Text dialogueText;
    
    [SerializeField] private Transform buttonGroup;

    public DialogueReader currentReader {get; set;}
    public DialogueLeaf currentLeaf {get; set;}

    private List<GameObject> buttons = new List<GameObject>();

    private void Start()
    {
        Messenger<string>.AddListener("ChoiceMade", OnChoice);    
    }

    public void RequestNextLeaf()
    {
        currentReader.GetNextLeaf();
    }

    public void StartDialogueSession()
    {
        dialogueGroup.SetActive(true);

        DisplayDialogueLeaf();
    }

    public void EndDialogueSession()
    {
        dialogueGroup.SetActive(false);
    }

    private void DisplayDialogueLeaf()
    {
        ClearButtons();

        if(currentLeaf.choices.Count > 0)
        {
            GetChoices(currentLeaf);
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
        
        dialogueText.text = currentLeaf.text;
    }

    private void OnChoice(string choiceBranchName)
    {
        RequestTraverse(choiceBranchName);
    }

    private void GetChoices(DialogueLeaf leaf)
    {
        foreach(var choice in leaf.choices)
        {
            GameObject button = Instantiate(choiceButton, Vector3.zero, Quaternion.identity);
            button.transform.SetParent(buttonGroup);
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = choice.text;

            button.GetComponent<ButtonChoiceBroadcaster>().choiceBranchName = choice.branchName;

            buttons.Add(button);
        }
    }

    private void ClearButtons()
    {
        foreach(var button in buttons)
        {
            Destroy(button);
        }
    }

    private void RequestTraverse(string branchName)
    {
        currentReader.TraverseTree(branchName);
    }
}
