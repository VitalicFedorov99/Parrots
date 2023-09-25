using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IntVariable")]
public class IntVariable : ScriptableObject
{
    [SerializeField] private int count;

    public void SetCount(int newCount) 
    {
        if (newCount >= 0) 
        {
            count = newCount;
        }
    }

    public void Add(int newCount) 
    {
        count += newCount;
        if (count < 0)
            count = 0;
    }

    public void Add(IntVariable intVariable) 
    {
        count += intVariable.GetCount();
    }

    public bool CheckCount(int cost) 
    {
        if (count >= cost)
            return true;
        return false;
    }

    public int GetCount() => count;
}
