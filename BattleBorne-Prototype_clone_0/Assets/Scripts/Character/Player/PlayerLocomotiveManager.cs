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

    protected override void Awake()
    {
        base.Awake();

        player = GetComponent<PlayerManager>();
    }
    public void HandleAllMovements()
    {
      
    }

    private void HandleGroundedMovements()
    {
        moveDirection = PlayerCamera.instance.transform.forward * verticalmovement;
        moveDirection = moveDirection + PlayerCamera.instance.transform.right * Horizontalmovement;
        moveDirection.Normalize();
        moveDirection.y = 0;
    }
}
