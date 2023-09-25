using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IPooledObject
{
    [SerializeField] private int score;
    [SerializeField] private TypeObjectInPool typeObject;
    public TypeObjectInPool TypeObject => typeObject;

    public void DestroyObject()
    {
        ObjectPool.instance.DestroyObject(gameObject);
    }

    public void Tween() 
    {
        ServiceLocator.Current.Get<ScoreManager>().AddScoreInLevel(score);
        DestroyObject();
    }
}

