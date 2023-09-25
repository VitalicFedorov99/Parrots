using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Skin")]
public class Skin : ScriptableObject
{
    [SerializeField] private bool isBuy;
    [SerializeField] private int cost;


    public int GetCost() => cost;

    public bool GetIsBuy() => isBuy;

    public void Buy() 
    {
        isBuy = true;
    }
        
}
