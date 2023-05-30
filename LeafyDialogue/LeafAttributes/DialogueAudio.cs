using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]
public class DialogueAudio
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;

    [SerializeField] private float volume;
    // public float delay;

    public void Trigger()
    {
        source.PlayOneShot(clip, volume);
    }

    // IEnumerator Play(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     source.PlayOneShot(clip, volume);
    // }
}
