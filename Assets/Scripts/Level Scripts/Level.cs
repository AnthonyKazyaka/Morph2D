using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    [SerializeField]
    private float _parTime = 0.0f;
    public float ParTime { get { return _parTime; } set { _parTime = value; } }

    [SerializeField]
    private int _parScore = 0;
    public int ParScore { get { return _parScore; } set { _parScore = value; } }

    [SerializeField]
    private float _elapsedLevelTime = 0.0f;
    public float ElapsedLevelTime { get { return _elapsedLevelTime; } set { _elapsedLevelTime = value; } }

    [SerializeField]
    private int _playerScore = 0;
    public int PlayerScore { get { return _playerScore; } set { _playerScore = value; } }

    [SerializeField]
    private int _coinsCollected = 0;
    public int CoinsCollected { get { return _coinsCollected; } set { _coinsCollected = value; } }

    // [SerializeField]
    private List<GameObject> _inactiveGameObjects = new List<GameObject>();
    public List<GameObject> InactiveGameObjects { get { return _inactiveGameObjects; } set { _inactiveGameObjects = value; } }

    [SerializeField]
    private bool _hasFinishedLevel = false;
    public bool HasFinishedLevel { get { return _hasFinishedLevel; } set { _hasFinishedLevel = value; } }

	// Use this for initialization
	void Start () 
    {
	
 	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!HasFinishedLevel && GameManager.Instance.PlayerController.HasMoved)
        {
            ElapsedLevelTime += Time.deltaTime;
        }
	}

    public void CollectCoin(Coin coin)
    {
        if (!InactiveGameObjects.Contains(coin.gameObject))
        {
            CoinsCollected++;
            InactiveGameObjects.Add(coin.gameObject);
        }

    }

    public void FinishLevel()
    {
        HasFinishedLevel = true;
        // CalculateScore();
    }

    public void CalculateScore()
    {
        // PlayerScore = 
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(Application.loadedLevelName + " Personal Best", PlayerScore);
    }

    public void Reset()
    {
        ElapsedLevelTime = 0.0f;
        CoinsCollected = 0;

        foreach (GameObject inactiveObject in _inactiveGameObjects)
        {
            inactiveObject.SetActive(true);

            if (inactiveObject.GetComponent<Collectible>() != null)
            {
                inactiveObject.GetComponent<Collectible>().HasBeenCollected = false;
            }
        }
    }
}
