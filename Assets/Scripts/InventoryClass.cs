using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Inventory
{
    public int Money;
    public int GoldAmount;
    public int GoldIngotsAmount;
    public int SilverAmount;
    public int SilverIngotsAmount;
    public int DiamondAmount;
    public int DiamondShapedAmount;
    public int RubyAmount;
    public int RubyShapedAmount;
    public int SapphireAmount;
    public int SapphireShapedAmount;
    public int EmeraldAmount;
    public int EmeraldShapedAmount;
    public int AmethystAmount;
    public int AmethystShapedAmount;

    public int Space => DiamondAmount + GoldAmount + SilverAmount + AmethystAmount + EmeraldAmount + RubyAmount +
                        SapphireAmount;

    public int MaxSpace;

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

    public int GetPrice()
    {
        return price;
    }

    public JewelryType GetJewelryType()
    {
        return type;
    }

    public Ore GetOre()
    {
        return ore;
    }

    public Gem GetGem()
    {
        return gem;
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
        inventory = new Inventory
        {
            MaxSpace = 10
        };
    }

    public void Dig(object obj)
    {
        switch (obj.ToString())
        {
            case "Diamond":
                {
                    inventory.DiamondAmount++;
                }
                break;
            case 
                "Ruby":
                {
                    inventory.RubyAmount++;
                }
                break;
            case 
                "Sapphire":
                {
                    inventory.SapphireAmount++;
                }
                break;
            case 
                "Emerald":
                {
                    inventory.EmeraldAmount++;
                }
                break;
            case 
                "Amethyst":
                {
                    inventory.AmethystAmount++;
                }
                break;
            case 
                "Gold":
                {
                    inventory.GoldAmount++;
                }
                break;
            case "Silver":
                {
                    inventory.SilverAmount++;
                }
                break;
        }

    }

    public void Sell(Jewelry jew)
    {
        if (availableJewelry.Contains(jew))
        {
            availableJewelry.Remove(jew);
            inventory.Money += jew.GetPrice();
        }   
    }
    public void Craft(object obj)
    {
        if (obj.GetType() == typeof(Jewelry))
        {
            Jewelry jew = (Jewelry)obj;
            switch (jew.GetJewelryType())
            {
                case JewelryType.Necklace:
                    if (GetShapedGemAmount(jew.GetGem()) >= 5 && GetOreIngotsAmount(jew.GetOre()) >= 3)
                    {
                        RemovePieces(jew);
                        availableJewelry.Add(jew);
                    }
                    break;
                case JewelryType.Ring:
                    if (GetShapedGemAmount(jew.GetGem()) >= 2 && GetOreIngotsAmount(jew.GetOre()) >= 2)
                    {
                        RemovePieces(jew);
                        availableJewelry.Add(jew);
                    }
                    break;
                case JewelryType.Earrings:
                    if (GetShapedGemAmount(jew.GetGem()) >= 4 && GetOreIngotsAmount(jew.GetOre()) >= 2)
                    {
                        RemovePieces(jew);
                        availableJewelry.Add(jew);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        switch (obj.ToString())
        {
            case "Diamond":
                if (inventory.DiamondAmount > 0)
                {
                    inventory.DiamondAmount--;
                    inventory.DiamondShapedAmount += 3;
                }
                break;
                case 
                "Ruby":
                    if (inventory.RubyAmount > 0)
                    {
                        inventory.RubyAmount--;
                        inventory.RubyShapedAmount += 3;
                    }
                    break;
               case 
                   "Sapphire":
                   if (inventory.SapphireAmount > 0)
                   {
                       inventory.SapphireAmount--;
                       inventory.SapphireShapedAmount += 3;
                   }
                   break;
                case 
                   "Emerald":
                    if (inventory.EmeraldAmount > 0)
                    {
                        inventory.EmeraldAmount--;
                        inventory.EmeraldShapedAmount += 3;
                    }
                break;
                case 
                "Amethyst":
                    if (inventory.AmethystAmount > 0)
                    {
                        inventory.AmethystAmount--;
                        inventory.AmethystShapedAmount += 3;
                    }
                    break;
                case 
                "Gold":
                    if (inventory.GoldAmount > 0)
                    {
                        inventory.GoldAmount--;
                        inventory.GoldIngotsAmount += 2;
                    }
                    break;
                case "Silver":
                if (inventory.SilverAmount > 0)
                {
                    inventory.SilverAmount--;
                    inventory.SilverIngotsAmount += 2;
                }
                break;
        }
    }

    private int GetGemAmount(Gem gem)
    {
        switch (gem)
        {
            case Gem.Diamond:
                return inventory.DiamondAmount;
                break;
            case Gem.Ruby:
                return inventory.RubyAmount;
                break;
            case Gem.Sapphire:
                return inventory.SapphireAmount;
                break;
            case Gem.Emerald:
                return inventory.EmeraldAmount;
                break;
            case Gem.Amethyst:
                return inventory.AmethystAmount;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gem), gem, null);
        }
    }

    private void RemovePieces(Jewelry jew)
    {
        
    }
    private int GetShapedGemAmount(Gem gem)
    {
        switch (gem)
        {
            case Gem.Diamond:
                return inventory.DiamondShapedAmount;
                break;
            case Gem.Ruby:
                return inventory.RubyShapedAmount;
                break;
            case Gem.Sapphire:
                return inventory.SapphireShapedAmount;
                break;
            case Gem.Emerald:
                return inventory.EmeraldShapedAmount;
                break;
            case Gem.Amethyst:
                return inventory.AmethystShapedAmount;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gem), gem, null);
        }
    }
    private int GetOreAmount(Ore ore)
    {
        switch (ore)
        {
            case Ore.Silver:
                return inventory.SilverAmount;
                break;
            case Ore.Gold:
                return inventory.SilverAmount;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ore), ore, null);
        }
    } 
    private int GetOreIngotsAmount(Ore ore)
    {
        switch (ore)
        {
            case Ore.Silver:
                return inventory.SilverIngotsAmount;
                break;
            case Ore.Gold:
                return inventory.GoldIngotsAmount;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ore), ore, null);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
