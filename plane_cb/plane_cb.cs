using Godot;
using System;

public partial class plane_cb : CharacterBody2D
{
	private float _gravity = 1900.0f;
	private float _power = -400.0f;

	private Vector2 _previousVelocity;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		_previousVelocity = Velocity;
		var newVelocityY = Input.IsActionJustPressed("fly") ? _power : (_previousVelocity.Y + _gravity * (float)delta);
		Velocity = new Vector2(_previousVelocity.X, newVelocityY);
		MoveAndSlide();

	}
}

