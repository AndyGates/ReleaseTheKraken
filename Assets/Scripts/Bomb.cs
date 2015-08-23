using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour 
{
	[SerializeField]
	GameObject m_explosion;

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("Head"))
		{
			GameObject go = Instantiate(m_explosion, transform.localPosition, Quaternion.identity) as GameObject;
			Destroy(gameObject);
			Destroy(go, 0.3f);
		}
	}
}
