using UnityEngine;
using System.Collections;

public class Tentacle : MonoBehaviour {

	static KeyCode CurrentKey = KeyCode.None;

	[SerializeField]
	Rigidbody2D m_tip;

	[SerializeField]
	KeyCode m_activationKey; 

	[SerializeField]
	float m_speed = 60.0f;

	bool m_selected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ((CurrentKey == KeyCode.None || CurrentKey == m_activationKey) && Input.GetKey(m_activationKey))
		{
			if(!m_selected) SetSelectedState(true);
			if(Input.GetMouseButton(0))
			{
				Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector3 dir = mousePos - m_tip.transform.position;
				dir.Normalize();

				m_tip.AddForce(new Vector2(dir.x, dir.y) * m_speed, ForceMode2D.Force);
			}
		}	
		else if(m_selected)
		{
			SetSelectedState(false);
		}
	}

	void SetSelectedState(bool selected)
	{
		CurrentKey = selected ? m_activationKey : KeyCode.None;
		m_selected = selected;
		foreach(SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
		{
			sr.color = selected ? Color.yellow : Color.white;
		}

		/*
		foreach(HingeJoint2D hj in gameObject.GetComponentsInChildren<HingeJoint2D>())
		{
			hj.useLimits = !selected;
		}
		*/
	}
}
