using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour 
{
	[SerializeField]
	float m_fadeTime = 1.0f;

	[SerializeField]
	float m_delayIn = 0.0f;

	[SerializeField]
	float m_delayOut = 0.0f;

	SpriteRenderer m_sprite; 

	[SerializeField]
	bool m_fadeInOnStart = false;

	void Start()
	{
		m_sprite = GetComponent<SpriteRenderer>();
		if(m_fadeInOnStart) FadeIn();
	}

	public void FadeIn()
	{
		iTween.ValueTo(gameObject, iTween.Hash("to", 0.0f, "from", 1.0f, "time", m_fadeTime, "delay", m_delayIn, "onupdate", "UpdateAlpha"));
	}

	public void FadeOut()
	{
		iTween.ValueTo(gameObject, iTween.Hash("to", 1.0f, "from", 0.0f, "time", m_fadeTime, "delay", m_delayOut, "onupdate", "UpdateAlpha"));
	}

	void UpdateAlpha(float val)
	{
		Color col = m_sprite.color;
		col.a = val;
		m_sprite.color = col;
	}
}
