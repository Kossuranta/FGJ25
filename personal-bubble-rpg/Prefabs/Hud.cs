using Godot;
using System;

public partial class Hud : MarginContainer
{
	public static Hud Instance { get; private set; }

	[Export]
	private VBoxContainer m_pickUpPopup;
	
	[Export]
	private VBoxContainer m_fightDoorPopup;
	
	[Export]
	private VBoxContainer m_hitTrashcanPopup;
	
	[Export]
	private VBoxContainer m_trashTrashTalk;

	[Export]
	private VBoxContainer m_roskisColaText;
	
	[Export]
	private VBoxContainer m_vendingBuy;
	
	[Export]
	private VBoxContainer m_vendingNoMoney;

	[Export]
	private Sprite2D m_itemSlot1;

	[Export]
	private Texture2D m_bone;
	
	[Export]
	private Texture2D m_candy;
	
	[Export]
	private Texture2D m_coin;

	[Export]
	private Texture2D m_cola;
	
	[Export]
	private Texture2D m_drugs;
	
	[Export]
	private Texture2D m_es;

	[Export]
	private Texture2D m_headphones;

	[Export]
	private Texture2D m_key;
	
	[Export]
	private Texture2D m_lockpick;
	
	[Export]
	private Texture2D m_meds;
	
	[Export]
	private Texture2D m_photo;

	[Export]
	private Texture2D m_spoon;

	[Export]
	private Texture2D m_sword;

	private Item m_itemToPickUp;
	private float m_pickupTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		HidePickup();
		HideFightDoor();
		HideHitTrashcan();
		HideTrashTrashTalk();
		m_roskisColaText.Visible = false;
		HideVendingBuy();
		ClearItem();
	}

	public void OnRoskisColaPickup()
	{
		m_roskisColaText.Visible = true;
		m_pickupTimer = 5f;
	}

	public override void _Process(double _delta)
	{
		float delta = (float) _delta;
		if (m_pickupTimer > 0)
		{
			m_pickupTimer -= delta;
			if (m_pickupTimer <= 0)
				m_roskisColaText.Visible = false;
		}
	}
	
	public void ShowPickup(Item _item)
	{
		m_itemToPickUp = _item;
		m_pickUpPopup.Visible = true;
	}

	public void HidePickup()
	{
		m_itemToPickUp = null;
		m_pickUpPopup.Visible = false;
	}

	public void HideFightDoor()
	{
		m_fightDoorPopup.Visible = false;
	}

	public void OnPickUpYes()
	{
		PickUpItem(m_itemToPickUp.m_type);
		Player.Instance.CurrentItem = m_itemToPickUp.m_type;
		m_itemToPickUp.QueueFree();
		HidePickup();
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}

	public void OnPickUpNo()
	{
		HidePickup();
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}

	public void ShowFightDoor()
	{
		m_fightDoorPopup.Visible = true;
	}
	
	public void OnFightDoorYes()
	{
		GD.Print($"START COMBAT! Enemy: {CharacterType.OVI}");
		GameManager.Instance.StartFight(CharacterType.OVI);
		HideFightDoor();
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}

	public void OnFightDoorNo()
	{
		HideFightDoor();
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}

	public void ShowHitTrashcan()
	{
		m_hitTrashcanPopup.Visible = true;
	}

	public void ShowTrashTrashTalk()
	{
		m_trashTrashTalk.Visible = true;
	}

	public void HideTrashTrashTalk()
	{
		m_trashTrashTalk.Visible = false;
	}

	public void OnVendingBuyYes()
	{
		HideVendingBuy();
		ClearItem();
		Player.Instance.CurrentItem = ItemType.ES;
		PickUpItem(ItemType.ES);
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}
	
	public void OnVendingBuyNo()
	{
		HideVendingBuy();
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}
	
	public void ShowVendingBuy()
	{
		m_vendingBuy.Visible = true;
	}
	
	public void ShowVendingBuyNoMoney()
	{
		m_vendingNoMoney.Visible = true;
	}

	public void HideVendingBuy()
	{
		m_vendingBuy.Visible = false;
		m_vendingNoMoney.Visible = false;
	}

	public void OnHitTrashcan()
	{
		if (Player.Instance.CurrentRoskis != null)
		{
			Player.Instance.CurrentRoskis.OnHit();
			Player.Instance.CurrentRoskis = null;
		}
		ClearItem();
		HideHitTrashcan();
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}

	public void OnDontHitTrashcan()
	{
		HideHitTrashcan();
		
		AudioPlayerScene.Instance?.PlayButtonSound();
	}

	public void HideHitTrashcan()
	{
		m_hitTrashcanPopup.Visible = false;
	}

	public void ClearItem()
	{
		Player.Instance.CurrentItem = ItemType.NOT_SET;
		m_itemSlot1.Texture = null;
	}

	public void PickUpItem(ItemType _item)
	{
		switch (_item)
		{
			case ItemType.COLA:
				m_itemSlot1.Texture = m_cola;
				break;
			case ItemType.CANDY:
				m_itemSlot1.Texture = m_candy;
				break;
			case ItemType.ES:
				m_itemSlot1.Texture = m_es;
				break;
			case ItemType.MIEKKA:
				m_itemSlot1.Texture = m_sword;
				break;
			case ItemType.KOLIKKO:
				m_itemSlot1.Texture = m_coin;
				break;
			case ItemType.KUVA:
				m_itemSlot1.Texture = m_photo;
				break;
			case ItemType.AVAIN:
				m_itemSlot1.Texture = m_key;
				break;
			case ItemType.TIIRIKKA:
				m_itemSlot1.Texture = m_lockpick;
				break;
			case ItemType.LUSIKKA:
				m_itemSlot1.Texture = m_spoon;
				break;
			case ItemType.PILLERI:
				m_itemSlot1.Texture = m_meds;
				break;
			case ItemType.STEROID:
				m_itemSlot1.Texture = m_drugs;
				break;
			case ItemType.KUULOKKEET:
				m_itemSlot1.Texture = m_headphones;
				break;
			case ItemType.LUU:
				m_itemSlot1.Texture = m_bone;
				break;
			default:
				m_itemSlot1.Texture = null;
				break;
		}
	}
}