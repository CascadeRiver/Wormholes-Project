using Godot;
using System;

public partial class RigidBody2d : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	private float _speed = 400;
	private float _angularSpeed = Mathf.Pi;
	

	public override void _Process(double delta)
	{

		var velocity = Vector2.Zero;
		if (Input.IsActionPressed("UpKey"))
		{
			velocity = Vector2.Up.Rotated(Rotation) * _speed;
		}
		if (Input.IsActionPressed("DownKey"))
		{
			velocity = Vector2.Down.Rotated(Rotation) * _speed;
		}
		if (Input.IsActionPressed("LeftKey"))
		{
			velocity = Vector2.Left.Rotated(Rotation) * _speed;
		}
		if (Input.IsActionPressed("RightKey"))
		{
			velocity = Vector2.Right.Rotated(Rotation) * _speed;
		}

		Position += velocity * (float)delta;
	}
}
