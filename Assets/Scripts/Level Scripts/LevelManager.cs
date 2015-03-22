using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    private List<Collectible> _levelCollectibles = new List<Collectible>();
    public List<Collectible> LevelCollectibles {get { return _levelCollectibles; } set { _levelCollectibles = value; }}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
