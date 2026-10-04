using Godot;
using System;

public partial class MovingCharacter : CharacterBody2D
{
	Sprite2D hinge;
	Vector2 deltaPos = Vector2.Zero;
	int Speed = 1; //default
	public override void _Ready()
	{
		if (HasMeta("Speed"))
		{
			Speed = GetMeta("Speed").AsInt32();
		}
	}

	const float gravity = 9.8f;

	Single boolToInt (bool param)
	{
		return param ? 1 : 0;
	}
	

	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;
		velocity = new Vector2(
			boolToInt(Input.IsActionPressed("RightKey")) - boolToInt(Input.IsActionPressed("LeftKey")),
			boolToInt(Input.IsActionPressed("DownKey")) - boolToInt(Input.IsActionPressed("UpKey"))
		);

		Vector2 mousePos = GetGlobalMousePosition();
		deltaPos = (Vector2) mousePos-Position;
		if (HasMeta("AimAngle")) {
				var AimAngle = (float) Math.Atan2(deltaPos.Y, deltaPos.X);
				SetMeta("AimAngle", AimAngle);
				
			if (HasMeta("Hinge")) {
				hinge = GetNode<Sprite2D>((NodePath)GetMeta("Hinge"));
				hinge.Rotation = AimAngle;
			}
				
		}

		// add rotational thingy here

		
		//Position += velocity.Normalized() * _speed * (float)delta;
		MoveAndCollide(velocity.Normalized() * Speed);
	}
}
