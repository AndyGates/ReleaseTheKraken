using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageCollision : MonoBehaviour 
{
	SpriteRenderer m_sprite;

	[SerializeField]
	CameraShake m_cameraShake;

	[SerializeField]
	List<AudioClip> m_collisionAudio = new List<AudioClip>();
	
	AudioSource m_source; 

	void Start()
	{
		m_source = GetComponent<AudioSource>();
		m_sprite = GetComponent<SpriteRenderer>();
		m_cameraShake.shake = 1.5f;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		OnDamage();
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("Bomb"))
		{
			OnDamage();
		}
	}

	void OnDamage()
	{
		GameState.instance.TakeDamage();
		StopAllCoroutines();

		if(GameState.instance.CurrentHealth > 0)
		{
			StartCoroutine(DamageColor());

			m_source.PlayOneShot(m_collisionAudio[Random.Range(0, m_collisionAudio.Count)]);
			m_cameraShake.shake = 0.4f;
		}
	}

	IEnumerator DamageColor()
	{
		m_sprite.color = Color.red;
		yield return new WaitForSeconds(1.2f);
		m_sprite.color = Color.white;
	}
}
