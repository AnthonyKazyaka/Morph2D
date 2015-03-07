using UnityEngine;
using System.Collections;

public class Coin : Collectible 
{

    protected override void Collect()
    {
        base.Collect();
        GameManager.Instance.CurrentLevel.CollectCoin(this);
        this.gameObject.SetActive(false);
    }
}
