using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

public partial class FightEncounter : MarginContainer
{
	public CharacterType characterType;

	[Export]
	private RichTextLabel m_playerText;
	[Export]
	private RichTextLabel m_enemyText;
	[Export]
	private Sprite2D m_enemySprite;
	[Export]
	private Button m_talkOpt1;
	[Export]
	private Button m_talkOpt2;
	[Export]
	private Button m_continueButton;
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

	private bool m_fightAftermath;

	private bool m_fading;
	private float m_fadeProgress;

	[Export]
	private MarginContainer m_fightContainer;

	public void SetEnemy(CharacterType _character)
	{
		characterType = _character;
	}

	public void FightStart()
	{
		m_continueButton.Visible = false;
		m_fightContainer.Visible = true;
		m_talkOpt1.Visible = true;
		m_talkOpt2.Visible = true;

		if (characterType == CharacterType.OVI)
		{
			if (Player.Instance.CurrentItem != ItemType.AVAIN)
				m_talkOpt1.Visible = false;
		}
		if (characterType == CharacterType.LAPSI)
		{
			if (Player.Instance.CurrentItem != ItemType.ES)
			{
				m_talkOpt1.Visible = false;
			}
			if (Player.Instance.CurrentItem != ItemType.CANDY)
			{
				m_talkOpt2.Visible = false;
			}
		}

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
					m_playerText.Text = "[ I... I'm being robbed? For real?! ]";
					m_enemyText.Text = "Hey, gimme all your money! NOW!";
					GD.Print("Rosvo");
					m_talkOpt1.Text = "[ Fight back ]";
					m_talkOpt2.Text = "[ Give him your wallet ]";
					break;
				case CharacterType.MUMMO:
					// spawns a granny
					m_enemySprite.Texture = m_mummo;
					m_playerText.Text = "[ It's my elderly neighbour... "
										+ "I hope she doesn't ask me to fix her WIFI router again. ]";
					m_enemyText.Text = "My goodness, if it isnt my favourite neighbor! "
										+ "How's that school of yours coming along? Have a boyfriend yet?";
					GD.Print("Mummo");
					m_talkOpt1.Text = "How are you Mrs. Mummo?";
					m_talkOpt2.Text = "[ Laugh awkwardly ]";
					break;
				case CharacterType.EX:
					// spawns an ex
					m_enemySprite.Texture = m_ex;
					m_playerText.Text = "[ My ex...! Damn it, why does she look that good!? "
										+ "But she might still have my spare key... ]";
					m_enemyText.Text = "Hm, it's you. What do you want? ";
					GD.Print("Ex");
					m_talkOpt1.Text = "Ask about spare key";
					m_talkOpt2.Text = "Flee";
					break;
				case CharacterType.FEISSARI:
					// spawns a yuppie
					m_enemySprite.Texture = m_feissari;
					m_playerText.Text = "[ Just my luck, it's some salesperson. I hope they're not too pushy.... ]";
					m_enemyText.Text = "Hey, yes, you there, you! "
										+ "Would you have a moment to talk about your network provider? " 
										+ "Everything okay with it?";
					GD.Print("Feissari");
					m_talkOpt1.Text = "[ Point at headphones ]";
					m_talkOpt2.Text = "Buy whatever he's selling.";
					break;
				case CharacterType.TUTTU:
					// spawns a friend
					m_enemySprite.Texture = m_tuttu;
					m_playerText.Text = "[ Oh no, I don't recognize this person... "
									+ "So why are they waving at me?? ]";
					m_enemyText.Text = "Hey, haven't seen you in the longest time! How are you?";
					GD.Print("Tuttu");
					m_talkOpt1.Text = "Not much, how about you?";
					m_talkOpt2.Text = "Yeah, haha, college was crazy.";
					break;
				case CharacterType.TURISTI:
					// spawns a tourist
					m_enemySprite.Texture = m_turisti;
					m_playerText.Text = "[ It¨s a tourist... I was never good at languages... ]";
					m_enemyText.Text = "ヤッホー！私の社品をとれるの？";
					GD.Print("Turisti");
					m_talkOpt1.Text = "Me no English.";
					m_talkOpt2.Text = "Scream.";
					break;
				case CharacterType.TERAPEUTTI:
					// spawns a therapist
					m_enemySprite.Texture = m_terapeutti;
					m_playerText.Text = "[ ...My head feels dizzy. "
										+ "I hope I don't have to talk to anyone today. ]";
					m_enemyText.Text = "It's time for you to leave the hospital for now. "
										+ "It's getting late, so I hope you get home safely.";
					GD.Print("Terapeutti");
					m_talkOpt1.Text = "Who are you?";
					m_talkOpt2.Text = "Suck it, I'm going home.";
					break;
				case CharacterType.DIILERI:
					// spawns a dealer
					m_enemySprite.Texture = m_diileri;
					m_playerText.Text = "[ Eek! What does this guy want?! ]";
					m_enemyText.Text = "Are you looking for something...? You just might've come to the right place...";
					GD.Print("Diileri");
					m_talkOpt1.Text = "Who are you?";
					m_talkOpt2.Text = "Buy drugs.";
					break;
				case CharacterType.LAPSI:
					// spawns a brat
					if (!m_talkOpt1.Visible && !m_talkOpt2.Visible)
					{
						m_continueButton.Visible = true;
						m_fightContainer.Visible = false;
						m_fightAftermath = false;
					}
					m_enemySprite.Texture = m_kakara;
					m_playerText.Text = "[ Why are kids always staring? Oh no, our eyes met... ]";
					m_enemyText.Text = "Hey, whatcha starin' at? I'll call the cops.";
					GD.Print("Kakara");
					m_talkOpt1.Text = "[ Offer Energy Drink ]";
					m_talkOpt2.Text = "[ Offer candy ]";
					break;
				case CharacterType.KOIRA:
					// spawns a dog
					m_enemySprite.Texture = m_koira;
					m_playerText.Text = "[ It's a dog! ... I wonder if it's friendly? ]";
					m_enemyText.Text = "Woof! [ You feel a strange sense of calm... ]";
					GD.Print("Koira");
					m_talkOpt1.Text = "[ Pet the dog ]";
					m_talkOpt2.Text = "[ Offer a bone ]";
					break;
				case CharacterType.OVI:
					// spawns a door
					m_enemySprite.Texture = m_ovi;
					m_playerText.Text = "This is it, the final challenge... Please, let me go home!";
					m_enemyText.Text = "[ ... ]";
					GD.Print("Ovi");
					m_talkOpt1.Text = "[ Use a key ]";
					m_talkOpt2.Text = "[ Kick the door ]";
					break;
				default:
					GD.Print("Default");
					break;
			}
		}
	}

	public void Button1()
	{
		m_talkOpt1.Visible = false;
		m_talkOpt2.Visible = false;
		m_fightContainer.Visible = false;
		m_continueButton.Visible = true;

		switch (characterType)
			{
				case CharacterType.ROSVO:
					m_fightAftermath = true;
					m_enemyText.Text = "Woah, you're a tough one! I'll let you go this time.";
					m_playerText.Text = null;
					break;
				case CharacterType.MUMMO:
					m_fightAftermath = true;
					m_enemyText.Text = "Oh, great, but now that you're here, could you look at my phone? It has been a bit slow lately... [You close 1753 tabs from her browser] ";
					m_playerText.Text = null;
					break;
				case CharacterType.EX:
					m_fightAftermath = true;
					m_enemyText.Text = "Fine I'll give you the key. [She hands you the key] ";
					m_playerText.Text = null;
					break;
				case CharacterType.FEISSARI:
					m_fightAftermath = true;
					m_enemyText.Text = "Oh, you're not interested? That's fine, have a nice day!";
					m_playerText.Text = null;
					break;
				case CharacterType.TUTTU:
					m_fightAftermath = true;
					m_enemyText.Text = "Same old, same old. The kids are growing up so fast.";
					m_playerText.Text = null;
					break;
				case CharacterType.TURISTI:
					m_fightAftermath = true;
					m_enemyText.Text = "You've succesfully fled the scene.";
					m_playerText.Text = null;
					break;
				case CharacterType.TERAPEUTTI:
					m_fightAftermath = true;
					m_enemyText.Text = "I'm your Doctor. I take care of you whenever you collapse from intense social stress.";
					m_playerText.Text = null;
					break;
				case CharacterType.DIILERI:
					m_fightAftermath = false;
					m_enemyText.Text = "Cops ask questions. Are you a cop?";
					m_playerText.Text = null;
					break;
				case CharacterType.LAPSI:
					m_fightAftermath = true;
					m_enemyText.Text = "Yooo, is this the new Caramel Ass flavoured ES?? Sweet!";
					m_playerText.Text = null;
					break;
				case CharacterType.KOIRA:
					m_fightAftermath = true;
					m_enemyText.Text = "Woof woof [ You feel better. ]";
					m_playerText.Text = null;
					break;
				case CharacterType.OVI:
					m_fightAftermath = true;
					m_enemyText.Text = "You used the key. *CLACK!*";
					m_playerText.Text = null;
					break;
				default:
					GD.Print("Default");
					break;
			}
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}

	public void Button2()
	{
		m_talkOpt1.Visible = false;
		m_talkOpt2.Visible = false;
		m_fightContainer.Visible = false;
		m_continueButton.Visible = true;
		switch (characterType)
			{
				case CharacterType.ROSVO:
					m_fightAftermath = false;
					m_enemyText.Text = "Good. Now, SCRAM!";
					m_playerText.Text = null;
					break;
				case CharacterType.MUMMO:
					m_fightAftermath = false;
					m_enemyText.Text = "What?";
					m_playerText.Text = null;
					break;
				case CharacterType.EX:
					m_fightAftermath = false;
					m_enemyText.Text = "Oh okay... Be careful.";
					m_playerText.Text = null;
					break;
				case CharacterType.FEISSARI:
					m_fightAftermath = false;
					m_enemyText.Text = "Our current pricing starts at 39.99£ a month, "
										+ "but just for this week, we have a super-special-mega "
										+ "offer of 34.99£ by the hour!";
					m_playerText.Text = null;
					break;
				case CharacterType.TUTTU:
					m_fightAftermath = false;
					m_enemyText.Text = "..We did not go to the same college? "
										+ "Wait, you do not remember me at all, do you!?";
					m_playerText.Text = null;
					break;
				case CharacterType.TURISTI:
					m_fightAftermath = false;
					m_enemyText.Text = "キャーーー！ [ Tourist runs away ]";
					m_playerText.Text = null;
					break;
				case CharacterType.TERAPEUTTI:
					m_fightAftermath = false;
					m_enemyText.Text = "Oh okay... Be careful.";
					m_playerText.Text = null;
					break;
				case CharacterType.DIILERI:
					m_fightAftermath = true;
					m_enemyText.Text = "You want drugs? I'll give you drugs.";
					m_playerText.Text = null;
					break;
				case CharacterType.LAPSI:
					m_fightAftermath = false;
					m_enemyText.Text = "What the FUCK are you offering me? "
										+ "You think kids still eat candy? "
										+ "That's skibidi gross, dude. ";
					m_playerText.Text = null;
					break;
				case CharacterType.KOIRA:
					m_fightAftermath = true;
					m_enemyText.Text = "WOOF! [ You feel better ]";
					m_playerText.Text = null;
					break; 
				case CharacterType.OVI:
					m_fightAftermath = false;
					m_enemyText.Text = "You hurt your foot. The door stays closed.";
					m_playerText.Text = null;
					break; 
				default:
					GD.Print("Default");
					break;
			}

			if (!m_fightAftermath)
			{
				Player.Instance.m_healthSystem.ApplyDamage(1);
			}

			if (characterType == CharacterType.KOIRA)
			{
				Player.Instance.m_healthSystem.ApplyDamage(-1);
			}
		
			AudioPlayerScene.Instance?.PlayButtonSound();
	}
	public void Button3()
	{
		if (m_fightAftermath)
		{
			GameManager.Instance.EndFightPlayerWin(characterType);
		}
		else
		{
			GameManager.Instance.EndFightPlayerLose(characterType);
		}
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}
}
