using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // Mikser dŸwiêku
    public Slider volumeSlider; // Slider do ustawiania g³oœnoœci
    private const string VolumeKey = "Volume"; // Klucz dla PlayerPrefs

    private void Start()
    {
        // Wczytaj zapisan¹ wartoœæ g³oœnoœci
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 0.0f); // Domyœlnie 0.0f
        volumeSlider.value = savedVolume; // Ustaw slider na zapisan¹ wartoœæ
        audioMixer.SetFloat("volume", savedVolume); // Zastosuj wartoœæ do miksera

        // Nas³uchuj zmiany wartoœci slidera
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Ustaw g³oœnoœæ w mikserze
        audioMixer.SetFloat("volume", volume);

        // Zapisz wartoœæ slidera w PlayerPrefs
        PlayerPrefs.SetFloat(VolumeKey, volume);
    }

    public void LoadMainMenu()
    {
        // Prze³¹cz na scenê g³ówn¹
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //private void OnDestroy()
    //{
    //    // Usuñ nas³uch, by unikn¹æ b³êdów
    //    volumeSlider.onValueChanged.RemoveListener(SetVolume);
    //}
}
