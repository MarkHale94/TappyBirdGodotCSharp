using Godot;
using System;

public partial class main : Control
{
	private StringName _fly ="fly";

	private gameManager _gameManager;

	private Label _highScore;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<gameManager>("/root/GameManager");
		_highScore = GetNode<Label>("MC/HB/HighScoreLabel");
		_highScore.Text = _gameManager.GetHighScore().ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed(_fly))
			GetNode<gameManager>("/root/GameManager").LoadGameScene();
	}
}
