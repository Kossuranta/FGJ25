using Godot;
using System;

public partial class Roskis : Node3D
{
    public void OnTriggerEnter(Node _node)
    {
        GD.Print("trigger");
        if (_node is not Player player)
            return;
        
        GD.Print("trigger player");
        if (player.CurrentItem != ItemType.STEROID)
            return;

        GD.Print("trigger steroid");
        player.CurrentRoskis = this;
        Hud.Instance.ShowHitTrashcan();
    }

    public void OnHit()
    {
        QueueFree();
    }
}
