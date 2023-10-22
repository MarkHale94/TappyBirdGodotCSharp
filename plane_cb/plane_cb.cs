using Godot;
using System;

public partial class plane_cb : CharacterBody2D
{
	private float _gravity = 1900.0f;
	private float _power = -400.0f;
	private AnimationPlayer _animationPlayer;
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
		bool isFlyPressed = Input.IsActionJustPressed("fly");
		_previousVelocity = Velocity;
		var newVelocityY = isFlyPressed ? _power : (_previousVelocity.Y + _gravity * (float)delta);
		if( isFlyPressed )
			_animationPlayer.Play("fly");
		Velocity = new Vector2(_previousVelocity.X, newVelocityY);
		MoveAndSlide();

	}
}

