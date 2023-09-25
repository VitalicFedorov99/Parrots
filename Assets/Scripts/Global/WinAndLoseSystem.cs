using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WinAndLoseSystem: IService
{
    [SerializeField] private GameObject loseImage;
    [SerializeField] private GameObject winImage;

    
    public void Win() 
    {
       
        ServiceLocator.Current.Get<FollowCamers>().SetIsFall(false);
        ServiceLocator.Current.Get<Player>().SetIsWin(true);
        ServiceLocator.Current.Get<AnimationBirdsFinish>().SetIsWin(true);
        ServiceLocator.Current.Get<ScoreManager>().WinGame();
        winImage.SetActive(true);
    }

    public void Lose() 
    {
        ServiceLocator.Current.Get<FollowCamers>().SetIsFall(false);
        loseImage.SetActive(true);
    }

    public void Restart() 
    {
        loseImage.SetActive(false);
        winImage.SetActive(false);
    }
}
