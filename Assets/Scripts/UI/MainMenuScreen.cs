using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScreen : MonoBehaviour
{
    public AudioMixer mainMixer;
    public TMP_Dropdown selectDifficulty;

    public static string DIFFICULTY_KEY = "difficulty";

    public const float EASY_DIFFICULTY = 0f;
    public const float MEDIUM_DIFFICULTY = 1f;
    public const float HARD_DIFFICULTY = 2f;

    void Start()
    {
        // Get the stored difficulty value
        float storedDifficulty = MainMenuScreen.GetDifficulty();

        // Set the dropdown's value based on the stored difficulty
        if (selectDifficulty != null)
        {
            // Assuming the dropdown values are ordered as 0 (Easy), 1 (Medium), 2 (Hard)
            selectDifficulty.value = (int)storedDifficulty;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolume (float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

    public void SetDifficulty()
    {
        float difficulty;

        switch (selectDifficulty.value)
        {
            case 0: // 0 is Easy
                Debug.Log("Difficulty set to Easy");
                difficulty = EASY_DIFFICULTY;
                break;
            case 1: // 1 is Medium
                Debug.Log("Difficulty set to Medium");
                difficulty = MEDIUM_DIFFICULTY;
                break;
            case 2: //2 is Hard
                Debug.Log("Difficulty set to Hard");
                difficulty = HARD_DIFFICULTY;
                break;
            default:
                difficulty = MEDIUM_DIFFICULTY; // Default to Medium or any other default
                break;
        }

        PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
    }

    public void OnDifficultyChanged(int difficultyIndex)
    {
        PlayerPrefs.SetInt(DIFFICULTY_KEY, difficultyIndex);
        PlayerPrefs.Save();
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
