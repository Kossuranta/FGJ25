using System;
using Godot;

[Serializable]
public partial class ItemTexture : Node
{
    [Export]
    public ItemType m_type;

    [Export]
    public Texture2D m_sprite;
}