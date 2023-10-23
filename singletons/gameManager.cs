using Godot;
using System;
using System.IO;

public partial class gameManager : Node
{
	private  PackedScene _gameScene = (PackedScene)ResourceLoader.Load("res://game/game.tscn");
	private PackedScene _mainScene = (PackedScene) ResourceLoader.Load("res://main/main.tscn");
	public string groupPlane = "plane";
	private int _score;
	private int _highScore;
	private StringName _scoreUpdated = SignalName.OnScoreUpdated;

	[Signal]
	public delegate void OnGameOverEventHandler();

	[Signal]
	public delegate void OnPlaneCollisionEventHandler();

	[Signal]
	public delegate void OnScoreUpdatedEventHandler();
	public void LoadGameScene()
	{
		GetTree().ChangeSceneToPacked(_gameScene);
	}

	public void LoadMainScene()
	{
		GetTree().ChangeSceneToPacked(_mainScene);
	}

	public int GetScore()
	{
		return _score;
	}

	private void SetScore(int score)
	{
		_score = score;
		CompareScoreToHighScore();
		EmitSignal(_scoreUpdated);
		GD.Print($"Score: {_score}. HighScore: {_highScore}");
	}

	public void IncrementScore()
	{
		SetScore(_score + 1);
	}

	public int GetHighScore()
	{
		return _highScore;
	}

	private void CompareScoreToHighScore()
	{
		if (_score > _highScore)
			_highScore = _score;
	}

	public void ResetScore()
	{
		_score = 0;
	}
}
