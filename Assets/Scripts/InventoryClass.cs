using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    private Jewelry currentJew;
    private Jewelry lastJew;
    private Gem currentGem;
    private Ore currentOre;
    private JewelryType currentType;

    private int gap;
    // Start is called before the first frame update
    void Start()
    {
        gap = 0;
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
        texts[15].text = inventory.Money.ToString();
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

    public void SellAbby(int n)
    {
        Jewelry jew = null;
        switch (n)
        {
            case 0:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Amethyst, JewelryType.Earrings), Ore.Silver, Gem.Amethyst, JewelryType.Earrings);
                break;
            case 1:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Amethyst, JewelryType.Earrings), Ore.Gold, Gem.Amethyst, JewelryType.Earrings);
                break;
            case 2:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Amethyst, JewelryType.Necklace), Ore.Silver, Gem.Amethyst, JewelryType.Necklace);
                break;
            case 3:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Amethyst, JewelryType.Necklace), Ore.Gold, Gem.Amethyst, JewelryType.Necklace);
                break;
            case 4:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Amethyst, JewelryType.Ring), Ore.Silver, Gem.Amethyst, JewelryType.Ring);
                break;
            case 5:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Amethyst, JewelryType.Ring), Ore.Gold, Gem.Amethyst, JewelryType.Ring);
                break;
        }

        currentJew = jew;
    }
    public void SellJack(int n)
    {
        Jewelry jew = null;
        switch (n)
        {
            case 0:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Amethyst, JewelryType.Ring), Ore.Silver, Gem.Amethyst, JewelryType.Ring);
                break;
            case 1:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Amethyst, JewelryType.Ring), Ore.Gold, Gem.Amethyst, JewelryType.Ring);
                break;
            case 2:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Diamond, JewelryType.Ring), Ore.Silver, Gem.Diamond, JewelryType.Ring);
                break;
            case 3:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Diamond, JewelryType.Ring), Ore.Gold, Gem.Diamond, JewelryType.Ring);
                break;
            case 4:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Ruby, JewelryType.Ring), Ore.Silver, Gem.Ruby, JewelryType.Ring);
                break;
            case 5:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Ruby, JewelryType.Ring), Ore.Gold, Gem.Ruby, JewelryType.Ring);
                break;
            case 6:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Sapphire, JewelryType.Ring), Ore.Silver, Gem.Sapphire, JewelryType.Ring);
                break;
            case 7:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Sapphire, JewelryType.Ring), Ore.Gold, Gem.Sapphire, JewelryType.Ring);
                break;
            case 8:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Emerald, JewelryType.Ring), Ore.Silver, Gem.Emerald, JewelryType.Ring);
                break;
            case 9:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Emerald, JewelryType.Ring), Ore.Gold, Gem.Emerald, JewelryType.Ring);
                break;
        }

        currentJew = jew;
    }
    public void SellLilly(int n)
    {
        Jewelry jew = null;
        switch (n)
        {
            case 0:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Ruby, JewelryType.Earrings), Ore.Silver, Gem.Amethyst, JewelryType.Earrings);
                break;
            case 1:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Sapphire, JewelryType.Necklace), Ore.Gold, Gem.Sapphire, JewelryType.Necklace);
                break;
            case 2:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Amethyst, JewelryType.Necklace), Ore.Silver, Gem.Amethyst, JewelryType.Necklace);
                break;
            case 3:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Emerald, JewelryType.Necklace), Ore.Gold, Gem.Emerald, JewelryType.Necklace);
                break;
            case 4:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Emerald, JewelryType.Ring), Ore.Silver, Gem.Emerald, JewelryType.Ring);
                break;
            case 5:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Ruby, JewelryType.Ring), Ore.Gold, Gem.Ruby, JewelryType.Ring);
                break;
        }

        currentJew = jew;
    } 
    public void SellMartha(int n)
    {
        Jewelry jew = null;
        switch (n)
        {
            case 0:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Ruby, JewelryType.Earrings), Ore.Gold, Gem.Amethyst, JewelryType.Earrings);
                break;
            case 1:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Sapphire, JewelryType.Necklace), Ore.Silver, Gem.Sapphire, JewelryType.Necklace);
                break;
            case 2:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Amethyst, JewelryType.Necklace), Ore.Gold, Gem.Amethyst, JewelryType.Necklace);
                break;
            case 3:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Emerald, JewelryType.Necklace), Ore.Silver, Gem.Emerald, JewelryType.Necklace);
                break;
            case 4:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Emerald, JewelryType.Ring), Ore.Gold, Gem.Emerald, JewelryType.Ring);
                break;
            case 5:
                jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Ruby, JewelryType.Ring), Ore.Silver, Gem.Ruby, JewelryType.Ring);
                break;
        }

        currentJew = jew;
    }
    
    public void SellMillie(int n)
    {
        Jewelry jew = null;
        switch (n)
        {
            case 0:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Emerald, JewelryType.Earrings), Ore.Silver, Gem.Emerald, JewelryType.Earrings);
                break;
            case 1:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Emerald, JewelryType.Earrings), Ore.Gold, Gem.Emerald, JewelryType.Earrings);
                break;
            case 2:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Diamond, JewelryType.Earrings), Ore.Silver, Gem.Diamond, JewelryType.Earrings);
                break;
            case 3:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Diamond, JewelryType.Earrings), Ore.Gold, Gem.Diamond, JewelryType.Earrings);
                break;
            case 4:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Ruby, JewelryType.Earrings), Ore.Silver, Gem.Ruby, JewelryType.Earrings);
                break;
            case 5:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Ruby, JewelryType.Earrings), Ore.Gold, Gem.Ruby, JewelryType.Earrings);
                break;
            case 6:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Sapphire, JewelryType.Earrings), Ore.Silver, Gem.Sapphire, JewelryType.Earrings);
                break;
            case 7:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Sapphire, JewelryType.Earrings), Ore.Gold, Gem.Sapphire, JewelryType.Earrings);
                break;
            case 8:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Ruby, JewelryType.Necklace), Ore.Silver, Gem.Ruby, JewelryType.Necklace);
                break;
            case 9:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Ruby, JewelryType.Necklace), Ore.Gold, Gem.Ruby, JewelryType.Necklace);
                break;
            case 10:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Silver, Gem.Diamond, JewelryType.Necklace), Ore.Silver, Gem.Diamond, JewelryType.Necklace);
                break;
            case 11:
                 jew = new Jewelry(-1, JewelryStock.GetPrice(Ore.Gold, Gem.Diamond, JewelryType.Necklace), Ore.Gold, Gem.Diamond, JewelryType.Necklace);
                break;
        }

        currentJew = jew;
    }

    public void Sell()
    {
        Debug.Log(currentJew.GetOre().ToString() + currentJew.GetGem() + currentJew.GetJewelryType());
        var aj = new List<Jewelry>(availableJewelry);
        foreach (var jew in aj)
        {
            if (jew.GetOre() == currentJew.GetOre() && jew.GetGem() == currentJew.GetGem() &&
                jew.GetJewelryType() == currentJew.GetJewelryType())
            {
                if(lastJew != null)
                    if (jew.GetOre() == lastJew.GetOre() && jew.GetGem() == lastJew.GetGem() &&
                        jew.GetJewelryType() == lastJew.GetJewelryType())
                    {
                        Debug.Log("EQUALS");
                        gap = math.min(gap + 5, 30);
                        inventory.Money -= gap;
                    }
                    else
                    {
                        gap = 0;
                    }
                availableJewelry.Remove(jew);
                inventory.Money += jew.GetPrice();
                UpdateTexts();
                lastJew = jew;
                break;
            }
            
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
                        Debug.Log(currentOre.ToString() +currentGem +currentType);
                    }
                    break;
                case JewelryType.Ring:
                    if (GetShapedGemAmount(jew.GetGem()) >= 2 && GetOreIngotsAmount(jew.GetOre()) >= 2)
                    {
                        RemovePieces(jew);
                        availableJewelry.Add(jew);
                        Debug.Log(currentOre.ToString() +currentGem +currentType);
                    }
                    break;
                case JewelryType.Earrings:
                    if (GetShapedGemAmount(jew.GetGem()) >= 4 && GetOreIngotsAmount(jew.GetOre()) >= 2)
                    {
                        RemovePieces(jew);
                        availableJewelry.Add(jew);
                        Debug.Log(currentOre.ToString() +currentGem +currentType);
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
        switch (jew.GetJewelryType())
        {
            case JewelryType.Necklace:
                switch (jew.GetOre())
                {
                    case Ore.Silver:
                        inventory.SilverIngotsAmount -= 3;
                        break;
                    case Ore.Gold:
                        inventory.GoldIngotsAmount -= 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (jew.GetGem())
                {
                    case Gem.Diamond:
                        inventory.DiamondShapedAmount -= 5;
                        break;
                    case Gem.Ruby:
                        inventory.RubyShapedAmount -= 5;
                        break;
                    case Gem.Sapphire:
                        inventory.SapphireShapedAmount -= 5;
                        break;
                    case Gem.Emerald:
                        inventory.EmeraldShapedAmount -= 5;
                        break;
                    case Gem.Amethyst:
                        inventory.AmethystShapedAmount -= 5;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case JewelryType.Ring:
                switch (jew.GetOre())
                {
                    case Ore.Silver:
                        inventory.SilverIngotsAmount -= 2;
                        break;
                    case Ore.Gold:
                        inventory.GoldIngotsAmount -= 2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (jew.GetGem())
                {
                    case Gem.Diamond:
                        inventory.DiamondShapedAmount -= 2;
                        break;
                    case Gem.Ruby:
                        inventory.RubyShapedAmount -= 2;
                        break;
                    case Gem.Sapphire:
                        inventory.SapphireShapedAmount -= 2;
                        break;
                    case Gem.Emerald:
                        inventory.EmeraldShapedAmount -= 2;
                        break;
                    case Gem.Amethyst:
                        inventory.AmethystShapedAmount -= 2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case JewelryType.Earrings:
                switch (jew.GetOre())
                {
                    case Ore.Silver:
                        inventory.SilverIngotsAmount -= 2;
                        break;
                    case Ore.Gold:
                        inventory.GoldIngotsAmount -= 2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (jew.GetGem())
                {
                    case Gem.Diamond:
                        inventory.DiamondShapedAmount -= 4;
                        break;
                    case Gem.Ruby:
                        inventory.RubyShapedAmount -= 4;
                        break;
                    case Gem.Sapphire:
                        inventory.SapphireShapedAmount -= 4;
                        break;
                    case Gem.Emerald:
                        inventory.EmeraldShapedAmount -= 4;
                        break;
                    case Gem.Amethyst:
                        inventory.AmethystShapedAmount -= 4;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        UpdateTexts();
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
