using Godot;
using System;

public partial class game_over : Control
{
	private Label _gameOverLabel;
	private Label _pressSpaceLabel;
	private Timer _timer;
	private bool _canPressSpace;
	private gameManager _gameManager;

	private StringName _fly = "fly";

	private StringName _gameOver = gameManager.SignalName.OnGameOver;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameOverLabel = GetNode<Label>("GameOverLabel");
		_pressSpaceLabel = GetNode<Label>("PressSpaceLabel");
		_timer = GetNode<Timer>("Timer");
		_gameManager = GetNode<gameManager>("/root/GameManager");

		//_gameManager.OnGameOver += OnGameOver;
		// Have to connect to signals in this way because currently
		// when using +=, when the object is disposed, the signal is not automatically disconnected, leading to a object disposed exception
		// See following links for more details
		// https://github.com/godotengine/godot/issues/66319
		// https://github.com/godotengine/godot/pull/73730
		// https://github.com/godotengine/godot/issues/71032
		_gameManager.Connect(_gameOver, new Callable(this, _gameOver));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(_canPressSpace && Input.IsActionJustPressed(_fly))
			_gameManager.LoadMainScene();
	}

	private void OnGameOver()
	{
		Show();
		_timer.Start();
	}

	private void RunSequence()
	{
		_gameOverLabel.Hide();
		_pressSpaceLabel.Show();
		_canPressSpace = true;
	}

	private void OnTimerTimeout()
	{
		RunSequence();
	}
}
