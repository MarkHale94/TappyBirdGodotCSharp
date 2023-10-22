using Godot;
using System;

public partial class pipes : Node2D
{
	private Vector2 _previousPosition;
	private float _scrollSpeed = 120.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_previousPosition = Position;
		var newPositionX = _previousPosition.X - _scrollSpeed * (float)delta;
		Position = new Vector2(newPositionX, _previousPosition.Y);
	}

	private void OnScreenExited()
	{
		QueueFree();
	}

}
