using UnityEngine;
using System.Collections;

public class LevelFinish : MonoBehaviour {

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.collider.tag.Equals("Player"))
        {
            GameManager.Instance.CurrentLevel.FinishLevel();
        }
    }

}
