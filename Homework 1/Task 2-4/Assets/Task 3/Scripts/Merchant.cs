using UnityEngine;

public class Merchant : MonoBehaviour
{
    private ITrading _tradeBehavior;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player)) {
            _tradeBehavior.Trade();
        }
    }

    public void SetTradeStrategy(ITrading tradeBehavior)
    {
        _tradeBehavior = tradeBehavior;
    }
}
