using UnityEngine;
using System.Collections;

public class DelayedDestroy : MonoBehaviour {

	[SerializeField]
	float m_delay = 5.0f;

	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, m_delay);	
	}
}
