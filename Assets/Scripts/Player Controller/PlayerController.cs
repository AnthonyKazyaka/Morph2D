using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private ShapeController _shapeController = new ShapeController();
    public enum Shapes
    {
        Sphere,
        Cube,
        Triangle,
        Star
    }

    private Shapes _currentShape = Shapes.Cube;

    private void Awake()
    {
        
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Alpha1) && _currentShape != Shapes.Sphere)
        {
            _shapeController = new SphereController();
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && _currentShape != Shapes.Cube)
        {
            Vector3 playerPosition = transform.GetChild(0).position;
            //_shapeController = new SphereController();
            
            GameObject playerCube = GameObject.Instantiate(Resources.Load(@"Assets\Prefabs\Shape Prefabs\Square"), playerPosition, new Quaternion()) as GameObject;
            playerCube.transform.parent = this.transform;
            _currentShape = Shapes.Cube;
        }
	}

    private void FixedUpdate()
    {
        
    }

    private void FormUpdate()
    {
        _shapeController.FormUpdate();
    }
}
