using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Skin")]
public class Skin : ScriptableObject
{
    [SerializeField] private bool isBuy;
    [SerializeField] private int cost;
    [SerializeField] private Vector3 rotateInShop;
    [SerializeField] private Vector3 rotateInGame;
    public Vector3 OffsetShop;
    public Vector3 offsetGame;


    public Vector3 GetRotateInShop() => rotateInShop;
    public Vector3 GetRotateInGame() => rotateInGame;

    public int GetCost() => cost;

    public bool GetIsBuy() => isBuy;

    public void Buy() 
    {
        isBuy = true;
    }
        
}
