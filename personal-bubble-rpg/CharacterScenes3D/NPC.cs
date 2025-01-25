using Godot;
using System;

public partial class NPC : Character
{
    public void OnTriggerEnter(Node _node)
    {
        if (_node is not Player player)
            return;
        
        GD.Print($"START COMBAT! Enemy: {m_type}");
        GameManager.Instance.StartFight(m_type);
    }
}
