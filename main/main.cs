using Godot;
using System;

public partial class main : Control
{
	private StringName _fly = new StringName("fly");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed(_fly))
			GetNode<gameManager>("/root/GameManager").LoadGameScene();
	}
}
