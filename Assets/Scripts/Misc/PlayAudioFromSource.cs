using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioFromSource : MonoBehaviour
{
    public void PlayButtonSound(int index)
    {
        if (AudioManager._instance != null)
            AudioManager._instance.PlaySound(index);
        else
            Debug.Log("Warning<PlayerAudioFromSource> - " + gameObject.name + ". _instance of AudioManager == null.");
    }
}
