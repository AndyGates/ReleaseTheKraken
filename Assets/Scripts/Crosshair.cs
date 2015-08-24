using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	[SerializeField]
	SpriteRenderer m_cursor;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);	
		//Cursor.SetCursor(m_cursor, Vector2.zero, CursorMode.Auto);
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = 0.0f;
		transform.localPosition =pos;

		m_cursor.color = Input.GetMouseButton(0) ? Color.red : Color.white;
	}
}
