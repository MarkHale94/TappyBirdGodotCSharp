using Godot;
using System;

public partial class hud : Control
{
	private gameManager _gameManager;
	private Label _scoreLabel;

	private StringName _scoreUpdated = gameManager.SignalName.OnScoreUpdated;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<gameManager>("/root/GameManager");
		_scoreLabel = GetNode<Label>("MC/ScoreLabel");
		_gameManager.Connect(_scoreUpdated, new Callable(this, _scoreUpdated));
	}

	private void OnScoreUpdated()
	{
		var newText = _gameManager.GetScore().ToString();
		_scoreLabel.Text = newText;
		GD.Print($"newText: {newText}");
	}
}
