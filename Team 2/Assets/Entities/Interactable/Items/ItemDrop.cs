using static ItemInformation;

/// <summary>
/// @author Samuel Paquette
/// @date 13 FEB 19
/// @description A loot in the game
/// </summary>
public class ItemDrop
{
    /// <summary>
    /// The actual item
    /// </summary>
    public Item Loot { get; set; }

    /// <summary>
    /// The percentage chances to receive the loot
    /// </summary>
    public RarityChances Chances { get; set; }

    /// <summary>
    /// The minimum amount of that item you can receive
    /// </summary>
    public int MinimumAmount { get; set; }

    /// <summary>
    /// The maximum amount of that item you can receive
    /// </summary>
    public int MaximumAmount { get; set; }
    

    public ItemDrop (Item loot, RarityChances chances, int minAmount, int maxAmount)
    {
        Loot = loot;
        Chances = chances;
        MinimumAmount = minAmount;
        MaximumAmount = maxAmount;
    }

}
