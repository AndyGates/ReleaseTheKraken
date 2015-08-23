using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour 
{
	[SerializeField]
	Text m_scoreText;

	[SerializeField]
	Text m_boatsText;

	[SerializeField]
	Text m_timeText;

	// Use this for initialization
	void Start () 
	{
		m_scoreText.text = GameState.instance.ScoreString;
		m_boatsText.text = GameState.instance.BoatsString;
		m_timeText.text = GameState.instance.TimeString;
	}
	
	public void Cleanup()
	{
		Destroy(GameState.instance.gameObject);
	}
}
