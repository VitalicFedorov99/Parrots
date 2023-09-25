using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSkin
{
    [SerializeField] private Transform positionHat;
    [SerializeField] private Material material;
    private GameObject hat;

    [SerializeField] private GameObject parent;

    

    public void SetupColor(Texture newText)
    {
        material.SetTexture("_MainTex", newText);
    }

    public void SetupHat(Hat hat1)
    {
        Debug.Log(hat1.HatElement.name);
        var go = hat1.HatElement;
        if (hat != null)
        {
            hat.transform.parent = null;
            hat.transform.position = new Vector3(1000, 1000, 1000);
        }
        hat = hat1.HatElement;
        hat.transform.SetParent(parent.transform);
        hat.transform.position = positionHat.position;
    }







}
