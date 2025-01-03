using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // Mikser d�wi�ku
    public Slider volumeSlider; // Slider do ustawiania g�o�no�ci
    private const string VolumeKey = "Volume"; // Klucz dla PlayerPrefs

    private void Start()
    {
        // Wczytaj zapisan� warto�� g�o�no�ci
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 0.0f); // Domy�lnie 0.0f
        volumeSlider.value = savedVolume; // Ustaw slider na zapisan� warto��
        audioMixer.SetFloat("volume", savedVolume); // Zastosuj warto�� do miksera

        // Nas�uchuj zmiany warto�ci slidera
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Ustaw g�o�no�� w mikserze
        audioMixer.SetFloat("volume", volume);

        // Zapisz warto�� slidera w PlayerPrefs
        PlayerPrefs.SetFloat(VolumeKey, volume);
    }

    public void LoadMainMenu()
    {
        // Prze��cz na scen� g��wn�
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //private void OnDestroy()
    //{
    //    // Usu� nas�uch, by unikn�� b��d�w
    //    volumeSlider.onValueChanged.RemoveListener(SetVolume);
    //}
}
