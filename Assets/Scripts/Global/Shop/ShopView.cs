using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour, IService
{
    [SerializeField] private PlayerSkin playerSkin;
    [SerializeField] private SkinSystem skinSystem;
    [SerializeField] private IntVariable scorePlayer;
    [SerializeField] private TMPro.TMP_Text nameTypeTMP;
    [SerializeField] private TMPro.TMP_Text nameItemTMP;
    [SerializeField] private TMPro.TMP_Text costItemTMP;
    [SerializeField] private TMPro.TMP_Text playerScoreTMP;
    [SerializeField] private GameObject imageBlockButtonBuy;
    [SerializeField] private GameObject imageBlockButtonApply;


    private ShopModelColor shopModelColor;
    private ShopModelHat shopModelHat;
    private ShopModel currentShopModel;

    private Item currentItem;

    public void Setup()
    {
        playerScoreTMP.text = scorePlayer.GetCount().ToString();
        playerSkin.SetupColor(skinSystem.GetChooseColorSkin().texture);
        playerSkin.SetupHat(skinSystem.GetChooseHat());
        shopModelColor = new ShopModelColor(skinSystem.GetLengthColorSkins(), skinSystem.GetColorSkinWithId(0), skinSystem,playerSkin);
        shopModelHat = new ShopModelHat(skinSystem.GetLengthHats(), skinSystem.GetHatWithId(0),skinSystem,playerSkin);
        currentShopModel = shopModelColor;
        currentShopModel.PressButtonTypeItem(ref currentItem, nameTypeTMP);
        nameItemTMP.text = currentItem.Name;
        costItemTMP.text = currentItem.skin.GetCost().ToString();
        SetActiveBlockButtonBuy();
        currentShopModel.SetActiveBlockButtonApply(imageBlockButtonApply);
    }

    public void PressButtonTypeItem() 
    {

        if (currentShopModel == shopModelColor) {
            currentShopModel = shopModelHat;
            currentShopModel.PressButtonTypeItem(ref currentItem, nameTypeTMP);
            nameItemTMP.text = currentItem.Name;
            costItemTMP.text = currentItem.skin.GetCost().ToString();
            SetActiveBlockButtonBuy();
            currentShopModel.SetActiveBlockButtonApply(imageBlockButtonApply);
            return;
        }
        else 
        {
            currentShopModel = shopModelColor;
            currentShopModel.PressButtonTypeItem(ref currentItem, nameTypeTMP);
            nameItemTMP.text = currentItem.Name;
            costItemTMP.text = currentItem.skin.GetCost().ToString();
            SetActiveBlockButtonBuy();
            currentShopModel.SetActiveBlockButtonApply(imageBlockButtonApply);
        }
    }
    public void PressButtonBuy()
    {
        currentItem.skin.Buy(); 
        scorePlayer.Add(-currentItem.skin.GetCost());
        SetActiveBlockButtonBuy();
        currentShopModel.SetActiveBlockButtonApply(imageBlockButtonApply);
        playerScoreTMP.text = scorePlayer.GetCount().ToString();
    }

    public void PressButtonApply()
    {
        currentShopModel.PressButtonApply();
        currentShopModel.SetActiveBlockButtonApply(imageBlockButtonApply);
    }

    public void PressButtonNextItem(int addId)
    {
        currentShopModel.PressButtonNextItem(addId, ref currentItem);
        nameItemTMP.text = currentItem.Name;
        costItemTMP.text = currentItem.skin.GetCost().ToString();
        SetActiveBlockButtonBuy();
        currentShopModel.SetActiveBlockButtonApply(imageBlockButtonApply);
    }

    private void SetActiveBlockButtonBuy()
    {
            if (!currentItem.skin.GetIsBuy())
                if (scorePlayer.GetCount() >= currentItem.skin.GetCost())
                    imageBlockButtonBuy.SetActive(false);
                else imageBlockButtonBuy.SetActive(true);
            else imageBlockButtonBuy.SetActive(true);
    }
}
