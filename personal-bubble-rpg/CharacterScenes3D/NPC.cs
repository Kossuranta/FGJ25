using Godot;
using System;

public partial class NPC : Character
{
    [Export]
    private PackedScene m_itemToDrop;

    [Export]
    private AudioStreamPlayer m_playerSeenAudio;

    [Export]
    private Node3D m_playerSeenModel;

    private bool m_fightCompleted;
    private Vector3 m_position;

    public override void _Ready()
    {
        base._Ready();
        if (m_playerSeenModel != null)
            m_playerSeenModel.Visible = false;

        m_position = GlobalPosition;
    }

    public void OnTriggerEnter(Node _node)
    {
        if (m_fightCompleted)
            return;
        
        if (_node is not Player player)
            return;

        if (m_playerSeenModel != null)
            m_playerSeenModel.Visible = true;
        m_playerSeenAudio?.Play();
        
        GD.Print($"START COMBAT! Enemy: {m_type}");
        GameManager.Instance.StartFight(m_type);
        m_fightCompleted = true;
        GameManager.Instance.CombatEnded += OnFightCompleted;
    }

    public void OnFightCompleted(bool _win)
    {
        GameManager.Instance.CombatEnded -= OnFightCompleted;
        
        GD.Print($"OnFightCompleted(win:{_win})");
        if (_win)
        {
            if (m_itemToDrop != null)
            {
                GD.Print("Spawn reward item");
                Item item = (Item)m_itemToDrop.Instantiate();
                GameManager.MainLevel.AddChild(item);
                Vector3 pos = m_position;
                pos.Y = 0.5f;
                item.GlobalPosition = pos;
            }
            else
            {
                GD.Print("No reward item set!");
            }
        }

        if (IsInstanceValid(this))
            QueueFree();
    }
}
