using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {

    public Main MainScript;
    public CubeRun CubeRunScript;
    [Space]

    public GameObject BlackScreen, QuestCompleteObject;
    public Text QuestText;
    public Text QuestEx;

    public void QuestCompliter()
    {
        Debug.Log("Q");
        int tmpNQ = Save.NowQuest;
        switch (tmpNQ)
        {
            case 1: // Play one game 
                QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                Save.NowQuest++; break;
            case 2:
                Debug.Log(Save.NowQuest);
                if (CubeRunScript.Score > 10) // Score > 10 
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 3:
                if (CubeRunScript.Score > 17 && CubeRunScript.Score < 21) // Score > 17 and Score < 21
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 4:
                Color PlayerColor = MainScript.PlayerCubeRenderers[1].material.color; // Player is red and Score == 25
                Debug.Log(PlayerColor);
                if (PlayerColor.r == Color.red.r && PlayerColor.g == Color.red.g && PlayerColor.b == Color.red.b && CubeRunScript.Score == 25)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 5:
                if (CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 6:
                if (CubeRunScript.Score == 35)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 7:
                Color PlayerColor7 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor7.r == Color.green.r && PlayerColor7.g == Color.green.g && PlayerColor7.b == Color.green.b && CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 8:
                if (CubeRunScript.Score == Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 9:
                if (CubeRunScript.Score > 60)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 10:
                if (MainScript.AlphaBool)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 11:
                if (MainScript.Mode == 1)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 12:
                if (MainScript.Mode == 2)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 13:
                if (CubeRunScript.Score > 45)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 14:
                Color PlayerColor14 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor14.r == Color.blue.r && PlayerColor14.g == Color.blue.g && PlayerColor14.b == Color.blue.b && CubeRunScript.Score == 40)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 15:
                if (CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 16:
                if (CubeRunScript.Score == Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 17:
                if (MainScript.AlphaBool && CubeRunScript.Score == 45)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 18:
                if (CubeRunScript.Score > 50)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 19:
                if (CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 20:
                if (CubeRunScript.Score > (int)Save.AverageScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 21:
                Color PlayerColor21 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor21.r == Color.green.r && PlayerColor21.g == Color.green.g && PlayerColor21.b == Color.green.b && CubeRunScript.Score > 65)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 22:
                if (CubeRunScript.Score == Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 23:
                Color PlayerColor23 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor23.r == Color.cyan.r && PlayerColor23.g == Color.cyan.g && PlayerColor23.b == Color.cyan.b && CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 24:
                if (CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 25:
                if (CubeRunScript.Score > 70)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 26:
                Color PlayerColor26 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor26.r == Color.white.r && PlayerColor26.g == Color.white.g && PlayerColor26.b == Color.white.b && CubeRunScript.Score == Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 27:
                if (CubeRunScript.Score > 85)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 28:
                Color PlayerColor28 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor28.r == Color.blue.r && PlayerColor28.g == Color.blue.g && PlayerColor28.b == Color.blue.b && CubeRunScript.Score > 75)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 29:
                if (CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 30:
                if (CubeRunScript.Score > 75 && CubeRunScript.Score < 95)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 31:
                Color PlayerColor31 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor31.r == Color.green.r && PlayerColor31.g == Color.green.g && PlayerColor31.b == Color.green.b && CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 32:
                if (MainScript.AlphaBool && CubeRunScript.Score > 80)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 33:
                Color PlayerColor33 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor33.r == Color.blue.r && PlayerColor33.g == Color.blue.g && PlayerColor33.b == Color.blue.b && CubeRunScript.Score > (int)(Save.AverageScore * 2))
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 34:
                if (MainScript.AlphaBool && CubeRunScript.Score > 85)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 35:
                if (MainScript.AlphaBool && CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 36:
                Color PlayerColor36 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor36.r == Color.black.r && PlayerColor36.g == Color.black.g && PlayerColor36.b == Color.black.b && CubeRunScript.Score > 90)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 37:
                if (MainScript.AlphaBool && CubeRunScript.Score > 90)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 38:
                Color PlayerColor38 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor38.r == Color.green.r && PlayerColor38.g == Color.green.g && PlayerColor38.b == Color.green.b && MainScript.AlphaBool)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 39:
                if (MainScript.AlphaBool && CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 40:
                if (MainScript.AlphaBool && CubeRunScript.Score > 95)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 41:
                if (CubeRunScript.Score > 100)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 42:
                Color PlayerColor42 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor42.r == Color.red.r && PlayerColor42.g == Color.red.g && PlayerColor42.b == Color.red.b && CubeRunScript.Score > (int)(Save.AverageScore * 2))
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 43:
                if (MainScript.AlphaBool && CubeRunScript.Score > (int)(Save.AverageScore * 2))
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 44:
                if (CubeRunScript.Score > 105)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 45:
                if (CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 46:
                Color PlayerColor46 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor46.r == Color.blue.r && PlayerColor46.g == Color.blue.g && PlayerColor46.b == Color.blue.b && CubeRunScript.Score > 110)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 47:
                Color PlayerColor47 = MainScript.PlayerCubeRenderers[0].material.color;
                if (PlayerColor47.r == Color.red.r && PlayerColor47.g == Color.red.g && PlayerColor47.b == Color.red.b && CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 48:
                if (CubeRunScript.Score > 115)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 49:
                if (MainScript.AlphaBool && CubeRunScript.Score > Save.BestScore)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;
            case 50:
                if (CubeRunScript.Score > 150)
                {
                    QuestText.text = Lang.Phrase("Quest") + " #" + Save.NowQuest + " " + Lang.Phrase("complete") + " " + GetQuestText(Save.NowQuest);
                    QuestText.gameObject.transform.parent.GetComponent<Animator>().Play("QuestText");
                    Save.NowQuest++;
                }
                break;



        }

        if (tmpNQ == Save.NowQuest && QuestText != null)
            StartCoroutine(QuestView(false));
        else
            StartCoroutine(QuestView(true));
    }

    IEnumerator QuestView(bool _bool)
    {
        if (_bool)
        {
            QuestCompleteObject.SetActive(true);
            yield return new WaitForSeconds(5f);
        }
        else
            yield return new WaitForSeconds(2f);
        QuestCompleteObject.SetActive(false);
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        BlackScreen.SetActive(false);
        BlackScreen.transform.parent.gameObject.SetActive(false);
        MainScript.AfterLose();
    }

    public string GetQuestText(int INT)
    {
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            switch (INT)
            {
                case 1:
                    return "Сыграйте одну игру.";

                case 2:
                    return "Закончите игру с более чем 10 очками.";

                case 3:
                    return "Закончите игру с очками между 17 и 21.";

                case 4:
                    return "Будучи красным наберите 25 очков.";

                case 5:
                    return "Получите новый рекорд.";

                case 6:
                    return "Наберите 35 очков.";

                case 7:
                    return "Будучи зеленым получите новый рекорд.";

                case 8:
                    return "Наберите кол-во очков равно рекорду.";

                case 9:
                    return "Наберите более 40 очков.";

                case 10:
                    return "Сыграйте игру с низкий показателем прозрачности.";

                case 11:
                    return "Сыграйте игру с режимом касаний.";

                case 12:
                    return "Сыграйте игру с режимом водения.";

                case 13:
                    return "Наберите больше 45 очков.";

                case 14:
                    return "Будучи синим наберите 40 очков.";

                case 15:
                    return "Одержите новый рекорд.";

                case 16:
                    return "Наберите кол-во очков равно рекорду.";

                case 17:
                    return "Наберите 45 очков с низким показателем прозрачности.";

                case 18:
                    return "Наберите больше 50 очков.";

                case 19:
                    return "Одержите новый рекорд.";

                case 20:
                    return "Наберите кол-во очков больше чем среднее кол-во.";

                case 21:
                    return "Будучи зеленым наберите больше 65 очков.";

                case 22:
                    return "Наберите кол-во очков равному рекорду.";

                case 23:
                    return "Будучи голубым одержите новый рекорд.";

                case 24:
                    return "Одержите новый рекорд.";

                case 25:
                    return "Наберите больше 70 очков.";

                case 26:
                    return "Будучи белым кубом наберите кол-во очков равно рекорду.";

                case 27:
                    return "Наберите больше 85 очков.";

                case 28:
                    return "Будучи красным наберите больше 75 очков.";

                case 29:
                    return "Одержите новый рекорд.";

                case 30:
                    return "Набери кол-во очков между 75 и 95.";

                case 31:
                    return "Будучи зеленым одержите новый рекорд.";

                case 32:
                    return "Наберите больше 80 очков с низким показателем прозрачности.";

                case 33:
                    return "Будучи синим набери кол-во очком больше чем дважды среднее кол-во.";

                case 34:
                    return "Наберите 80 очков с низким показателем прозрачности.";

                case 35:
                    return "Одержите новый рекорд с низким показателем прозрачности.";

                case 36:
                    return "Будучи кубом черного цвета наберите больше 90 очков.";

                case 37:
                    return "Наберите более 90 очков с низким показателем прозрачности.";

                case 38:
                    return "Закончите игру будучи синим с низким показателем прозрачности";

                case 39:
                    return "Одержите новый рекорд с низким показателем прозрачности.";

                case 40:
                    return "Наберите более 95 очков с низким показателем прозрачности.";

                case 41:
                    return "Наберите более 100 очков.";

                case 42:
                    return "Будучи красным наберите кол-во очков более чем дважды среднее.";

                case 43:
                    return "Наберите кол-во очком более чем дважды среднее и будучи с низким показателем прозрачности.";

                case 44:
                    return "Наберите более 105 очков.";

                case 45:
                    return "Одержите новый рекорд";

                case 46:
                    return "Будучи синим наберите более 110 очков.";

                case 47:
                    return "Будучи красным одержите новый рекорд.";

                case 48:
                    return "Наберите более 115 очков.";

                case 49:
                    return "Одержите новый рекорд будучи с низким показателем прозрачности.";

                case 50:
                    return "Последнее... Наберите более 150 очков.";

            }
        }
        else if (Application.systemLanguage == SystemLanguage.Ukrainian)
        {
            switch (INT)
            {
                case 1:
                    return "Зіграйте одну гру.";

                case 2:
                    return "Припиніть гру з більш ніж 10 очками.";

                case 3:
                    return "Припиніть гру з рахунком між 17 і 21.";

                case 4:
                    return "Будучи червоним наберіть 25 очок.";

                case 5:
                    return "Отримайте новий рекорд.";

                case 6:
                    return "Наберіть 35 очок.";

                case 7:
                    return "Будучи зеленим отримайте новий рекорд.";

                case 8:
                    return "Наберіть кількість очок яке дорівнює рекорду.";

                case 9:
                    return "Наберіть більше 40 очок.";

                case 10:
                    return "Зіграйте гру з низький показником прозорості.";

                case 11:
                    return "Зіграйте гру з режимом торкань.";

                case 12:
                    return "Зіграйте гру з режимом водіння.";

                case 13:
                    return "Наберіть більше 45 очок.";

                case 14:
                    return "Будучи синім наберіть 40 очок.";

                case 15:
                    return "Отримайте новий рекорд.";

                case 16:
                    return "Наберіть кількість очок яке дорівнює рекорду.";

                case 17:
                    return "Наберіть 45 очок з низьким показником прозорості.";

                case 18:
                    return "Наберіть більше 50 очок.";

                case 19:
                    return "Отримайте новий рекорд.";

                case 20:
                    return "Наберіть кількість очок більше ніж середня кількість.";

                case 21:
                    return "Будучи зеленим наберіть більше 65 очок.";

                case 22:
                    return "Наберіть кількість очок рівному рекорду.";

                case 23:
                    return "Будучи блакитним здобудьте новий рекорд.";

                case 24:
                    return "Отримайте новий рекорд.";

                case 25:
                    return "Наберіть більше 70 очок.";

                case 26:
                    return "Будучи білим кубом наберіть кількість очок яке рівне рекорду.";

                case 27:
                    return "Наберіть більше 85 очок.";

                case 28:
                    return "Будучи червоним наберіть більше 75 очок.";

                case 29:
                    return "Отримайте новий рекорд.";

                case 30:
                    return "Набери кількість очок між 75 і 95.";

                case 31:
                    return "Будучи зеленим здобудьте новий рекорд.";

                case 32:
                    return "Наберіть більше 80 очок з низьким показником прозорості.";

                case 33:
                    return "Будучи синім наберіть кількість очком більше ніж двічі середня кількість.";

                case 34:
                    return "Наберіть 80 очок з низьким показником прозорості.";

                case 35:
                    return "Отримайте новий рекорд з низьким показником прозорості.";

                case 36:
                    return "Будучи кубом чорного кольору наберіть більше 90 очок.";

                case 37:
                    return "Наберіть більше 90 очок з низьким показником прозорості.";

                case 38:
                    return "Припиніть гру будучи синім з низьким показником прозорості";

                case 39:
                    return "Отримайте новий рекорд з низьким показником прозорості.";

                case 40:
                    return "Наберіть більше 95 очок з низьким показником прозорості.";

                case 41:
                    return "Наберіть більше 100 очок.";

                case 42:
                    return "Будучи червоним наберіть кількість очок більше ніж двічі середнє.";

                case 43:
                    return "Наберіть кількість очком більш ніж двічі середнє і будучи з низьким показником прозорості.";

                case 44:
                    return "Наберіть більше 105 очок.";

                case 45:
                    return "Отримайте новий рекорд";

                case 46:
                    return "Будучи синім наберіть більше 110 очок.";

                case 47:
                    return "Будучи червоним здобудьте новий рекорд.";

                case 48:
                    return "Наберіть більше 115 очок.";

                case 49:
                    return "Отримайте новий рекорд будучи з низьким показником прозорості.";

                case 50:
                    return "Останнє ... Наберіть більше 150 очок.";

            }
        }
        else
        {
            switch (INT)
            {
                case 1:
                    return "Lose one game.";

                case 2:
                    return "Lose with many ten score.";

                case 3:
                    return "Beetwen 17 and 21.";

                case 4:
                    return "Being red lose with 25 score.";

                case 5:
                    return "Get new record.";

                case 6:
                    return "Lose with 35 score.";

                case 7:
                    return "Being green get new record.";

                case 8:
                    return "Lose game with record score.";

                case 9:
                    return "Lose with many 40 score.";

                case 10:
                    return "Lose with very low alpha.";

                case 11:
                    return "Lose with touches mode.";

                case 12:
                    return "Lose with linear mode.";

                case 13:
                    return "Lose with many 45 score.";

                case 14:
                    return "Being blue lose with 40 score.";

                case 15:
                    return "Get new record.";

                case 16:
                    return "Lose game with record score.";

                case 17:
                    return "Lose with low alpha and 45 score.";

                case 18:
                    return "Lose with many 50 score.";

                case 19:
                    return "Get new record.";

                case 20:
                    return "Lose with many average score.";

                case 21:
                    return "Being green lose with many 65 score.";

                case 22:
                    return "Lose game with record score.";

                case 23:
                    return "Being cyan get new record.";

                case 24:
                    return "Get new record.";

                case 25:
                    return "Lose with many 70 score.";

                case 26:
                    return "Being white cube lose with record score.";

                case 27:
                    return "Lose with many 85 score.";

                case 28:
                    return "Being red lose with many 75 score.";

                case 29:
                    return "Get new record.";

                case 30:
                    return "Lose beetwen 75 and 95.";

                case 31:
                    return "Being green get new record.";

                case 32:
                    return "Lose with low alpha and many 80 score.";

                case 33:
                    return "Being blue lose with many double average score.";

                case 34:
                    return "Lose with low alpha and many 85 score.";

                case 35:
                    return "Get new record with low alpha.";

                case 36:
                    return "Being black cube lose with many 90 score.";

                case 37:
                    return "Lose with low alpha and many 90 score.";

                case 38:
                    return "Lose being blue and have low alpha.";

                case 39:
                    return "Get new record with low alpha.";

                case 40:
                    return "Lose with low alpha and many 95 score.";

                case 41:
                    return "Lose with many 100 score.";

                case 42:
                    return "Being red lose with many double average score.";

                case 43:
                    return "Lose with low alpha and many double average score.";

                case 44:
                    return "Lose with many 105 score.";

                case 45:
                    return "Get new record.";

                case 46:
                    return "Being blue lose with many 110 score.";

                case 47:
                    return "Being red get new record.";

                case 48:
                    return "Lose with many 115 score.";

                case 49:
                    return "Get new record with low alpha.";

                case 50:
                    return "Lose with many 150 score.";

            }
        }
        return "NULL";
    }

    public bool JustCheckColorQuest()
    {
        switch (Save.NowQuest)
        {
            case 4: 
            case 7: 
            case 14:
            case 21:
            case 23: 
            case 26: 
            case 28: 
            case 31: 
            case 33: 
            case 36: 
            case 38: 
            case 42: 
            case 46: return false;
        }
        return true;
    }

    public int GetNeedQuest(int _num)
    {
        switch (_num)
        {
            case 1: return 5;
            case 2: return 10;
            case 3: return 15;
            case 4: return 20;
            case 5: return 25;
            case 6: return 30;
            case 7: return 40;
            case 8: return 50;
            default: return 0;
        }
    }
}
