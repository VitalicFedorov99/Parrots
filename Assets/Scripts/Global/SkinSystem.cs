using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SkinSystem : MonoBehaviour, IService
{
    [SerializeField] private ColorSkin[] colorSkins;
    [SerializeField] private Hat[] hats;

    [SerializeField] private ColorSkin chooseColorSkin;
    [SerializeField] private Hat chooseHat;


    public void Setup()
    {
        chooseHat = hats[0];
        chooseColorSkin = colorSkins[0];
    }

    public Hat GetChooseHat() => chooseHat;

    public ColorSkin GetChooseColorSkin() => chooseColorSkin;


    public Hat GetHatWithId(int id)
    {
        return hats[id];
    }

    public ColorSkin GetColorSkinWithId(int id)
    {
        return colorSkins[id];
    }

    public int GetLengthColorSkins() => colorSkins.Length;

    public int GetLengthHats() => hats.Length;

    public void SetChooseColorSkin(ColorSkin skin) => chooseColorSkin = skin;
    public void SetChooseHat(Hat hat) => chooseHat = hat;

    public void SearchHat(string name)
    {
        chooseHat = Array.Find(hats, h => h.Name == name);
        // Debug.Log(chooseHat.HatElement.name);
    }

    public void RotateHatsInGame() 
    {
        foreach (var hat in hats)
        {

            hat.HatElement.transform.rotation = Quaternion.Euler(0, 0, 0);
            hat.HatElement.transform.Rotate(hat.skin.GetRotateInGame());
        }
        // bird.transform.rotation =
    }

    public void RotateHatsInShop()
    {

        foreach (var hat in hats)
        {

            hat.HatElement.transform.rotation = Quaternion.Euler(0, 0, 0);
            hat.HatElement.transform.Rotate(hat.skin.GetRotateInShop());
        }
        // bird.transform.rotation =
    }


    public void SearchColorSkin(string name) => chooseColorSkin = Array.Find(colorSkins, c => c.Name == name);
}
[System.Serializable]
public class ColorSkin : Item
{
    public Texture texture;

}
[System.Serializable]
public class Hat : Item
{

    public GameObject HatElement;
    

}


public class Item
{
    public string Name;
    public Skin skin;

    
}

