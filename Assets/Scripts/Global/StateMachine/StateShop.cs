using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateShop : IState
{
    public void Enter()
    {
        ServiceLocator.Current.Get<ShopView>().Setup();
        ServiceLocator.Current.Get<CameraController>().TakeOnCamera(TypeCamera.Shop);
        ServiceLocator.Current.Get<AudioManager>().Play("MainThemeShop");
        ServiceLocator.Current.Get<SkinSystem>().RotateHatsInShop();
    }

    public void Exit()
    {
        ServiceLocator.Current.Get<AudioManager>().Stop("MainThemeShop");
    }

    public void Hurt()
    {

    }

    public void UpdateState()
    {

    }
}
