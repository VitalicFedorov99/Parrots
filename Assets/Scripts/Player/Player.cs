using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IService
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerSkin playerSkin;
    [SerializeField] private GameObject bird;


    private PlayerAnimator playerAnimator;


    private bool isLive;
    private bool isWin;
    private bool isGame=false;
    public void Setup()
    {
       // bird.transform.rotation = Quaternion.Euler(0, 0, 0);
        playerMovement.Setup(gameObject);
        playerAnimator = new PlayerAnimator(GetComponent<Animator>());
        SetupSkin();
        isLive = true;
        isGame = true;
    }


    public void SetIsGame(bool flag) 
    {
        isGame = flag;
    }
    public void SetupSkin() 
    {
        SetupHat(ServiceLocator.Current.Get<SkinSystem>().GetChooseHat());
        SetupColor(ServiceLocator.Current.Get<SkinSystem>().GetChooseColorSkin().texture);
    }

    public void SetupHat(Hat hat) => playerSkin.SetupHat(hat);
    public void SetupColor(Texture texture) => playerSkin.SetupColor(texture);

    public void Setup(Transform startPos)  //Restart
    {
        bird.transform.rotation = Quaternion.Euler(0, -180, 0);
        if (!isWin)
        {
           // bird.transform.Rotate(new Vector3(+90, 0, 0));
        }
        playerAnimator = new PlayerAnimator(GetComponent<Animator>());
        playerMovement.Setup(gameObject);
        SetupSkin();
        playerAnimator.StartGame();
        isLive = true;
        isWin = false;
        isGame = true;
        transform.position = startPos.position;
        //playerSkin.Setup(gameObject);
    }
    public void SetIsWin(bool flag) => isWin = flag;



    private void Update()
    {
        if(!isGame)
            return;

        if (!isLive)
        {
            playerMovement.Fall();
            return;
        }

        if (!isWin)
        {
            playerMovement.Update();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ServiceLocator.Current.Get<WinAndLoseSystem>().Lose();
        if (isLive)
            Death();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Finish finish))
        {
            ServiceLocator.Current.Get<WinAndLoseSystem>().Win();
        }
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.OffVision();
        }
        if (other.TryGetComponent(out Hoop hoop))
        {
            hoop.Tween();
        }
        if(other.TryGetComponent(out Fruit fruit)) 
        {
            fruit.Tween();
        }

    }

    private void Death()
    {
        isLive = false;
        FallRotate();
        playerAnimator.Death();
    }


    private void FallRotate()
    {
        bird.transform.Rotate(new Vector3(-90, 0, 0));
    }
}
