using Godot;
using System;

public partial class Vendingmachine : Node3D
{
    public void OnTriggerEnter(Node _node)
    {
        if (_node is not Player player)
            return;
		
        if (player.CurrentItem != ItemType.KOLIKKO)
        {
            Hud.Instance.ShowVendingBuyNoMoney();
            return;
        }

        Hud.Instance.ShowVendingBuy();
    }

    public void OnTriggerExit(Node _node)
    {
        if (_node is not Player player)
            return;
		
        Hud.Instance.HideVendingBuy();
    }
}
