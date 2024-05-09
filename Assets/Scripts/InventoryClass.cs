using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Inventory
{
    private int goldAmount;
    private int goldIngotsAmount;
    private int silverAmount;
    private int silverIngotsAmount;
    private int diamondAmount;
    private int diamondShapedAmount;
    private int rubyAmount;
    private int rubyShapedAmount;
    private int sapphireAmount;
    private int sapphireShapedAmount;
    private int emeraldAmount;
    private int emeraldShapedAmount;
    private int amethystAmount;
    private int amethystShapedAmount;
}

public enum Ore
{
    Silver,
    Gold
}

public enum Gem
{
    Diamond,
    Ruby,
    Sapphire,
    Emerald,
    Amethyst
}

public enum JewelryType
{
    Necklace,
    Ring,
    Earrings
}

public class Jewelry
{
    private int id;
    private int price;
    private Ore ore;
    private Gem gem;
    private JewelryType type;

    public Jewelry(int i, int p, Ore o, Gem g, JewelryType t)
    {
        id = i;
        price = p;
        ore = o;
        gem = g;
        type = t;
    }
}

public static class JewelryStockClass
{
    public static List<Jewelry> AllJewelries;
    public static List<int> AllPrices = new List<int>()
        {100, 80, 70, 70, 60, 75, 65, 55, 55, 50, 50, 45, 40, 40, 35, 40, 35, 30, 30, 25, 75, 65, 60, 60, 55, 60, 55, 50, 50, 45};
}

public class JewelryStock : MonoBehaviour
{
    private void Awake()
    {
      /*  JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
        JewelryStockClass.AllJewelries.Add
            (new Jewelry("gdn", 100, Ore.Gold, Gem.Diamond, JewelryType.Necklace));
            */
      for (int i = 0; i < 2; i++)
      {
          for (int j = 0; j < 5; j++)
          {
              for (int k = 0; k < 3; k++)
              {
                  JewelryStockClass.AllJewelries.Add(new Jewelry(i+j+k, JewelryStockClass.AllPrices[i+j+k], (Ore)i, (Gem)j, (JewelryType)k));
              }
          }
      }
    }
}
public class InventoryClass : MonoBehaviour
{
    private Inventory inventory;

    private List<Jewelry> availableJewelry = new List<Jewelry>();
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
