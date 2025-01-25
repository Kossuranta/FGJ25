using Godot;
using System;

public partial class NPC : Character
{
    [Export]
    private OnTriggerEnter m_onTriggerEnter;
    
    public override void _Ready()
    {
        m_onTriggerEnter.m_onTriggerEnter += StartCombat;
    }

    private void StartCombat()
    {
        GD.Print($"START COMBAT! Enemy: {m_type}");
    }
}
