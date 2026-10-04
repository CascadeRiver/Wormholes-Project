using Godot;
using System;
using System.ComponentModel;

public partial class GetAimAngle : Node2D
{
	CharacterBody2D playerChar;
	float AimAngle;
	Vector2 deltaPos;
	public override void _Process(double delta)
	{
		Vector2 mousePos = GetGlobalMousePosition();
		if (HasMeta("Player"))
		{
			playerChar = (CharacterBody2D) GetMeta("Player");
			Vector2 playerPos = playerChar.Position;
			deltaPos = mousePos-playerPos;
			if (HasMeta("AimAngle"))
			{
				AimAngle = (float) Math.Atan2(deltaPos.Y, deltaPos.X);
				SetMeta("AimAngle", AimAngle);
				GD.Print(AimAngle);
			}
		}
	}
}
