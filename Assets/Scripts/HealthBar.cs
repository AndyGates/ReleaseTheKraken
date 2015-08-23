using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField]
	Image m_healthImage;

	public float Amount 
	{ 
		set { Vector2 scale = m_healthImage.rectTransform.localScale; scale.x = value; m_healthImage.rectTransform.localScale = scale; }
	}
}
