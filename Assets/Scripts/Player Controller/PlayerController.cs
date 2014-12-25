using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private ShapeController _shapeController;

    [SerializeField]
    private GameManager.Shapes _currentShape = GameManager.Shapes.Sphere;

    private void Awake()
    {
        _currentShape = GameManager.Shapes.Sphere;
        _shapeController = new SphereController();
        _shapeController.InitializeForm(gameObject.transform);
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private void Update ()
	{
	    Vector3 shapeVelocity = _shapeController.GetShapeVelocity();

	    if(Input.GetKeyDown(KeyCode.Alpha1) && _currentShape != GameManager.Shapes.Sphere)
        {
            _shapeController.DisableForm();

            _shapeController = new SphereController();
            _shapeController.InitializeForm(gameObject.transform);
            _shapeController.SetShapeVelocity(shapeVelocity);

            _currentShape = GameManager.Shapes.Sphere;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && _currentShape != GameManager.Shapes.Cube)
        {
            _shapeController.DisableForm();

            _shapeController = new CubeController();
            _shapeController.InitializeForm(gameObject.transform);
            
            _currentShape = GameManager.Shapes.Cube;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && _currentShape != GameManager.Shapes.Triangle)
        {
            _shapeController.DisableForm();

            _shapeController = new TriangleController();
            _shapeController.InitializeForm(gameObject.transform);

            _currentShape = GameManager.Shapes.Triangle;
        }

        else if(Input.GetKeyDown(KeyCode.Alpha4) && _currentShape != GameManager.Shapes.Star)
        {
            _shapeController.DisableForm();

            _shapeController = new StarController();
            _shapeController.InitializeForm(gameObject.transform);
            _shapeController.SetShapeVelocity(shapeVelocity);

            _currentShape = GameManager.Shapes.Star;
        }

	    gameObject.transform.position = _shapeController.GetShapePosition();

        FormUpdate();
	}

    private void FixedUpdate()
    {
        
    }

    private void FormUpdate()
    {
        _shapeController.FormUpdate();
    }
}
