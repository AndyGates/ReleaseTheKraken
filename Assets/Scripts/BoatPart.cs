using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BoatPart : MonoBehaviour 
{
	float m_targetY;
	float m_randomOffset;

	float m_floatTime;
	Rigidbody2D m_rigidbody;
	bool m_floating = false; 

	void Start () 
	{
		m_randomOffset = Random.Range(0.0f, 1.0f);
		float parenty = transform.parent.localPosition.y;

		m_targetY = Random.Range(transform.localPosition.y - 2.0f, transform.localPosition.y);

		if(m_targetY + parenty > -2.0f)
		{
			m_targetY = Random.Range(-10.0f - parenty, -4.0f - parenty);
		}
	
		m_rigidbody = GetComponent<Rigidbody2D>();
		m_rigidbody.AddForce(new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(1.0f, 10.0f)), ForceMode2D.Impulse);
		m_rigidbody.AddTorque(Random.Range(10.0f, 100.0f));
	}

	void LateUpdate()
	{
		if(!m_floating && Mathf.Abs(transform.localPosition.y - m_targetY) < 0.3f)
		{
			m_rigidbody.isKinematic = true;
			m_floating = true;
		}
		else if(m_floating)
		{
			m_floatTime += Time.deltaTime;

			Vector3 pos = transform.localPosition;
			pos.y = m_targetY + (Mathf.Sin(m_floatTime) * m_randomOffset);
			transform.localPosition = pos;

			if(m_floatTime > Random.Range(3.0f, 6.0f)) Destroy(gameObject);
		}
	}
}
