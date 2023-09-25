using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilbordImage : MonoBehaviour
{
    [SerializeField] private Sprite[] arrayImage;


    private int rand;
    
    
    public void Setup() 
    {
        rand = Random.Range(0, arrayImage.Length);

    }
}
