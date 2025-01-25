using Godot;
using System;

public partial class Hud : MarginContainer
{
	public static Hud Instance { get; private set; }

	[Export]
	private Sprite2D m_itemSlot1;
	
	[Export]
	private Sprite2D m_itemSlot2;

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

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		PickUpItem(0, ItemType.COLA);
		PickUpItem(1, ItemType.LUU);
	}

	public void PickUpItem(int _slot, ItemType _item)
	{
		Sprite2D slot = _slot == 0 ? m_itemSlot1 : m_itemSlot2;
		switch (_item)
		{
			case ItemType.COLA:
				slot.Texture = m_cola;
				break;
			case ItemType.CANDY:
				break;
			case ItemType.ES:
				break;
			case ItemType.MIEKKA:
				slot.Texture = m_sword;
				break;
			case ItemType.KOLIKKO:
				slot.Texture = m_coin;
				break;
			case ItemType.KUVA:
				break;
			case ItemType.AVAIN:
				slot.Texture = m_key;
				break;
			case ItemType.TIIRIKKA:
				break;
			case ItemType.LUSIKKA:
				slot.Texture = m_spoon;
				break;
			case ItemType.PILLERI:
				break;
			case ItemType.STEROID:
				break;
			case ItemType.KUULOKKEET:
				slot.Texture = m_headphones;
				break;
			case ItemType.LUU:
				slot.Texture = m_bone;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(_item), _item, null);
		}
	}
}