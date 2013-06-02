using UnityEngine;
using System;
using System.Collections.Generic;
using com.soomla.unity;
using com.soomla.unity.example;

public class BGStartup : MonoBehaviour
{
    public tk2dSprite sky;
    public tk2dSprite tree;
    public tk2dSprite canopy;
    public tk2dSprite ray;
    public tk2dSprite bottom;

    public tk2dSpriteCollectionData bkgdSpriteCollection, bkgdSpriteCollection2;

    void Start()
    {
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.DEFAULT_BG.ItemId))
        {
            sky.SetSprite(bkgdSpriteCollection, "newbg 1");
            tree.SetSprite(bkgdSpriteCollection, "treeland");
            canopy.SetSprite(bkgdSpriteCollection, "treetop");
            ray.SetSprite(bkgdSpriteCollection, "hugeray");
            bottom.SetSprite(bkgdSpriteCollection, "treeland_bottom");
        }
        if (StoreInventory.IsVirtualGoodEquipped(AndysApplesAssets.CBLOSSOM_BG.ItemId))
        {
            sky.SetSprite(bkgdSpriteCollection2, "bg_blossom");
            tree.SetSprite(bkgdSpriteCollection2, "tree_cherry");
            canopy.SetSprite(bkgdSpriteCollection2, "cherryblossombgtop");
            ray.SetSprite(bkgdSpriteCollection2, "hugeray2");
            bottom.SetSprite(bkgdSpriteCollection2, "tree_cherry_bottom");
        }
    }
}