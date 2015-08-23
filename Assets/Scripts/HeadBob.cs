using UnityEngine;
using System.Collections;

public class HeadBob : MonoBehaviour {

	float m_initialY;
	float m_randomScale;
	float m_startTime;

	// Use this for initialization
	void Start () {
		m_initialY = transform.localPosition.y;
		m_startTime = Time.time;
		m_randomScale = Random.Range(0.2f, 0.7f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = transform.localPosition;
		pos.y = m_initialY + (Mathf.Sin(Time.time - m_startTime) * m_randomScale);
		transform.localPosition = pos;
	}
}
