using Godot;
using System;

public partial class AudioPlayerScene : AudioStreamPlayer
{
    public static AudioPlayerScene Instance { get; private set; }
    
    [Export]
    private AudioStreamPlayer m_buttonSound;
    
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
        Instance = this;
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

    public void PlayButtonSound()
    {
        m_buttonSound?.Play();
    }
}
