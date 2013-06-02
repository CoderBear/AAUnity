using UnityEngine;
using System;
using System.Collections.Generic;
using com.soomla.unity;
using com.soomla.unity.example;

public class BGStartup : MonoBehaviour
{
    public tk2dSprite sky, sky2;
    public tk2dSprite tree, tree2;
    public tk2dSprite canopy, canopy2;
    public tk2dSprite ray, ray2;
    public tk2dSprite bottom, bottom2;

    void Start()
    {

        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.DEFAULT_BG.ItemId))
        {
            sky.gameObject.SetActive(true);
            tree.gameObject.SetActive(true);
            canopy.gameObject.SetActive(true);
            ray.gameObject.SetActive(true);
            bottom.gameObject.SetActive(true);

            sky2.gameObject.SetActive(false);
            tree2.gameObject.SetActive(false);
            canopy2.gameObject.SetActive(false);
            ray2.gameObject.SetActive(false);
            bottom2.gameObject.SetActive(false);
        }
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.CBLOSSOM_BG.ItemId))
        {
            sky.gameObject.SetActive(false);
            tree.gameObject.SetActive(false);
            canopy.gameObject.SetActive(false);
            ray.gameObject.SetActive(false);
            bottom.gameObject.SetActive(false);

            sky2.gameObject.SetActive(true);
            tree2.gameObject.SetActive(true);
            canopy2.gameObject.SetActive(true);
            ray2.gameObject.SetActive(true);
            bottom2.gameObject.SetActive(true);
        }
    }
}