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

    public override void _Ready()
    {
        base._Ready();
        if (m_playerSeenModel != null)
            m_playerSeenModel.Visible = false;
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
    }
}
