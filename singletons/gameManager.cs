using Godot;
using System;
using System.IO;

public partial class gameManager : Node
{
	private  PackedScene _gameScene = (PackedScene)ResourceLoader.Load("res://game/game.tscn");
	private PackedScene _mainScene = (PackedScene) ResourceLoader.Load("res://main/main.tscn");
	private PackedScene _sceneToLoad;
	public string groupPlane = "plane";
	private int _score;
	private int _highScore;
	private StringName _scoreUpdated = SignalName.OnScoreUpdated;
	public enum GameScenes
	{
		GameScene,
		MainScene
	}

	[Signal]
	public delegate void OnGameOverEventHandler();

	[Signal]
	public delegate void OnPlaneCollisionEventHandler();

	[Signal]
	public delegate void OnScoreUpdatedEventHandler();

	public void LoadScene(GameScenes scene)
	{
		switch (scene)
		{
			case GameScenes.GameScene:
				_sceneToLoad = _gameScene;
				break;
			case GameScenes.MainScene:
				_sceneToLoad = _mainScene;
				break;
			default:
				_sceneToLoad = _mainScene;
				break;
		}

		GetTree().ChangeSceneToPacked(_sceneToLoad);

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
