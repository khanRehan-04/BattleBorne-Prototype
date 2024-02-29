using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    PlayerLocomotiveManager playerLocomotionManager;
    protected override void Awake()
    {
        base.Awake(); // Call the base class method

        playerLocomotionManager = GetComponent<PlayerLocomotiveManager>();  
    }

    protected override void Update()
    {
        base.Update();

        playerLocomotionManager.HandleAllMovements();
    }
}