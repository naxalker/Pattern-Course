using UnityEngine;

public enum FactionType {
    Beggar,
    Citizen,
    Knight
}

public class Player : MonoBehaviour
{
    public FactionType Type;

    [SerializeField] private Merchant merchant;

    private void Update()
    {
        if (Type == FactionType.Beggar)
        {
            merchant.SetTradeStrategy(new DoNotTrade());
        } else if (Type == FactionType.Citizen)
        {
            merchant.SetTradeStrategy(new TradingFruits());
        } else if (Type == FactionType.Knight)
        {
            merchant.SetTradeStrategy(new TradingArmor());
        }
    }
}
