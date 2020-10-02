using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGameSettings : MonoBehaviour
{
    [Header("Setting Components")]
    public Slider _musicVolumeSlider = null;
    public Slider _sfxVolumeSlider = null;
    public InputField _playerNameInput = null;


    public enum SliderType
    {
        Music = 0,
        SFX = 1
    }


    // void Awake() {}

    void Start()
    {
        InitializeGameSettings();
    }

    // void Update() {}
    // void FixedUpdate() {}

    private void InitializeGameSettings()
    {
        if (GameSettings._instance != null)
        {
            GameSettings._instance._musicVolume = _musicVolumeSlider.value;
            GameSettings._instance._sfxVolume = _sfxVolumeSlider.value;   
        }
    }

    public void ChangeSliderValue(int type)
    {
        switch((SliderType)type)
        {
            case SliderType.Music:
                GameSettings._instance._musicVolume = _musicVolumeSlider.value;
                break;
            
            case SliderType.SFX:
                GameSettings._instance._sfxVolume = _sfxVolumeSlider.value;
                break;
        }
    }

    public void ChangePlayerName()
    {
        GameSettings._instance._playerName = _playerNameInput.text;
    }
}
