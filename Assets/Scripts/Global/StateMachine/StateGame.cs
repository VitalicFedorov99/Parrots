using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGame : IState
{
    public void Enter()
    {
        SetupRun();
    }

    public void Exit()
    {
        ServiceLocator.Current.Get<AudioManager>().Stop("MainThemeGame");
        ServiceLocator.Current.Get<Player>().SetIsGame(false);
    }

    public void Hurt()
    {

    }

    public void UpdateState()
    {

    }

    private void SetupRun()
    {
        /*   ServiceLocator.Current.Get<CameraController>().TakeOnCamera(TypeCamera.Game);
           
           ServiceLocator.Current.Get<AudioManager>().Play("MainThemeGame");
           ServiceLocator.Current.Get<PlacementSystem>().Setup();
           ServiceLocator.Current.Get<FollowCamers>().Setup();
           // followCamers.SetIsFall(true);
           ServiceLocator.Current.Get<AnimationBirdsFinish>().Setup();
           ServiceLocator.Current.Get<ScoreManager>().Setup();*/
        
        ServiceLocator.Current.Get<Player>().Setup();
        ServiceLocator.Current.Get<RestartSystem>().Restart();
       /* ServiceLocator.Current.Get<WinAndLoseSystem>().Restart();
        ServiceLocator.Current.Get<ScoreManager>().Setup();
        ObjectPool.instance.DestroyAll();
        ServiceLocator.Current.Get<PlacementSystem>().Setup();
        ServiceLocator.Current.Get<Player>().Setup(placeStartPlayer);
        ServiceLocator.Current.Get<AudioManager>().Play("MainThemeGame");
        ServiceLocator.Current.Get<FollowCamers>().Setup(placeStartCamera);
        ServiceLocator.Current.Get<AnimationBirdsFinish>().Setup(placeWinGame);*/
    }
    

}
