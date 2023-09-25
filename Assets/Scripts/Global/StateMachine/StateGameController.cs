using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameController: IService
{
    public IState stateGame;
    public IState stateShop;
    public IState stateMenu;

    public IState CurrentState { get; set; }

    public StateGameController() 
    {
        stateGame = new StateGame();
        stateShop = new StateShop();
        stateMenu = new StateMenu(); 
    }

    public void Initialize(IState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(IState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

}




public interface IState 
{
    public void Enter();
    public void UpdateState();
    public void Hurt();
    public void Exit();
}
