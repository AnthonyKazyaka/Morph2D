using UnityEngine;
using System.Collections;

public class LoadLevelButton : MonoBehaviour {

    public string levelToLoad = "SphereTest";

    public float xPosition = 0.0f;
    public float yPosition = 0.0f;
    public float width = 0.0f;
    public float height = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnGUI()
    {
        if(GUI.Button(new Rect(xPosition, yPosition, width, height), levelToLoad))
            Application.LoadLevel(levelToLoad);
    }
}
