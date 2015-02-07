using UnityEngine;
using System.Collections;

public class Coin : Collectible 
{

    protected override void Collect()
    {
        base.Collect();
        GameManager.Instance.PlayerController.CollectCoin();
        this.gameObject.SetActive(false);
    }
}
