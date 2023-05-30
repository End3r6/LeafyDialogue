using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class DialogueAnimation
{
    public enum ParameterType
    {
        Bool = 0,
        Float = 1,
        Trigger = 2,
    }
    [SerializeField] private ParameterType type = ParameterType.Bool;

    [SerializeField] private Animator source;

    [SerializeField] private string parameterName;

    [SerializeField] private bool boolParameter;
    [SerializeField] private float floatParameter;

    public void Trigger()
    {
        if(type == ParameterType.Bool)
        {
            source.SetBool(parameterName, boolParameter);
        }
        else if(type == ParameterType.Float)
        {
            source.SetFloat(parameterName, floatParameter);
        }
        else if(type == ParameterType.Trigger)
        {
            source.SetTrigger(parameterName);
        }
    }
}
