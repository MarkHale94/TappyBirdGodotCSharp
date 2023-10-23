using Godot;
using System;
using System.IO;

public partial class gameManager : Node
{
	private  PackedScene _gameScene = (PackedScene)ResourceLoader.Load("res://game/game.tscn");
	private PackedScene _mainScene = (PackedScene) ResourceLoader.Load("res://main/main.tscn");
	public string groupPlane = "plane";

	[Signal]
	public delegate void OnGameOverEventHandler();

	[Signal]
	public delegate void OnPlaneCollisionEventHandler();
	public void LoadGameScene()
	{
		GetTree().ChangeSceneToPacked(_gameScene);
	}

	public void LoadMainScene()
	{
		GetTree().ChangeSceneToPacked(_mainScene);
	}
}
