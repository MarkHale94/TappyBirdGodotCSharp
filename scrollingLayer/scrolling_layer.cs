using Godot;
public partial class scrolling_layer : ParallaxLayer
{
	private Sprite2D _sprite;

	[Export] private Texture2D _texture;
	[Export] private float _scrollScale;
	[Export] private float _textureX = 1920.0f;
	[Export] private float _textureY = 1080.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sprite = GetNode<Sprite2D>("Sprite2D");
		_scrollScale = MotionScale.X;
		var scaleF = GetViewportRect().Size.Y / _textureY;
		_sprite.Texture = _texture;
		_sprite.Scale = new Vector2(scaleF, scaleF);
		MotionMirroring = new Vector2(_textureX * scaleF, MotionMirroring.Y) ;
	}

}
