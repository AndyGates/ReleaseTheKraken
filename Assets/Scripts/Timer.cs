using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	Text m_text;

	// Use this for initialization
	void Start () 
	{
		m_text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_text.text = Time.time.ToString("0:00");
	}
}
