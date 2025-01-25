using Godot;
using System;

public partial class FightEncounter : Node
{
	public CharacterType characterType;

	[Export]
	private RichTextLabel m_enemyText;
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
	private Texture2D m_diileri;
	[Export]
	private Texture2D m_kakara;
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
					m_enemyText.Text = "Hey, gimme all your money! NOW!";
					GD.Print("Rosvo");
					break;
				case CharacterType.MUMMO:
					// spawns a granny
					m_enemySprite.Texture = m_mummo;
					m_enemyText.Text = "My goodness, if it isnt my favourite neighbor! "
										+ "How's that school of yours coming along? Have a boyfriend yet?";
					GD.Print("Mummo");
					break;
				case CharacterType.EX:
					// spawns an ex
					m_enemySprite.Texture = m_ex;
					m_enemyText.Text = "Hm, it's you. What do you want? ";
					GD.Print("Ex");
					break;
				case CharacterType.FEISSARI:
					// spawns a yuppie
					m_enemySprite.Texture = m_feissari;
					m_enemyText.Text = "Hey, yes, you there, you! "
										+ "Would you have a moment to talk about your network provider? " 
										+ "Everything okay with it?";
					GD.Print("Feissari");
					break;
				case CharacterType.TUTTU:
					// spawns a friend
					m_enemySprite.Texture = m_tuttu;
					m_enemyText.Text = "Hey, haven't seen you in the longest time! How are you?";
					GD.Print("Tuttu");
					break;
				case CharacterType.TURISTI:
					// spawns a tourist
					m_enemySprite.Texture = m_turisti;
					m_enemyText.Text = "ヤッホー！私の社品をとれるの？";
					GD.Print("Turisti");
					break;
				case CharacterType.TERAPEUTTI:
					// spawns a therapist
					m_enemySprite.Texture = m_terapeutti;
					m_enemyText.Text = "It's time for you to leave the hospital for now. "
										+ "It's getting late, so I hope you get home safely.";
					GD.Print("Terapeutti");
					break;
				case CharacterType.DIILERI:
					// spawns a dealer
					m_enemySprite.Texture = m_diileri;
					m_enemyText.Text = "Are you looking for something...? You just might've come to the right place...";
					GD.Print("Diileri");
					break;
				case CharacterType.LAPSI:
					// spawns a brat
					m_enemySprite.Texture = m_kakara;
					m_enemyText.Text = "Hey, whatcha starin' at? I'll call the cops.";
					GD.Print("Kakara");
					break;
				case CharacterType.KOIRA:
					// spawns a dog
					m_enemySprite.Texture = m_koira;
					m_enemyText.Text = "Woof! [ You feel a strange sense of calm...]";
					GD.Print("Koira");
					break;
				case CharacterType.OVI:
					// spawns a door
					m_enemySprite.Texture = m_ovi;
					m_enemyText.Text = "[ ... ]";
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
