using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class FruitCreater : IService
{
    [SerializeField] private Vector3 vectorHeights;
    [SerializeField] private float distanceSpawn;
    [SerializeField] private Vector3 startVector;
    [SerializeField] private Vector3 endVector;

    private Vector3 currentVector;
    private Fruit currentFruit;
    private int randHeight;
    private int randFruit;
    private float currentHeight;
    private TypeObjectInPool typeObject;
    private int countFruitsOnLine;
    public void CreateFruits()
    {
        ChangeHeight();
        currentVector = startVector;
        currentVector.y = currentHeight;
        countFruitsOnLine = 0;
        while (currentVector.z < endVector.z)
        {

            randFruit = Random.Range(0, 2);
            typeObject = ChangeFruit(randFruit);
            currentFruit = ObjectPool.instance.GetObject(typeObject).GetComponent<Fruit>();
            currentFruit.transform.position = currentVector;
            currentVector.z += distanceSpawn;
            countFruitsOnLine++;
            if (countFruitsOnLine > 6)
            {
                ChangeHeight();
                currentVector.y = currentHeight;
                countFruitsOnLine = 0;
            }
        }

    }

    private TypeObjectInPool ChangeFruit(int rand)
    {
        return rand switch
        {
            0 => TypeObjectInPool.Grapes,
            1 => TypeObjectInPool.Orange,
            2 => TypeObjectInPool.Lime,
            _ => TypeObjectInPool.Grapes,
        };
    }

    private void ChangeHeight()
    {
        randHeight = Random.Range(0, 2);

        currentHeight = randHeight switch
        {
            0 => vectorHeights.x,
            1 => vectorHeights.y,
            2 => vectorHeights.z,
            _ => vectorHeights.x,
        };
    }








}
