using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour {

    public Main MainScript;

    public Image SoundImage, 
                MusicImage;
    public Text BestScoreText,
                CountGamesText,
                AverageScoreText,
                CompleteQuestsText,
                SettingsText,
                MusicSettingsText,
                ModeSettingsText,
                ModeButtonSettingsText;
    public void StartSettings ()
    {
        gameObject.SetActive(true);
        SoundImage.sprite = Resources.LoadAll<Sprite>("InterFace")[PlayerPrefs.GetString("Sound", "Yes") == "Yes" ? 1 : 2];
        MusicImage.sprite = Resources.LoadAll<Sprite>("InterFace")[PlayerPrefs.GetString("Music", "Yes") == "Yes" ? 10 : 11];

        SettingsText.text = Lang.Phrase("Settings");
        switch (PlayerPrefs.GetInt("Mode"))
        {
            case 0: ModeButtonSettingsText.text = Lang.Phrase("Swipe"); break;
            case 1: ModeButtonSettingsText.text = Lang.Phrase("Touches"); break;
            case 2: ModeButtonSettingsText.text = Lang.Phrase("Linear"); break;
        }
        ModeSettingsText.text = Lang.Phrase("Mode") + ":";
        BestScoreText.text = Lang.Phrase("Best score") + ": " + Save.BestScore.ToString();
        CountGamesText.text = Lang.Phrase("Count games") + ": " + Save.CountGames.ToString();
        AverageScoreText.text = Lang.Phrase("Average score") + ": " + Save.AverageScore.ToString("0.00");
        CompleteQuestsText.text = Lang.Phrase("Complete quests") + ": " + (Save.NowQuest - 1).ToString() + "/50";
    }

    public void ClickOnSoundButton()
    {
        PlayerPrefs.SetString("Sound", PlayerPrefs.GetString("Sound", "Yes") == "Yes" ? "No" : "Yes");
        SoundImage.sprite = Resources.LoadAll<Sprite>("InterFace")[PlayerPrefs.GetString("Sound", "Yes") == "Yes" ? 1 : 2];
    }

    public void ClickOnMusicButton()
    {
        PlayerPrefs.SetString("Music", PlayerPrefs.GetString("Music", "Yes") == "Yes" ? "No" : "Yes");
        MusicImage.sprite = Resources.LoadAll<Sprite>("InterFace")[PlayerPrefs.GetString("Music", "Yes") == "Yes" ? 10 : 11];
        MainScript.Music.volume = PlayerPrefs.GetString("Music", "Yes") == "Yes" ? 1 : 0;
    }

    public void ClickOnModeButton()
    {
        PlayerPrefs.SetInt("Mode", PlayerPrefs.GetInt("Mode", 0) == 1 ? 2 : PlayerPrefs.GetInt("Mode", 0) == 2 ? 0 : 1);

        switch (PlayerPrefs.GetInt("Mode"))
        {
            case 0: ModeButtonSettingsText.text = Lang.Phrase("Swipe"); break;
            case 1: ModeButtonSettingsText.text = Lang.Phrase("Touches"); break;
            case 2: ModeButtonSettingsText.text = Lang.Phrase("Linear"); break;
        }
    }

    public void ClickOnExitButton()
    {
        GetComponent<Animator>().Play("CloseSett");
    }

    public void AfterAnim()
    {
        gameObject.SetActive(false);
    }
}
