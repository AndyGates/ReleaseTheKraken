using UnityEngine;
using System.Collections;

public class KrakenDeath : MonoBehaviour 
{
	[SerializeField]
	AudioClip m_deathNoise;

	[SerializeField]
	CameraShake m_cameraShake;

	public void OnDeath()
	{
		GetComponent<AudioSource>().PlayOneShot(m_deathNoise);
		foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>())
		{
			sr.color = Color.red;
		}

		foreach(Collider2D cl in GetComponentsInChildren<Collider2D>())
		{
			cl.enabled = false;
		}
		m_cameraShake.shake = 3.5f;
	}

}
