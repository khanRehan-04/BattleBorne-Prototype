using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    PlayerControls playerControls;
    [SerializeField] Vector2 movementInput;

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
}