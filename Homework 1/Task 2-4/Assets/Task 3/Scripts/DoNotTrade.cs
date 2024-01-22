using UnityEngine;

public class DoNotTrade : ITrading
{
    public void Trade()
    {
        Debug.Log("С такими не торгуем!");
    }
}
