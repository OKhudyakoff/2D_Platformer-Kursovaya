using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;

    [Header("InAir State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("WallSlide State")]
    public float wallSlideVelocity = 3f;

    [Header("WallClimb State")]
    public float WallClimbVelocity = 3f;

    [Header("LedgeClimb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("WallJump State")]
    public float WallJumpVelocity = 20f;
    public float WallJumpTime = 0.4f;
    public Vector2 WallJumpAngle = new Vector2(1, 2);

    [Header("CheckVariables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask WhatIsGround;
    public LayerMask WhatIsWall;
    public float WallCheckDistance = 0.5f;
}
