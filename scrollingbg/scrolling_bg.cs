using Godot;

public partial class scrolling_bg : ParallaxBackground
{
	private float _speed = 120.0f;
	private Vector2 _previousOffset;
	private StringName _gameOver = gameManager.SignalName.OnGameOver;

	private gameManager _gameManager;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<gameManager>("/root/GameManager");
		_gameManager.Connect(_gameOver, new Callable(this, _gameOver));

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_previousOffset = ScrollOffset;
		var newOffsetX = _previousOffset.X + _speed * (float)delta * -1;
		ScrollOffset = new Vector2(newOffsetX, _previousOffset.Y);
	}

	private void OnGameOver()
	{
		SetProcess(false);
	}
}
