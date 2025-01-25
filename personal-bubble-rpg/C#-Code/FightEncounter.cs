using Godot;
using System;

public partial class FightEncounter : Node
{

	public CharacterType characterType = CharacterType.ROSVO;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (characterType == CharacterType.NOT_SET)
		{
			GD.Print("CharacterType not set");
		}
		else
		{
			GD.Print("CharacterType set to: " + characterType);
			
			switch (characterType)
			{
				case CharacterType.ROSVO:
					GD.Print("Rosvo");
					break;
				case CharacterType.MUMMO:
					GD.Print("Mummo");
					break;
				case CharacterType.EX:
					GD.Print("Ex");
					break;
				case CharacterType.FEISSARI:
					GD.Print("Feissari");
					break;
				case CharacterType.TUTTU:
					GD.Print("Tuttu");
					break;
				case CharacterType.TURISTI:
					GD.Print("Turisti");
					break;
				case CharacterType.TERAPEUTTI:
					GD.Print("Terapeutti");
					break;
				case CharacterType.KOIRA:
					GD.Print("Koira");
					break;
				case CharacterType.OVI:
					GD.Print("Ovi");
					break;
				default:
					GD.Print("Default");
					break;
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
