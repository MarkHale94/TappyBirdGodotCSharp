using Godot;
using System;

public partial class plane_cb : CharacterBody2D
{
	private AnimationPlayer _animationPlayer;
	private float _gravity = 1900.0f;
	private float _power = -400.0f;
	private float _newVelocityY;
	private Vector2 _previousVelocity;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
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
		if(!Input.IsActionJustPressed("fly"))
			return;
		_newVelocityY =  _power;
		_animationPlayer.Play("fly");
	}
}

