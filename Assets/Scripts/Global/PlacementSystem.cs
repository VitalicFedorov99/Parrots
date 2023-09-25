using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlacementSystem: IService
{
    [SerializeField] private float distance;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;
    private Vector3 currentPoint;
    
    private Obstacle currentObstacle;
    private Hoops currentHoops;
    private GameObject currentObject;
    private Hoop currentHoop;
    private int rand;

  /*  public PlacementSystem(float distance, Vector3 startPoint,Vector3 endPoint) 
    {
        this.distance = distance;
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        currentPoint = startPoint;
    }
  */

    public void Setup() 
    {
        currentPoint = startPoint;
        PlaceObjects();
    }
    

    private void PlaceObjects() 
    {
        while (Vector3.Distance(currentPoint, endPoint) > 5) 
        {
            currentPoint.z = currentPoint.z + distance;
            if (currentPoint.z > endPoint.z)
            {
                Debug.Log("Все расставлено");
                break;
            }

            rand =Random.Range(0, 3);
            if (rand < 1)
            {
                currentObject = ObjectPool.instance.GetObject(TypeObjectInPool.Hoops);
                currentHoop = ObjectPool.instance.GetObject(TypeObjectInPool.Hoop).GetComponent<Hoop>();
                currentHoops = currentObject.GetComponent<Hoops>();
                currentHoops.transform.position = currentPoint;
                currentHoops.Setup(currentHoop);
            }
            else
            {
                currentObject = ObjectPool.instance.GetObject(TypeObjectInPool.Obstacle);
                currentObstacle = currentObject.GetComponent<Obstacle>();
                currentObstacle.Setup();
                currentObstacle.transform.position = currentPoint;
            }
        }
    }



   

    
}
