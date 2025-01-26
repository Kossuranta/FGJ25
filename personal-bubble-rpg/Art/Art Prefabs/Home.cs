using Godot;
using System;

public partial class Home : Node3D
{
    public void OnTriggerEnter(Node _node)
    {
        if (_node is not Player player)
            return;
        
        Hud.Instance.ShowFightDoor();
    }
    
    private void OnTriggerExit(Node _node)
    {
        if (_node is not Player player)
            return;
		
        Hud.Instance.HideFightDoor();
    }
}
