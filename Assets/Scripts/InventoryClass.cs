using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int Space => DiamondAmount + GoldAmount*2 + SilverAmount*2 + AmethystAmount + EmeraldAmount + RubyAmount +
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


public class InventoryClass : MonoBehaviour
{
    private Inventory inventory;

    private List<Jewelry> availableJewelry = new List<Jewelry>();
    [SerializeField] private List<Text> texts; 
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
       // Debug.Log(JewelryStock.GetPrice(currentOre,currentGem,currentType));
      // Debug.Log(JewelryStockClass.AllJewelries.Count); 
       inventory = new Inventory
        {
            MaxSpace = 15
        };
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        texts[0].text = inventory.SilverAmount.ToString();
        texts[1].text = inventory.GoldAmount.ToString();
        texts[2].text = inventory.DiamondAmount.ToString();
        texts[3].text = inventory.RubyAmount.ToString();
        texts[4].text = inventory.SapphireAmount.ToString();
        texts[5].text = inventory.EmeraldAmount.ToString();
        texts[6].text = inventory.AmethystAmount.ToString();
        texts[7].text = inventory.SilverIngotsAmount.ToString();
        texts[8].text = inventory.GoldIngotsAmount.ToString();
        texts[9].text = inventory.DiamondShapedAmount.ToString();
        texts[10].text = inventory.RubyShapedAmount.ToString();
        texts[11].text = inventory.SapphireShapedAmount.ToString();
        texts[12].text = inventory.EmeraldShapedAmount.ToString();
        texts[13].text = inventory.AmethystShapedAmount.ToString();
        texts[14].text = inventory.Space + "/" + inventory.MaxSpace;
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
        UpdateTexts();
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
            Jewelry jew = new Jewelry(-1, JewelryStock.GetPrice(currentOre, currentGem, currentType), currentOre, currentGem, currentType);
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
            UpdateTexts();
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
        UpdateTexts();
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
