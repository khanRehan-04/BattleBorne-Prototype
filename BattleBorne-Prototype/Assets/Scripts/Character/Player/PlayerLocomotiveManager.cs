using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotiveManager : CharacterLocomotionManager
{
    PlayerManager player;

    public float verticalmovement;
    public float Horizontalmovement;
    public float moveAmount;

    private Vector3 moveDirection;
    [SerializeField] float walkingSpeed = 2.0f;
    [SerializeField] float runningSpeed = 5.0f;

    protected override void Awake()
    {
        base.Awake();

        player = GetComponent<PlayerManager>();
    }
    public void HandleAllMovements()
    {
        HandleGroundedMovements();      
    }

    private void GetHorizontalAndVerticalInputs()
    {
        verticalmovement = InputManager.instance.verticalInput;
        Horizontalmovement = InputManager.instance.horizentalInput;
    }

    private void HandleGroundedMovements()
    {
        GetHorizontalAndVerticalInputs();

        moveDirection = PlayerCamera.instance.transform.forward * verticalmovement;
        moveDirection = moveDirection + PlayerCamera.instance.transform.right * Horizontalmovement;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if(InputManager.instance.movementAmount > 0.5f)
        {
            player.characterController.Move(moveDirection * runningSpeed * Time.deltaTime);
        }
        else if (InputManager.instance.movementAmount <= 0.5f)
        {
            player.characterController.Move(moveDirection * walkingSpeed * Time.deltaTime);
        }

    }
}
