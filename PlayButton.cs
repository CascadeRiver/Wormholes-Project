using Godot;
using System;

public partial class PlayButton : MenuButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += changeScene;
	}

	void changeScene()
	{
		GetTree().ChangeSceneToFile("res://scenes/node_2d.tscn");
	}
}
