using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour 
{
	[SerializeField]
	GameObject m_breakPrefab;

	[SerializeField]
	float m_speed = 1.0f;

	float m_initialY;
	protected float m_dir; 

	// Use this for initialization
	protected virtual void Start () 
	{
		m_initialY = transform.localPosition.y;
		m_dir = transform.localPosition.x > 0.0f ? -1.0f : 1.0f;

		Vector3 scale = transform.localScale;
		scale.x *= m_dir;
		transform.localScale = scale;
	}
	
	// Update is called once per frame
	protected virtual void Update () 
	{
		Vector3 pos = transform.localPosition;
		pos.y = m_initialY + (Mathf.Sin(Time.time) / 2.0f);
		pos.x += m_speed * m_dir * Time.deltaTime;
		transform.localPosition = pos;
	}

	protected virtual void OnTriggerEnter2D(Collider2D other) 
	{	
		if(Mathf.Abs(other.attachedRigidbody.velocity.magnitude) > 6.0f || other.gameObject.layer == LayerMask.NameToLayer("Head"))
		{
			if(other.gameObject.layer == LayerMask.NameToLayer("Kraken")) GameState.instance.AddScore();
			Instantiate(m_breakPrefab, transform.localPosition, transform.localRotation);
			Destroy(gameObject);
		}
	}
}
