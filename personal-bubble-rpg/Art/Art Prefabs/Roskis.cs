using Godot;
using System;

public partial class Roskis : Node3D
{
    public void OnTriggerEnter(Node _node)
    {
        if (_node is not Player player)
            return;
        
        if (player.CurrentItem != ItemType.STEROID)
        {
            Hud.Instance.ShowTrashTrashTalk();
            return;
        }

        player.CurrentRoskis = this;
        Hud.Instance.ShowHitTrashcan();
    }

    public void OnTriggerExit(Node _node)
    {
        if (_node is not Player player)
            return;
        
        Hud.Instance.HideHitTrashcan();
        Hud.Instance.HideTrashTrashTalk();
    }

    public void OnHit()
    {
        QueueFree();
    }
}
