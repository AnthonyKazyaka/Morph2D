﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    // Our GameManager
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField]
    private GameObject _spherePrefab;
    public GameObject SpherePrefab { get { return _spherePrefab; } }

    [SerializeField]
    private GameObject _trianglePrefab;
    public GameObject TrianglePrefab { get { return _trianglePrefab; } }

    [SerializeField]
    private GameObject _cubePrefab;
    public GameObject CubePrefab { get { return _cubePrefab; } }

    [SerializeField]
    private GameObject _starPrefab;
    public GameObject StarPrefab { get { return _starPrefab; } }

    public enum Shapes
    {
        Sphere,
        Cube,
        Triangle,
        Star
    }


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

    public GameObject InstantiateShape(Shapes shape)
    {
        GameObject instantiatedShape;
        switch (shape)
        {
            case Shapes.Sphere:
                instantiatedShape = (GameObject)Instantiate(SpherePrefab);
                break;
            case Shapes.Cube:
                instantiatedShape = (GameObject)Instantiate(CubePrefab);
                break;
            case Shapes.Triangle:
                instantiatedShape = (GameObject)Instantiate(TrianglePrefab);
                break;
            case Shapes.Star:
                instantiatedShape = (GameObject)Instantiate(StarPrefab);
                break;
            default:
                // If we don't know what is being instantiated (would never happen), give them a sphere
                instantiatedShape = (GameObject)Instantiate(SpherePrefab);
                break;
        }

        return instantiatedShape;
    }

    public void DestroyShape(GameObject shapeObject)
    {
        Destroy(shapeObject);
    }
}
