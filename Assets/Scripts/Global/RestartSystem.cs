using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RestartSystem: IService
{
    [SerializeField] private Transform placeStartPlayer;
    [SerializeField] private Transform placeStartCamera;
    [SerializeField] private Transform placeWinGame;

    public void Restart() 
    {
        
        ServiceLocator.Current.Get<CameraController>().TakeOnCamera(TypeCamera.Game);
        ServiceLocator.Current.Get<WinAndLoseSystem>().Restart();
        ServiceLocator.Current.Get<ScoreManager>().Setup();
        ObjectPool.instance.DestroyAll();
        ServiceLocator.Current.Get<PlacementSystem>().Setup();
        ServiceLocator.Current.Get<Player>().Setup(placeStartPlayer);
        ServiceLocator.Current.Get<AudioManager>().Play("MainThemeGame");
        ServiceLocator.Current.Get<FollowCamers>().Setup(placeStartCamera);
        ServiceLocator.Current.Get<AnimationBirdsFinish>().Setup(placeWinGame);
        ServiceLocator.Current.Get<FruitCreater>().CreateFruits();
    }
}
