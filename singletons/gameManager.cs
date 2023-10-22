using Godot;
using System;
using System.IO;

public partial class gameManager : Node
{
	private  PackedScene _gameScene; 
	public void LoadGameScene()
	{
		_gameScene = (PackedScene)ResourceLoader.Load("res://game/game.tscn");
		GetTree().ChangeSceneToPacked(_gameScene);
	}
}
