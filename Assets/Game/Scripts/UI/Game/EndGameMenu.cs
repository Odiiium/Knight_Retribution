using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGameMenu : MonoBehaviour
{
    internal static int highscore;
    internal static int earnedMoney;
    internal static int wavesPassed;

    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI earnedMoneyText;
    [SerializeField] TextMeshProUGUI wavesPassedText;

    private void Start()
    {
        GameController.isGame = false;

        earnedMoney = PlayerPrefs.GetInt("money") - PlayerController.startMoney;
        if (SpawnManager.waveCount > 0)
        {
            wavesPassed = SpawnManager.waveCount - 1;
        }
        else
        {
            wavesPassed = SpawnManager.waveCount;
        }
        if (wavesPassed > PlayerPrefs.GetInt("maximalWave"))
        {
            PlayerPrefs.SetInt("maximalWave", wavesPassed);
        }

        if (highscore > PlayerPrefs.GetInt("highscore"))
        {
            highscoreText.gameObject.SetActive(true);
            PlayerPrefs.SetInt("highscore", highscore);
        }

        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                scoreText.text = "Score: " + highscore;
                earnedMoneyText.text = "Money earned: " + earnedMoney;
                wavesPassedText.text = "Waves passed: " + wavesPassed;
                break;
            case 1:
                scoreText.text = "Рахунок: " + highscore;
                earnedMoneyText.text = "Монет зароблено: " + earnedMoney;
                wavesPassedText.text = "Xвиль пройдено: " + wavesPassed;
                break;
            case 2:
                scoreText.text = "Счет: " + highscore;
                earnedMoneyText.text = "Монет заработано: " + earnedMoney;
                wavesPassedText.text = "Волн пройдено: " + wavesPassed;
                break;
        }

        
    }

    public void Restart()
    {
        SceneTransition.SwitchToScene("Game");
    }

    public void Exit()
    {
        SceneTransition.SwitchToScene("PostGameMenu");
    }

}
