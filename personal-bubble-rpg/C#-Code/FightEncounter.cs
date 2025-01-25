using Godot;
using System;

public partial class FightEncounter : Node
{

	public CharacterType characterType;

	public void FightStart(CharacterType _characterType)
	{
		characterType = _characterType;
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
					// spawns a robber
					GD.Print("Rosvo");
					break;
				case CharacterType.MUMMO:
					// spawns a granny
					GD.Print("Mummo");
					break;
				case CharacterType.EX:
					// spawns an ex
					GD.Print("Ex");
					break;
				case CharacterType.FEISSARI:
					// spawns a yuppie
					GD.Print("Feissari");
					break;
				case CharacterType.TUTTU:
					// spawns a friend
					GD.Print("Tuttu");
					break;
				case CharacterType.TURISTI:
					// spawns a tourist
					GD.Print("Turisti");
					break;
				case CharacterType.TERAPEUTTI:
					// spawns a therapist
					GD.Print("Terapeutti");
					break;
				case CharacterType.KOIRA:
					// spawns a dog
					GD.Print("Koira");
					break;
				case CharacterType.OVI:
					// spawns a door
					GD.Print("Ovi");
					break;
				default:
					GD.Print("Default");
					break;
			}
		}
	}

	public override void _Process(double delta)
	{
	}
}
