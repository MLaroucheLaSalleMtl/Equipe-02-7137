using static ItemInformation;

/// <summary>
/// @author Samuel Paquette
/// @date 13 FEB 19
/// @description A loot in the game
/// </summary>
public class ItemDrop
{
    /// <summary>
    /// The id of the item
    /// </summary>
    public int DropId { get; set; }

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
    
    /// <summary>
    /// is it money or not
    /// </summary>
    public bool IsMoney { get; set; }

    public ItemDrop (int dropId, RarityChances chances, bool isMoney, int minAmount, int maxAmount)
    {
        DropId = dropId;
        Chances = chances;
        IsMoney = isMoney;
        MinimumAmount = minAmount;
        MaximumAmount = maxAmount;
    }

}
