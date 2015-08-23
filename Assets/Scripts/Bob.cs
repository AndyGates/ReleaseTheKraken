using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour 
{
	float m_initialY;
	float m_initialX;

	float m_randomScale;
	float m_startTime;
	
	// Use this for initialization
	void Start () {
		m_initialY = transform.localPosition.y;
		m_initialX = transform.localPosition.x;

		m_startTime = Time.time;
		m_randomScale = Random.Range(0.2f, 0.7f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = transform.localPosition;
		pos.y = m_initialY + (Mathf.Sin(Time.time - m_startTime) * m_randomScale);
		pos.x = m_initialX + (Mathf.Cos(Time.time - m_startTime) * 0.75f * m_randomScale);

		transform.localPosition = pos;
	}
}
