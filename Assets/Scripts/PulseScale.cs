using UnityEngine;
using System.Collections;

public class PulseScale : MonoBehaviour {
	Vector3 m_initialScale;

	[SerializeField]
	float m_minScale = 0.9f;

	// Use this for initialization
	void Start () {
		m_initialScale = transform.localScale;	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = m_initialScale * (m_minScale + Mathf.Abs((Mathf.Sin(Time.time) * (1.0f - m_minScale))));
	}
}
