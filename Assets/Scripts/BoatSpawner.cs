using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoatSpawner : MonoBehaviour {

	[SerializeField]
	float m_spawnDelay = 1.0f;

	[SerializeField]
	float m_startDelay = 0.0f;

	[SerializeField]
	GameObject m_boat;

	[SerializeField]
	List<AudioClip> m_sounds = new List<AudioClip>();

	[SerializeField]
	int m_soundChance = 30;

	float m_lastSpawnTime = 0;
	AudioSource m_source;

	void Start () 
	{
		m_source = GetComponent<AudioSource>();
		m_lastSpawnTime = GameState.instance.GameTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float gameTime = GameState.instance.GameTime;

		if((gameTime > m_startDelay) && (gameTime - m_lastSpawnTime > m_spawnDelay))
		{
			Vector3 pos = transform.localPosition;
			pos.y += Random.Range(-4.0f, 2.0f);

			Instantiate(m_boat, pos, transform.localRotation);
			m_lastSpawnTime = gameTime;

			if(Random.Range(0, m_soundChance) == 0)
			{
				m_source.PlayOneShot(m_sounds[Random.Range(0, m_sounds.Count)]);
			}
		}
	}
}
