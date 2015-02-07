using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour 
{
    [SerializeField]
    private int _totalCoinsCollected = 0;
    public int TotalCoinsCollected { get { return _totalCoinsCollected; } set { _totalCoinsCollected = value; } }

    [SerializeField]
    private float _totalTimePlayed = 0.0f;
    public float TotalTimePlayed { get { return _totalTimePlayed; } set { _totalTimePlayed = value; } }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
