using Godot;
using System;

public partial class pipes : Node2D
{
	private Vector2 _previousPosition;
	private float _scrollSpeed = 120.0f;
	private gameManager _gameManager;
	private StringName _planeCollision = gameManager.SignalName.OnPlaneCollision;
	private AudioStreamPlayer _scoreSound;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<gameManager>("/root/GameManager");
		_scoreSound = GetNode<AudioStreamPlayer>("ScoreSound");

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

	private void OnPipeBodyEntered(Node2D body)
	{
		if (body.IsInGroup(_gameManager.groupPlane))
		{
			_gameManager.EmitSignal(_planeCollision);
		}
	}

	private void OnLaserBodyEntered(Node2D body)
	{
		PlayerScore();
	}

	private void PlayerScore()
	{
		_scoreSound.Play();
		_gameManager.IncrementScore();
	}

}
