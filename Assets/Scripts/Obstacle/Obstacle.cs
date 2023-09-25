using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour,IPooledObject
{
    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject billbord;
    [SerializeField] private GameObject umbrella;
    [SerializeField] private GameObject ImageBillbord;
    [SerializeField] private GameObject text;

    private int rand;
    private TypeObstacle typeObstacle;

    public TypeObjectInPool TypeObject => TypeObjectInPool.Obstacle;

    private void Start()
    {
        Setup();
    }
    public void Setup() 
    {
        OffObjects();
        rand = Random.Range(0, 5);
        SetupObjects();
        billbord.layer = 0;
        cloud.layer = 0;
        ImageBillbord.layer = 0;
        text.layer = 0;
    }
    public void OffVision() 
    {
        billbord.layer = 6;
        cloud.layer = 6;
        ImageBillbord.layer = 6;
        text.layer = 6;
    }
   

    private void SetupObjects() 
    {
        switch (rand) 
        {
            case 0:
                cloud.SetActive(true);
                typeObstacle = TypeObstacle.Cloud;
                break;
            case 1:
                umbrella.SetActive(true);
                typeObstacle = TypeObstacle.Umbrella;
                break;
            case 2:
                billbord.SetActive(true);
                typeObstacle = TypeObstacle.Billbord;
                break;
            case 3:
                umbrella.SetActive(true);
                billbord.SetActive(true);
                typeObstacle = TypeObstacle.BillbordAndUmbrella;
                break;
            case 4:
                cloud.SetActive(true);
                billbord.SetActive(true);
                typeObstacle = TypeObstacle.CloudAndBillbord;
                break;
            case 5:
                umbrella.SetActive(true);
                cloud.SetActive(true);
                typeObstacle =TypeObstacle.CloudAndUmbrella;
                break;
        }
    }
    private void OffObjects()
    {
        cloud.SetActive(false);
        billbord.SetActive(false);
        umbrella.SetActive(false);
    }

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }
}

public enum TypeObstacle 
{
    CloudAndBillbord,
    Cloud,
    CloudAndUmbrella,
    Billbord,
    BillbordAndUmbrella,
    Umbrella
}
