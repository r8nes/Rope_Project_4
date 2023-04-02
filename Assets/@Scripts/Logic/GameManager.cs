using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	public static GameManager GM;

	[Header("Spawn Monsters")]
	[SerializeField] private float _posSpawnMonsters;
	[SerializeField]	private float _timeChangeWaves = 20f;
	[SerializeField]	private Wave[] _waves;

	[Header("Score menu")]
	[SerializeField]	private GameObject _scoreObject;

	[SerializeField]	private TextMeshProUGUI _scoreText;
	[SerializeField]	private TextMeshProUGUI _scoreMenu;
	[SerializeField]	private TextMeshProUGUI _highScoreMenu;

	[Header("Player")]
	[SerializeField] private GameObject _player;
	[SerializeField] private GameObject _particuleDeath;

	private int _actualWave;
	private int _actualScore;
	private bool _isRunning = true;

	private Camera _mainCamera;

	private void Awake()
	{
		if (GameManager.GM == null)
		{
			GameManager.GM = this;
			return;
		}
		Destroy(this);
	}

	private void Start()
	{
		if (!PlayerPrefs.HasKey("Score"))
		{
			PlayerPrefs.SetInt("Score", 0);
		}
		
		if (!PlayerPrefs.HasKey("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", 0);
		}

		if (PlayerPrefs.GetInt("HighScore") <= 0)
		{
			_scoreObject.SetActive(false);
		}

		_mainCamera = Camera.main;

		_highScoreMenu.text = PlayerPrefs.GetInt("highScore").ToString();
		_scoreMenu.text = PlayerPrefs.GetInt("score").ToString();
		_scoreText.text = "0";
	}

	private IEnumerator SpawnMonsters()
	{
		yield return new WaitForSeconds(1f);

		StartCoroutine(DelayChangeWave());
		while (_isRunning)
		{
			Wave w = _waves[_actualWave];

			yield return new WaitForSeconds(Random.Range(w.MinRandom, w.MinRandom));
			
			Vector2 v = Random.insideUnitCircle.normalized * _posSpawnMonsters;
			GameObject original = w.Entities[Random.Range(0, w.Entities.Length)];
			
			if (_isRunning)
			{
				Instantiate(original, v, Quaternion.identity);
			}

			w = null;
		}
		yield break;
	}

	private IEnumerator DelayChangeWave()
	{
		while (_actualWave < _waves.Length - 1)
		{
			yield return new WaitForSeconds(_timeChangeWaves);
			_actualWave++;
		}
		yield break;
	}

	public void AddScore(int score, float timeShake, float magnitudeShake)
	{
		StartCoroutine(Shake(timeShake, magnitudeShake));
		
		_actualScore += score;
		_scoreText.text = _actualScore.ToString();
	}

	public void EndGame()
	{
		StartCoroutine(DelayTransition());
		_isRunning = false;
		PlayerPrefs.SetInt("Score", _actualScore);

		if (PlayerPrefs.GetInt("HighScore") < _actualScore)
		{
			PlayerPrefs.SetInt("HighScore", _actualScore);
		}

		Instantiate(_particuleDeath, _player.transform.position, Quaternion.identity);
		Destroy(_player);
		StartCoroutine(Shake(0.2f, 0.5f));
	}

	private IEnumerator DelayTransition()
	{
		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadScene(0);
		yield break;
	}

	public IEnumerator Shake(float duration, float magnitude)
	{
		Vector3 originalPos = _mainCamera.transform.localPosition;
		
		float elapsed = 0f;
		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;
		
			_mainCamera.transform.localPosition = new Vector3(x, y, _mainCamera.transform.localPosition.z);
			elapsed += Time.deltaTime;
			
			yield return null;
		}
		_mainCamera.transform.localPosition = originalPos;
		yield break;
	}

	public void StartGame()
	{
		Time.timeScale = 1f;
		_isRunning = true;
		StartCoroutine(SpawnMonsters());
	}

	public void QuitApp()
	{
		Application.Quit();
	}
}