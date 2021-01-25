using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour {

    public Main MainScript;
    public CubeRun CubeRunScript;
    public Quest QuestScript;
    [Space]
    public Text YourScoreText;
    public Text BestScoreTextLast;
    public Text AverageScoreTextLast;
    public Text MainMenuLoseText;

    public void StartLose()
    {
        foreach (Animator a in MainScript.PlayerCybeAnimator)
        {
            if(a != null)
            a.enabled = false;
        }
        gameObject.SetActive(true);
        if (PlayerPrefs.GetString("Sound", "Yes") == "Yes")
        {
            MainScript.Sound.PlayOneShot(Resources.Load<AudioClip>("Lose"));
        }
        MainScript.Play = false;
        gameObject.SetActive(true);
        MainScript.EventCubes.SetActive(false);


        Save.AverageScore = (Save.AverageScore * Save.CountGames++ + CubeRunScript.Score) / Save.CountGames;
        MainScript.ScoreText.text = Lang.Phrase("Score") + ": " + CubeRunScript.Score;
        QuestScript.QuestCompliter();
        if (CubeRunScript.Score > Save.BestScore)
            Save.BestScore = CubeRunScript.Score;
    }
}
