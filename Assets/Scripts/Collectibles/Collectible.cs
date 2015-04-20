using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    private bool _hasBeenCollected = false;
    public bool HasBeenCollected { get { return _hasBeenCollected; } set { _hasBeenCollected = value; } }

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.tag.Equals("Player") && !_hasBeenCollected)
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        _hasBeenCollected = true;
    }
}
