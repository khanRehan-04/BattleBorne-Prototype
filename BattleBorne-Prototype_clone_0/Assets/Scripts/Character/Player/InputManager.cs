using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    PlayerControls playerControls;

    [SerializeField] Vector2 movementInput;

    public float horizentalInput;
    public float verticalInput;
    public float movementAmount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += OnSceneChange;

        instance.enabled = false;
    }

    private void  OnSceneChange(Scene oldScene, Scene newScene)
    {
       if(newScene.buildIndex == WorldSaveGameManager.instance.GetWorldSceneIndex())
        {
            instance.enabled = true;
        }
        else
        {
            instance.enabled = false;
        }
    }

    private void OnEnable()
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChange;
    }

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizentalInput = movementInput.x;

        movementAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizentalInput));

        if(movementAmount <= 0.5 && movementAmount > 0)
        {
            movementAmount = 0.5f;
        }
        else if(movementAmount > 0.5 && movementAmount <= 1)
        {
            movementAmount = 1;
        }

       
    }
}
