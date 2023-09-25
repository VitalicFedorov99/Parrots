using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocaterLoaderGame : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private WinAndLoseSystem winAndLoseSystem;
    [SerializeField] private FollowCamers followCamers;
    [SerializeField] private AnimationBirdsFinish animationBirdsFinish;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private RestartSystem restartSystem;
    [SerializeField] private SkinSystem skinSystem;
    [SerializeField] private ShopView shopView;
    [SerializeField] private PlacementSystem placementSystem;
    [SerializeField] private CameraController cameraControllers;
    [SerializeField] private FruitCreater fruitCreater;


    private StateGameController stateGameController;

    public void RegisterServices()
    {
        ServiceLocator.Initialize();
        stateGameController = new StateGameController();
        ServiceLocator.Current.Register(player);
        ServiceLocator.Current.Register(winAndLoseSystem);
        ServiceLocator.Current.Register(followCamers);
        ServiceLocator.Current.Register(animationBirdsFinish);
        ServiceLocator.Current.Register(scoreManager);
        ServiceLocator.Current.Register(audioManager);
        ServiceLocator.Current.Register(restartSystem);
        ServiceLocator.Current.Register(placementSystem);
        ServiceLocator.Current.Register(skinSystem);
        ServiceLocator.Current.Register(shopView);
        ServiceLocator.Current.Register(cameraControllers);
        ServiceLocator.Current.Register(stateGameController);
        ServiceLocator.Current.Register(fruitCreater);
    }

    public void Setup()
    {
        //skinSystem.SearchHat("Luffy");
        //skinSystem.SearchColorSkin("Black1");
        skinSystem.Setup();
        audioManager.Setup();
        stateGameController.Initialize(stateGameController.stateMenu);
        //stateGameController.ChangeState(stateGameController.stateShop);
    }

    public void ChangeStateInGame() 
    {
        stateGameController.ChangeState(stateGameController.stateGame);
    }
    public void ChangeStateInShop() 
    {
        stateGameController.ChangeState(stateGameController.stateShop);
    }
    public void ChangeStateInMenu()
    {
        stateGameController.ChangeState(stateGameController.stateMenu);
    }


    public void Restart()
    {
        restartSystem.Restart();
    }
}
