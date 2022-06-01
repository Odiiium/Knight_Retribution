using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    float score = 0;
    float trueScore;

    private void Update()
    {
        if (GameController.isGame)
        {
            score += Time.deltaTime;
            trueScore = Mathf.RoundToInt(Mathf.Pow(score, 1.5f));
            scoreText.text = "" + Mathf.RoundToInt(Mathf.Pow(score, 1.5f));
        }

        if (PlayerController.isDead)
        {
            EndGameMenu.highscore = Convert.ToInt16(scoreText.text);
        }
    }

}
