using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameState : MonoBehaviour
{
	[SerializeField]
	HealthBar m_healthBar;

	[SerializeField]
	Text m_scoreText;

	[SerializeField]
	Text m_boatsText;

	[SerializeField]
	Text m_timerText;

	[SerializeField]
	Text m_comboText;
	               
	[SerializeField]
	int m_startingHealth = 20;
	int m_currentHealth;

	[SerializeField]
	UnityEvent m_onGameOver;

	int m_score;
	int m_boats;
	int m_combo;
	float m_startTime = 0; 

	public int CurrentHealth {get { return m_currentHealth;}}

	private int ComboMultiplier
	{
		get { return (m_combo + 10) / 10; }
	}

	public string ScoreString
	{
		get { return m_score.ToString(); }
	}

	public string BoatsString
	{
		get { return m_boats.ToString(); }
	}

	public string TimeString
	{
		get 
		{
			float timer = GameTime;
			return string.Format("{0:00}:{1:00}", timer / 60, timer % 60);
		}
	}

	public float GameTime {get { return Time.time - m_startTime; } }

	private static GameState m_instance;
	public static GameState instance
	{
		get
		{
			if(m_instance == null)
				m_instance = GameObject.FindObjectOfType<GameState>();
			return m_instance;
		}
	}
	
	void Start () 
	{
		m_startTime = Time.time;
		m_currentHealth = m_startingHealth;
		m_healthBar.Amount = 1.0f;
		UpdateScoreText();
		UpdateComboText();
	}
	
	void Update () 
	{
		if(m_timerText != null) m_timerText.text = TimeString;
	}

	void UpdateComboText()
	{
		m_comboText.text = string.Format("{0}x", ComboMultiplier);
	}

	void UpdateScoreText()
	{
		m_scoreText.text = ScoreString;
		m_boatsText.text = BoatsString;
	}

	public void TakeDamage()
	{
		m_currentHealth--;
		m_healthBar.Amount = (float)m_currentHealth / (float) m_startingHealth;
		m_combo = 0;
		UpdateComboText();

		if(m_currentHealth <= 0)
		{
			OnGameOver();
		}
	}

	public void AddScore()
	{	
		m_boats++;
		m_score+= ComboMultiplier;
		m_combo++;

		UpdateComboText();
		UpdateScoreText();
	}

	public void OnGameOver()
	{
		DontDestroyOnLoad(gameObject);
		m_onGameOver.Invoke();
	}
}
