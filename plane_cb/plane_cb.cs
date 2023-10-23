using Godot;
using System;

public partial class plane_cb : CharacterBody2D
{
	private AnimationPlayer _animationPlayer;
	private AnimatedSprite2D _sprite;
	private float _gravity = 1900.0f;
	private float _power = -400.0f;
	private float _newVelocityY;
	private Vector2 _previousVelocity;
	private StringName _fly = "fly";
	private gameManager _gameManager;
	private StringName _gameOver = gameManager.SignalName.OnGameOver;
	private bool _dead;

	private StringName _planeCollision = gameManager.SignalName.OnPlaneCollision;
	//private StringName _planeDied = SignalName.OnPlaneDied;
	
	// [Signal]
	// public delegate void OnPlaneDiedEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_gameManager = GetNode<gameManager>("/root/GameManager");
		_gameManager.Connect(_planeCollision, new Callable(this,_planeCollision));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		_previousVelocity = Velocity;
		CalculateVelocityY(delta);
		Velocity = new Vector2(_previousVelocity.X, _newVelocityY);
		MoveAndSlide();
		if (IsOnFloor())
			Die();
	}

	private void CalculateVelocityY(double delta)
	{
		Gravity(delta);
		Fly();
	}

	private void Gravity(double delta)
	{
		_newVelocityY =  _previousVelocity.Y + _gravity * (float)delta;
	}
	private void Fly()
	{
		if(!Input.IsActionJustPressed(_fly))
			return;
		_newVelocityY =  _power;
		_animationPlayer.Play(_fly);
	}

	private void OnPlaneCollision()
	{
		Die();
	}

	private void Die()
	{
		if (_dead)
			return;
		_dead = true;
		_sprite.Stop();
		_gameManager.EmitSignal(_gameOver);
		SetPhysicsProcess(false);
	}
}

