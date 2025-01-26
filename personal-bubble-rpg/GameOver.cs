using Godot;
using System;

public partial class GameOver : MarginContainer
{
    [Export]
    private float m_fadeDuration = 1f;

    [Export]
    private Label m_fadeOutCounter;

    [Export]
    private float m_delay = 5f;

    private bool m_targetState;
    private float m_current;
    private bool m_fading;
    private float m_delayCounter;
    private bool m_delayRunning;

    public Action FadeOutCompleted;
    
    public override void _Ready()
    {
        Color color = Modulate;
        color.A = 0;
        Modulate = color;
        Visible = false;
    }

    public void Toggle(bool _state, int _fadeOutCount)
    {
        Visible = true;
        m_fading = true;
        m_targetState = _state;
        if (_state && m_fadeOutCounter != null)
            m_fadeOutCounter.Text = _fadeOutCount.ToString();

        m_current = _state ? 0f : 1f;
        Color color = Modulate;
        color.A = m_current;
        Modulate = color;
    }
    
    public override void _Process(double _delta)
    {
        float delta = (float) _delta;
        if (m_delayRunning)
        {
            if (GameManager.Instance.GameWinState)
                return;
            
            m_delayCounter -= delta;

            if (m_delayCounter < 0)
            {
                m_delayRunning = false;
                GameManager.Instance.RestartGame();
            }
        }
        else if (m_fading)
        {
            if (m_targetState)
            {
                m_current += m_fadeDuration * delta;

                if (m_current >= 1f)
                {
                    m_fading = false;
                    GD.Print("FadeInCompleted");
                    m_delayRunning = true;
                    m_delayCounter = m_delay;
                }
            }
            else
            {
                m_current -= m_fadeDuration * delta;

                if (m_current <= 0f)
                {
                    m_fading = false;
                    Visible = false;
                    GD.Print("FadeOutCompleted");
                    FadeOutCompleted?.Invoke();
                }
            }

            m_current = Mathf.Clamp(m_current, 0, 1f);
            Color color = Modulate;
            color.A = m_current;
            Modulate = color;
        }
    }
}
