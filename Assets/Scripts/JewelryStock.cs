using System.Collections.Generic;
using UnityEngine;


public static class JewelryStockClass
{
    public static List<Jewelry> AllJewelries = new();
    public static readonly List<int> AllPrices = new()
        {100, 80, 70, 70, 60, 75, 65, 55, 55, 50, 50, 45, 40, 40, 35, 40, 35, 30, 30, 25, 75, 65, 60, 60, 55, 60, 55, 50, 50, 45};
    

}
public class JewelryStock : MonoBehaviour
{
    
    private void Awake()
    {
        Debug.Log("ASJKBFKDJSDSDJKDSJKAFJKAFFASBJFBJ");
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
    public static int GetPrice(Ore ore, Gem gem, JewelryType jewelryType)
    {
        foreach (var jew in JewelryStockClass.AllJewelries)
        {
            if (jew.GetOre() == ore && jew.GetGem() == gem && jew.GetJewelryType() == jewelryType)
                return jew.GetPrice();
        }
        
        return -1;
    }
}