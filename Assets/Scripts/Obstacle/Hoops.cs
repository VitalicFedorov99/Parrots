using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoops : MonoBehaviour, IPooledObject
{
    [SerializeField] private Transform lowPlace;
    [SerializeField] private Transform midPlace;
    [SerializeField] private Transform highPlace;
    [SerializeField] private int min, max;
    private Transform currentPlace;

    //[SerializeField] private GameObject hoop;

    private int rand;
    public TypeObjectInPool TypeObject => TypeObjectInPool.Hoops;



    public void Setup(Hoop hoop)
    {

        rand = Random.Range(min, max);
        hoop.Setup(rand);
        rand = Random.Range(0, 3);
        currentPlace = rand switch
        {
            0 => lowPlace,
            1 => midPlace,
            2 => highPlace,
            _ => highPlace,
        };
        hoop.transform.position = currentPlace.position;
    }

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
}
