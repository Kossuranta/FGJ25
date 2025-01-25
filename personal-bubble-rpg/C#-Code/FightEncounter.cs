using Godot;
using System;

public partial class FightEncounter : Node
{
	public CharacterType characterType;

	[Export]
	private Sprite2D m_enemySprite;
	[Export]
	private Texture2D m_rosvo;
	[Export]
	private Texture2D m_mummo;
	[Export]
	private Texture2D m_ex;
	[Export]
	private Texture2D m_feissari;
	[Export]
	private Texture2D m_tuttu;
	[Export]	
	private Texture2D m_turisti;
	[Export]	
	private Texture2D m_terapeutti;
	[Export]
	private Texture2D m_koira;
	[Export]
	private Texture2D m_ovi;


	

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
					m_enemySprite.Texture = m_rosvo;
					GD.Print("Rosvo");
					break;
				case CharacterType.MUMMO:
					// spawns a granny
					m_enemySprite.Texture = m_mummo;
					GD.Print("Mummo");
					break;
				case CharacterType.EX:
					// spawns an ex
					m_enemySprite.Texture = m_ex;
					GD.Print("Ex");
					break;
				case CharacterType.FEISSARI:
					// spawns a yuppie
					m_enemySprite.Texture = m_feissari;
					GD.Print("Feissari");
					break;
				case CharacterType.TUTTU:
					// spawns a friend
					m_enemySprite.Texture = m_tuttu;
					GD.Print("Tuttu");
					break;
				case CharacterType.TURISTI:
					// spawns a tourist
					m_enemySprite.Texture = m_turisti;
					GD.Print("Turisti");
					break;
				case CharacterType.TERAPEUTTI:
					// spawns a therapist
					m_enemySprite.Texture = m_terapeutti;
					GD.Print("Terapeutti");
					break;
				case CharacterType.KOIRA:
					// spawns a dog
					m_enemySprite.Texture = m_koira;
					GD.Print("Koira");
					break;
				case CharacterType.OVI:
					// spawns a door
					m_enemySprite.Texture = m_ovi;
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
