using System.Configuration;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private ShapeController _shapeController = new SphereController();

    private Vector3 _shapeVelocity = Vector3.zero;

    [SerializeField]
    private GameManager.Shapes _currentShape = GameManager.Shapes.Sphere;

    [SerializeField]
    private bool _canChangeShape = true;
    public bool CanChangeShape { get { return _canChangeShape; } private set { _canChangeShape = value; } }

    [SerializeField]
    private float _shapeChangeDisableTimer = 0.50f;
    public float ShapeChangeDisableTimer { get { return _shapeChangeDisableTimer; } }

    private bool _hasMoved = false;
    public bool HasMoved { get { return _hasMoved; } set { _hasMoved = value; } }


    private void Awake()
    {
        SpawnPlayer();
    }
    
	// Use this for initialization
	void Start () 
    {
        InitializePlayer();
	}
	
	// Update is called once per frame
	private void Update ()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.Instance.IsPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }

        if (!GameManager.Instance.IsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                ResetPlayer();
            }
            else if (!HasMoved && IsMovementKeyPressed())
            {
                HasMoved = true;
            }

            if (CanChangeShape)
            {
                _shapeVelocity = _shapeController.GetShapeVelocity();

                if (Input.GetKeyDown(KeyCode.Alpha1) && _currentShape != GameManager.Shapes.Sphere)
                {
                    ChangePlayerShape(GameManager.Shapes.Sphere);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) && _currentShape != GameManager.Shapes.Cube)
                {
                    ChangePlayerShape(GameManager.Shapes.Cube);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) && _currentShape != GameManager.Shapes.Triangle)
                {
                    ChangePlayerShape(GameManager.Shapes.Triangle);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4) && _currentShape != GameManager.Shapes.Star)
                {
                    ChangePlayerShape(GameManager.Shapes.Star);
                }
            }

            gameObject.transform.position = _shapeController.GetShapePosition();

            FormUpdate();
        }
	}

    private void FixedUpdate()
    {
        
    }

    private void FormUpdate()
    {
        _shapeController.FormUpdate();
    }

    private void ChangePlayerShape(GameManager.Shapes shape)
    {
        switch (shape)
        {
                case GameManager.Shapes.Sphere:
                    CreateSphere();
                    break;
                case GameManager.Shapes.Cube:
                    CreateCube();
                    break;
                case GameManager.Shapes.Triangle:
                    CreateTriangle();
                    break;
                case GameManager.Shapes.Star:
                    CreateStar();
                    break;
        }

        StartCoroutine(StartShapeChangeTimer());
    }

    private IEnumerator StartShapeChangeTimer()
    {
        CanChangeShape = false;

        float timeElapsed = 0.0f;

        while (timeElapsed < ShapeChangeDisableTimer)
        {
            while (GameManager.Instance.IsPaused)
            {
                yield return null;
            }

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        CanChangeShape = true;
    }

    private void CreateSphere()
    {
        _shapeController.DisableForm();

        _shapeController = new SphereController();
        _shapeController.InitializeFormWithVelocity(gameObject.transform, _shapeVelocity);

        _currentShape = GameManager.Shapes.Sphere;
    }

    private void CreateCube()
    {
        _shapeController.DisableForm();

        _shapeController = new CubeController();
        _shapeController.InitializeFormWithVelocity(gameObject.transform, _shapeVelocity);

        _currentShape = GameManager.Shapes.Cube;
    }

    private void CreateTriangle()
    {
        _shapeController.DisableForm();

        _shapeController = new TriangleController();
        _shapeController.InitializeFormWithVelocity(gameObject.transform, _shapeVelocity);

        _currentShape = GameManager.Shapes.Triangle;
    }

    private void CreateStar()
    {
        _shapeController.DisableForm();

        _shapeController = new StarController();
        _shapeController.InitializeFormWithVelocity(gameObject.transform, _shapeVelocity);

        _currentShape = GameManager.Shapes.Star;
    }

    public void Pause()
    {
        _shapeController.PauseShape();
        GameManager.Instance.PauseGame();
    }

    public void Unpause()
    {
        _shapeController.UnpauseShape();
        GameManager.Instance.UnpauseGame();
    }

    private void ResetPlayer()
    {
        SpawnPlayer();
        GameManager.Instance.ResetLevel();

        InitializePlayer();
    }

    private void SpawnPlayer()
    {
        gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
    }

    private void InitializePlayer()
    {
        ChangePlayerShape(GameManager.Shapes.Sphere);
        _shapeController.SetShapeVelocity(Vector3.zero);
        _shapeController.SetShapeAngularVelocity(Vector3.zero);
        _shapeVelocity = Vector3.zero;
        _shapeChangeDisableTimer = 0.0f;
        
        CanChangeShape = true;
        HasMoved = false;
    }

    private bool IsMovementKeyPressed()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            return true;
        }
        
        return false;
    }


}
