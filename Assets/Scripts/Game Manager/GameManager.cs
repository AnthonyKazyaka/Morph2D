using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    // Our GameManager
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


    // Creates a unique GameManager that can't be destroyed
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        _instance = this;

        //Initialize the four shapes with their models
    }

	// Use this for initialization
	private void Start ()
    {
	
	}
	
	// Update is called once per frame
	private void Update ()
    {
	
	}
}
