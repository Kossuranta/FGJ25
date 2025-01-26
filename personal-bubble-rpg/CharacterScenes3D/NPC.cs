using Godot;
using System;

public partial class NPC : Character
{
    [Export]
    private PackedScene m_itemToDrop;

    private bool m_fightCompleted;
    
    public void OnTriggerEnter(Node _node)
    {
        if (m_fightCompleted)
            return;
        
        if (_node is not Player player)
            return;
        
        GD.Print($"START COMBAT! Enemy: {m_type}");
        GameManager.Instance.StartFight(m_type);
        m_fightCompleted = true;
    }
}
