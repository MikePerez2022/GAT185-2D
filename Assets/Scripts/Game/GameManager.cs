using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] IntVariable lives;
	[SerializeField] IntVariable score;
	[SerializeField] FloatVariable health;
	[SerializeField] FloatVariable timer;

	[SerializeField] GameObject respawn;

	[Header("Events")]
	[SerializeField] VoidEvent gameStartEvent;
	[SerializeField] GameObjectEvent respawnEvent;

	public enum State
	{
		TITLE,
		START_GAME,
		PLAY_GAME,
		GAME_OVER
	}

	private State state = State.TITLE;

	void Update()
	{
		switch (state)
		{
			case State.TITLE:
				UIManager.Instance.SetActive("Title", true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;

			case State.START_GAME:
				UIManager.Instance.SetActive("Title", false);
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

				// reset values
				timer.value = 60;
				lives.value = 3;
				health.value = 100;

				gameStartEvent.RaiseEvent();
				respawnEvent.RaiseEvent(respawn);

				state = State.PLAY_GAME;
				break;
			case State.PLAY_GAME:
				// game timer
				timer.value = timer - Time.deltaTime;
				if (timer <= 0)
				{
					state = State.GAME_OVER;
				}
				break;
			case State.GAME_OVER:
				break;
			default:
				break;
		}

		//UIManager.Instance.Health = health;
		//UIManager.Instance.Timer = timer;
		//UIManager.Instance.Score = score;
		//UIManager.Instance.Lives = lives;
	}

	public void OnStartGame()
	{
		state = State.START_GAME;
	}

	public void OnPlayerDead()
	{
		state = State.START_GAME;
	}

	public void Attack()
	{
		//weapon.Attack();
	}

	public void OnAddPoints(int points)
	{
		print(points);
	}
}
