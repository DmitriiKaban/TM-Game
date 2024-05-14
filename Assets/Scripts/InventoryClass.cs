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

public enum JP
{
    Gold,
    Silver,
    Diamond,
    Ruby,
    Sapphire,
    Emerald,
    Amethyst,
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

    public static int GetPrice(Ore ore, Gem gem, JewelryType jewelryType)
    {
        foreach (var jew in AllJewelries)
        {
            if (jew.GetOre() == ore && jew.GetGem() == gem && jew.GetJewelryType() == jewelryType)
                return jew.GetPrice();
        }

        return -1;
    }
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

    private JP lastPiece;
    private Gem currentGem;
    private Ore currentOre;
    private JewelryType currentType;
    // Start is called before the first frame update
    void Start()
    {
        lastPiece = JP.Gold;
        currentOre = Ore.Gold;
        currentGem = Gem.Diamond;
        currentType = JewelryType.Necklace;
        inventory = new Inventory
        {
            MaxSpace = 10
        };
    }

    public void Dig(char c)
    {
        if(inventory.Space == inventory.MaxSpace)
            return;
        switch (c)
        {
            case '2':
                {
                    inventory.DiamondAmount++;
                }
                break;
            case 
                '3':
                {
                    inventory.RubyAmount++;
                }
                break;
            case 
                '4':
                {
                    inventory.SapphireAmount++;
                }
                break;
            case 
                '5':
                {
                    inventory.EmeraldAmount++;
                }
                break;
            case 
                '6':
                {
                    inventory.AmethystAmount++;
                }
                break;
            case 
                '7':
                {
                    inventory.GoldAmount++;
                }
                break;
            case '0':
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

    public void Choise(int n)
    {
        switch (n)
        {
            case 0:
                currentOre = Ore.Silver;
                lastPiece = JP.Silver;
                break;

            case 7:
                currentOre = Ore.Gold;
                lastPiece = JP.Gold;
                break;

            case 2:
                currentGem = Gem.Diamond;
                lastPiece = JP.Diamond;
                break;
            case 3:
                currentGem = Gem.Ruby;
                lastPiece = JP.Ruby;
                break;
            case 4:
                currentGem = Gem.Sapphire;
                lastPiece = JP.Sapphire;
                break;
            case 5:
                currentGem = Gem.Emerald;
                lastPiece = JP.Emerald;
                break;
            case 6:
                currentGem = Gem.Amethyst;
                lastPiece = JP.Amethyst;
                break;
            case 8:
                currentType = JewelryType.Necklace;
                break;
            case 9:
                currentType = JewelryType.Earrings;
                break; 
            case 1:
                currentType = JewelryType.Ring;
                break;

           

        }
    }

    public void CraftJew()
    {
        {
            Jewelry jew = new Jewelry(-1, JewelryStockClass.GetPrice(currentOre, currentGem, currentType), currentOre, currentGem, currentType);
            switch (currentType)
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
    }
    public void Craft()
    {
        switch (lastPiece)
        {
            case JP.Diamond:
                if (inventory.DiamondAmount > 0)
                {
                    inventory.DiamondAmount--;
                    inventory.DiamondShapedAmount += 3;
                }
                break;
                case 
                JP.Ruby:
                    if (inventory.RubyAmount > 0)
                    {
                        inventory.RubyAmount--;
                        inventory.RubyShapedAmount += 3;
                    }
                    break;
               case 
                   JP.Sapphire :
                   if (inventory.SapphireAmount > 0)
                   {
                       inventory.SapphireAmount--;
                       inventory.SapphireShapedAmount += 3;
                   }
                   break;
                case 
                   JP.Emerald :
                    if (inventory.EmeraldAmount > 0)
                    {
                        inventory.EmeraldAmount--;
                        inventory.EmeraldShapedAmount += 3;
                    }
                break;
                case 
                JP.Amethyst :
                    if (inventory.AmethystAmount > 0)
                    {
                        inventory.AmethystAmount--;
                        inventory.AmethystShapedAmount += 3;
                    }
                    break;
                case 
                JP.Gold:
                    if (inventory.GoldAmount > 0)
                    {
                        inventory.GoldAmount--;
                        inventory.GoldIngotsAmount += 2;
                    }
                    break;
                case JP.Silver:
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
