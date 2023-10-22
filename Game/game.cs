using System;
using Godot;

public partial class game : Node2D
{
	[Export] private PackedScene _pipesScene;
	private Node2D _pipesHolder;
	private Marker2D _spawnUpper;
	private Marker2D _spawnLower;
	private Timer _spawnTimer;
	private RandomNumberGenerator _rng;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_spawnUpper = GetNode<Marker2D>("SpawnUpper");
		_spawnLower = GetNode<Marker2D>("SpawnLower");
		_spawnTimer = GetNode<Timer>("SpawnTimer");
		_pipesHolder = GetNode<Node2D>("PipesHolder");
		_rng = new RandomNumberGenerator();
		SpawnPipes();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SpawnPipes()
	{
		var positionY = _rng.RandfRange(_spawnUpper.Position.Y, _spawnLower.Position.Y);
		var newPipes = _pipesScene.Instantiate<Node2D>();
		newPipes.Position = new Vector2(_spawnLower.Position.X, positionY);
		_pipesHolder.AddChild(newPipes);
	}

	private void OnSpawnTimerTimeout()
	{
		SpawnPipes();
	}
}
