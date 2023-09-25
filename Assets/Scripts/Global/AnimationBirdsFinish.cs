using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBirdsFinish : MonoBehaviour, IService
{
    [SerializeField] private Player player;
    [SerializeField] private Transform place;
    [SerializeField] private Transform placeConstantWin;
    [SerializeField] private float speed;
    [SerializeField] private bool isWin;


    public void Setup() 
    {
        isWin = false;
    }

    public void Setup(Transform startPos) 
    {
        gameObject.transform.position = startPos.position;
        place.position = placeConstantWin.position;
        Setup();
    }

    public void SetIsWin(bool flag) => isWin = flag;

    public void PlayerFlyinPlace()
    {
        player.transform.position = Vector3.MoveTowards(player.transform.position, place.transform.position, Time.deltaTime * speed);
        if (Vector3.Distance(player.transform.position, place.transform.position) < 1)
        {
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            place.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (!isWin)
            return;

        PlayerFlyinPlace();

    }
}
