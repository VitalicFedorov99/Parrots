using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMenu : IState
{
    public void Enter()
    {
        ServiceLocator.Current.Get<CameraController>().TakeOnCamera(TypeCamera.Menu);
    }

    public void Exit()
    {

    }

    public void Hurt()
    {
       
    }

    public void UpdateState()
    {
       
    }
}
