using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel
{
    public virtual void PressButtonTypeItem(ref Item currentItem, TMPro.TMP_Text nameTypeTMP) 
    {
        
    }

    public virtual void PressButtonNextItem(int addId, ref Item currentItem) 
    {
    
    }

    public virtual void PressButtonApply() 
    {
    
    }

    public virtual void SetActiveBlockButtonApply(GameObject imageBlockButtonApply) 
    {
    
    }

   
}


public class ShopModelColor: ShopModel 
{

    private ColorSkin currentColorSkin;
    private int maxColor;
    private int idColor;
    private SkinSystem skinSystem;
    private PlayerSkin playerSkin;
    public ShopModelColor(int maxElement, ColorSkin currentItemElement,SkinSystem skin,PlayerSkin pSkin) 
    {
        maxColor = maxElement;
        idColor = 0;
        currentColorSkin = currentItemElement;
        skinSystem = skin;
        playerSkin = pSkin;
    }


    public override void PressButtonTypeItem(ref Item currentItem, TMPro.TMP_Text nameTypeTMP)
    {
        currentItem = currentColorSkin;
        nameTypeTMP.text = "÷вет";
    }

    public override void PressButtonNextItem(int addId, ref Item currentItem)
    {
        idColor += addId;
        if (idColor < 0)
        {
            idColor = maxColor - 1;
        }
        if (idColor >= maxColor)
        {
            idColor = 0;
        }
        currentColorSkin = skinSystem.GetColorSkinWithId(idColor);
        playerSkin.SetupColor(currentColorSkin.texture);
        currentItem = currentColorSkin;
    }

    public override void PressButtonApply()
    {
        skinSystem.SetChooseColorSkin(currentColorSkin);
    }

    public override void SetActiveBlockButtonApply(GameObject imageBlockButtonApply)
    {
        bool flag;
        if (currentColorSkin == skinSystem.GetChooseColorSkin())
        {
            imageBlockButtonApply.SetActive(true);
            return;
        }
        if (currentColorSkin.skin.GetIsBuy())
            flag = false;
        else
            flag = true;
        imageBlockButtonApply.SetActive(flag);
    }
}








public class ShopModelHat: ShopModel 
{
    private int maxHat;
    private Hat currentHat;
    private int idHat;
    private SkinSystem skinSystem;
    private PlayerSkin playerSkin;
    public ShopModelHat(int maxElement, Hat currentItemElement, SkinSystem skin, PlayerSkin pSkin) 
    {
        maxHat = maxElement;
        idHat = 0;
        currentHat = currentItemElement;
        skinSystem = skin;
        playerSkin = pSkin;
    }

  

    public override void PressButtonTypeItem(ref Item currentItem, TMPro.TMP_Text nameTypeTMP)
    {
        currentItem = currentHat;
        nameTypeTMP.text = "Ўл€па";
    }


    public override void PressButtonNextItem(int addId, ref Item currentItem)
    {
        idHat += addId;
        if (idHat < 0)
        {
            idHat = maxHat - 1;
        }
        if (idHat >= maxHat)
        {
            idHat = 0;
        }
        currentHat = skinSystem.GetHatWithId(idHat);
        playerSkin.SetupHat(currentHat,currentHat.skin.OffsetShop);
        currentItem = currentHat;
    }

    public override void PressButtonApply()
    {
       skinSystem.SetChooseHat(currentHat);
    }

    public override void SetActiveBlockButtonApply(GameObject imageBlockButtonApply)
    {
        bool flag;
        if (currentHat == skinSystem.GetChooseHat())
        {
            imageBlockButtonApply.SetActive(true);
            return;
        }
        if (currentHat.skin.GetIsBuy())
            flag = false;
        else
            flag = true;
        imageBlockButtonApply.SetActive(flag);
    }
}

