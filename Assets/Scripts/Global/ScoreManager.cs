using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreManager: IService
{
    [SerializeField] private TMPro.TMP_Text scoreText;
    [SerializeField] private TMPro.TMP_Text scoreWinGame;
    [SerializeField] private IntVariable scorePlayer;
    [SerializeField] private IntVariable scorePlayerInLevel;



    public void Setup() 
    {
        scorePlayerInLevel.SetCount(0);
        UpdateScoreInLevel();
    }

    public void AddScoreInLevel(int newScore) 
    {
        scorePlayerInLevel.Add(newScore);
        UpdateScoreInLevel();
    }

    public void UpdateScoreInLevel() 
    {
        scoreText.text = scorePlayerInLevel.GetCount().ToString();
    }

    public void WinGame() 
    {
        scorePlayer.Add(scorePlayerInLevel);
        scoreWinGame.text = scorePlayer.GetCount().ToString();
    }
}
