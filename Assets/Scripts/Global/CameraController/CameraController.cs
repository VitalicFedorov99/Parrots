using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CameraController : IService
{
    [SerializeField] private GameObject cameraGame;
    [SerializeField] private GameObject cameraShop;
    [SerializeField] private GameObject cameraMenu;
    [SerializeField] private GameObject canvasGame;
    [SerializeField] private GameObject canvasShop;
    [SerializeField] private GameObject canvasMenu;



    public void TakeOnCamera(TypeCamera typeCamera) 
    {
        switch (typeCamera) 
        {
            case TypeCamera.Game:
                cameraGame.SetActive(true);
                cameraShop.SetActive(false);
                cameraMenu.SetActive(false);
                canvasGame.SetActive(true);
                canvasShop.SetActive(false);
                canvasMenu.SetActive(false);
                break;
            case TypeCamera.Shop:
                cameraGame.SetActive(false);
                cameraShop.SetActive(true);
                cameraMenu.SetActive(false);
                canvasGame.SetActive(false);
                canvasShop.SetActive(true);
                canvasMenu.SetActive(false);
                break;
            case TypeCamera.Menu:
                cameraGame.SetActive(false);
                cameraShop.SetActive(false);
                cameraMenu.SetActive(true);
                canvasGame.SetActive(true);
                canvasShop.SetActive(false);
                canvasMenu.SetActive(true);
                break;
        }
    } 


}

public enum TypeCamera 
{
    Game,
    Shop,
    Menu
}
