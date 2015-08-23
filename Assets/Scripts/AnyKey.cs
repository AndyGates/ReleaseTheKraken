using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class AnyKey : MonoBehaviour {

	[SerializeField]
	UnityEvent m_onAnyKey;

	// Update is called once per frame
	void Update () 
	{
		if(Input.anyKeyDown)
		{
			m_onAnyKey.Invoke();
		}
	}
}
