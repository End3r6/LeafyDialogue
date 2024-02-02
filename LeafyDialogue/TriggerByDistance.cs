using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueReader))]
public class TriggerByDistance : MonoBehaviour
{
    [Tooltip("The distance the object has to be in to trigger the reader")]
    [SerializeField] private float distance = 3.0f;

    [Tooltip("The branch the trigger starts once it is triggered.")]
    [SerializeField] private string treeBranch;

    [Tooltip("The key the player has to press to trigger the reader")]
    [SerializeField] private KeyCode triggerKey = KeyCode.E;

    [Tooltip("A layermask that determines which objects can trigger the reader")]
    [SerializeField] private LayerMask whatCanTrigger;

    [Tooltip("The reader this trigger will trigger")]
    [SerializeField] private DialogueReader reader;

    private bool objectInTriggerZone = false;

    private void Awake() 
    {
        //Make sure the trigger has a reader assigned
        if(reader == null)
        {
            reader = GetComponent<DialogueReader>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckSphere();
        if(objectInTriggerZone && Input.GetKeyDown(triggerKey))
        {
            reader.TraverseTree(treeBranch);
        }
    }

    private void CheckSphere()
    {
        objectInTriggerZone = Physics.CheckSphere(transform.position, distance, whatCanTrigger);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
