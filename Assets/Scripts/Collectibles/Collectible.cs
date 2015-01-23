using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    private bool hasBeenCollected = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && !hasBeenCollected)
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        hasBeenCollected = true;
    }
}
