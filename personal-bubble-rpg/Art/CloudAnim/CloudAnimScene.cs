using Godot;
using System;

public partial class CloudAnimScene : Control
{
	[Export]
	private AnimatedSprite2D m_animatedSprite;

	private Viewport m_viewport;
	private Vector2 m_spriteSize;

	public Action FadeInCompleted;
	public Action FadeOutCompleted;

	private bool m_isFadeIn;
	
	public override void _Ready()
	{
		m_spriteSize = m_animatedSprite.SpriteFrames.GetFrameTexture(m_animatedSprite.Animation, 0).GetSize();
		m_viewport = GetViewport();
		m_viewport.SizeChanged += OnSizeChanged;
		OnSizeChanged();
	}
	
	public void OnAnimationLooped()
	{
		m_animatedSprite.Stop();
		if (m_isFadeIn)
		{
			m_animatedSprite.SetFrame(17);
			FadeInCompleted?.Invoke();
		}
		else
		{
			m_animatedSprite.SetFrame(20);
			FadeOutCompleted?.Invoke();
		}
	}

	public void FadeIn()
	{
		m_isFadeIn = true;
		m_animatedSprite.Play("FadeIn");
	}
	
	public void FadeOut()
	{
		m_isFadeIn = false;
		m_animatedSprite.Play("FadeOut");
	}

	private void OnSizeChanged()
	{
		Vector2 viewSize = m_viewport.GetVisibleRect().Size;
		Vector2 scaleFactor = viewSize / m_spriteSize;
		m_animatedSprite.Scale = scaleFactor;
	}
}
