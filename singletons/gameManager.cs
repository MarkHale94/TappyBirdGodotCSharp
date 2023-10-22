using Godot;
using System;
using System.IO;

public partial class gameManager : Node
{
	private  PackedScene _gameScene = (PackedScene)ResourceLoader.Load("res://game/game.tscn");
	public void LoadGameScene()
	{
		GetTree().ChangeSceneToPacked(_gameScene);
	}
}
