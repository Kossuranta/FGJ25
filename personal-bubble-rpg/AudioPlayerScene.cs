using Godot;
using System;

public partial class AudioPlayerScene : AudioStreamPlayer
{
    [Export]
    private AudioStream m_normal;
    
    [Export]
    private AudioStream m_combat;
    
    [Export]
    private AudioStream m_gameOver;

    [Export]
    private AudioStream m_gameWin;

    public override void _Ready()
    {
        PlayNormal();
    }

    public void PlayNormal()
    {
        Stream = m_normal;
        Play();
    }
    
    public void PlayCombat()
    {
        Stream = m_combat;
        Play();
    }

    public void PlayGameOver()
    {
        Stream = m_gameOver;
        Play();
    }
    
    public void PlayGameWin()
    {
        Stream = m_gameWin;
        Play();
    }
}
