using Godot;
using System;

public partial class Hud : MarginContainer
{
	public static Hud Instance { get; private set; }

	[Export]
	private PanelContainer m_pickUpPopup;

	[Export]
	private Sprite2D m_itemSlot1;

	[Export]
	private Texture2D m_bone;
	
	[Export]
	private Texture2D m_coin;

	[Export]
	private Texture2D m_cola;

	[Export]
	private Texture2D m_headphones;

	[Export]
	private Texture2D m_key;

	[Export]
	private Texture2D m_spoon;

	[Export]
	private Texture2D m_sword;

	private Item m_itemToPickUp;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		HidePickup();
		ClearItem();
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

	public void OnPickUpYes()
	{
		PickUpItem(m_itemToPickUp.m_type);
		Player.Instance.CurrentItem = m_itemToPickUp.m_type;
		m_itemToPickUp.QueueFree();
		HidePickup();
	}

	public void OnPickUpNo()
	{
		HidePickup();
	}

	public void ClearItem()
	{
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
				break;
			case ItemType.ES:
				break;
			case ItemType.MIEKKA:
				m_itemSlot1.Texture = m_sword;
				break;
			case ItemType.KOLIKKO:
				m_itemSlot1.Texture = m_coin;
				break;
			case ItemType.KUVA:
				break;
			case ItemType.AVAIN:
				m_itemSlot1.Texture = m_key;
				break;
			case ItemType.TIIRIKKA:
				break;
			case ItemType.LUSIKKA:
				m_itemSlot1.Texture = m_spoon;
				break;
			case ItemType.PILLERI:
				break;
			case ItemType.STEROID:
				break;
			case ItemType.KUULOKKEET:
				m_itemSlot1.Texture = m_headphones;
				break;
			case ItemType.LUU:
				m_itemSlot1.Texture = m_bone;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(_item), _item, null);
		}
	}
}