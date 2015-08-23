using UnityEngine;
using System.Collections;

public class AirBoat : Boat 
{
	[SerializeField]
	GameObject m_projectile;

	bool m_hasFired = false;

	protected override void Update ()
	{
		base.Update ();
		float absPos = Mathf.Abs(transform.localPosition.x);
		if(absPos > 30.0f)
		{
			m_hasFired = false;
			m_dir = transform.localPosition.x < 0 ? 1.0f : -1.0f;
		}

		if(absPos < 0.1f && !m_hasFired)
		{
			m_hasFired = true;
			Vector3 pos = transform.localPosition;
			pos.y -= 3.0f;

			Instantiate(m_projectile, pos, Quaternion.identity);
		}
	}
}
