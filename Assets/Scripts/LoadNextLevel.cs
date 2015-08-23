using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {

	[SerializeField]
	string m_nextLevel = "Main";
	
	[SerializeField]
	float m_delay = 1.0f; 
	
	// Update is called once per frame
	public void LoadNext() 
	{
		StartCoroutine(DoLoad());
	}
	
	IEnumerator DoLoad()
	{
		yield return new WaitForSeconds(m_delay);
		Application.LoadLevel(m_nextLevel);
	}
}
