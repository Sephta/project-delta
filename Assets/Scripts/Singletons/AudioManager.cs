using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField, ReadOnly] public List<AudioClip> _clips = new List<AudioClip>();
    [SerializeField, ReadOnly] public List<AudioSource> _sources = new List<AudioSource>();

    [Header("Instance Data")]
    public static AudioManager _instance;
    [SerializeField, ReadOnly] private bool gameStart = false;

    void Awake()
    {
        if (!gameStart)
        {
            _instance = this;
            gameStart = true;
        }
    }

    void Start()
    {
        // initialize all audio clips with an associated source
        InitializeAudio();
    }

    private void InitializeAudio()
    {
        if (_clips.Count <= 0 || _clips[0] == null)
            return;

        for (int i = 0; i < _clips.Count; i++)
        {
            _sources.Add(new AudioSource());
            _sources[i] = gameObject.AddComponent<AudioSource>();
            _sources[i].playOnAwake = false;
            _sources[i].clip = _clips[i];
        }
    }

    public void PlayerSound(int index)
    {
        _sources[index].PlayOneShot(_sources[index].clip);
    }
}
