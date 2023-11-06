using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State Variables

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }

    #endregion

    #region Components

    public Animator Player_Animator { get; private set; }
    public PlayerInputHandler InputHandler;
    public Rigidbody2D Player_Rigidbody { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    public Collider2D Player_Collider { get; private set;}

    #endregion

    #region CheckTransforms

    [SerializeField] private Transform groundCheck;

    #endregion

    #region Other Variables

    [SerializeField] private PlayerData playerData;

    private Vector2 workSpace;
    //[SerializeField] private bool isTouchingWall;

    #endregion

    #region Unity Callback Functions

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
    }

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        FacingDirection = 1;
    }

    private void Start()
    {
        Player_Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Player_Rigidbody = GetComponent<Rigidbody2D>();
        Player_Collider = GetComponent<Collider2D>();
        StateMachine.Initialize(InAirState);
    }

    private void Update()
    {
        CurrentVelocity = Player_Rigidbody.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Set Functions

    public void SetVelocityZero()
    {
        Player_Rigidbody.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
        Player_Rigidbody.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityX(float velocity)
    {
        workSpace.Set(velocity, CurrentVelocity.y);
        Player_Rigidbody.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    public void SetVelocityY(float velocity)
    {
        workSpace.Set(CurrentVelocity.x, velocity);
        Player_Rigidbody.velocity = workSpace;
        CurrentVelocity = workSpace;
    }

    #endregion

    #region Check Functions

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.WhatIsGround);
    }

    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    #endregion

    #region Other Functions

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180, 0f, 0.0f);
    }

    private void OnGameOver()
    {
        Player_Collider.gameObject.SetActive(false);
    }

    #endregion
}