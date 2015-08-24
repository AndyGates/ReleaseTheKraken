using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeAway : MonoBehaviour {

	[SerializeField]
	float m_fadeTime = 1.0f;
	
	[SerializeField]
	float m_delayIn = 0.0f;
	
	[SerializeField]
	float m_delayOut = 0.0f;

	SpriteRenderer m_image;

	public void Start()
	{
		m_image = GetComponent<SpriteRenderer>();

		if(m_delayIn > 0 )
		{
			iTween.ValueTo(gameObject, iTween.Hash("to", 1.0f, "from", 0.0f, "time", m_fadeTime, "delay", m_delayIn, "onupdate", "UpdateAlpha"));
		}

		iTween.ValueTo(gameObject, iTween.Hash("to", 0.0f, "from", 1.0f, "time", m_fadeTime, "delay", m_delayIn + m_delayOut, "onupdate", "UpdateAlpha"));
	}
	
	void UpdateAlpha(float val)
	{
		Color col = m_image.color;
		col.a = val;
		m_image.color = col;
	}
}
