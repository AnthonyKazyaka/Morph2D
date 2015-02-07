using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    [SerializeField]
    private float _parTime = 0.0f;
    public float ParTime { get { return _parTime; } set { _parTime = value; } }

    private int _parScore = 0;
    public int ParScore { get { return _parScore; } set { _parScore = value; } }

    private float _levelTime = 0.0f;
    public float LevelTime { get { return _levelTime; } set { _levelTime = value; } }

    private List<GameObject> _inactiveGameObjects = new List<GameObject>();
    public List<GameObject> InactiveGameObjects { get { return _inactiveGameObjects; } set { _inactiveGameObjects = value; } }


	// Use this for initialization
	void Start () {
	
 	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FinishLevel()
    {

    }

    public void TallyScore()
    {

    }
}
