using TMPro;
using UnityEngine;

namespace RopeMaster.Logic
{

    public class GameManager : MonoBehaviour
	{
		public static GameManager GM;

		[Header("Score menu")]
		[SerializeField] private GameObject _scoreObject;

		[SerializeField] private TextMeshProUGUI _scoreText;
		[SerializeField] private TextMeshProUGUI _scoreMenu;
		[SerializeField] private TextMeshProUGUI _highScoreMenu;

		[Header("Player")]
		[SerializeField] private GameObject _player;
		[SerializeField] private GameObject _particuleDeath;

		private int _actualScore;


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

			_scoreMenu.text = "MENU";

			_highScoreMenu.text = $"Hight Score: {PlayerPrefs.GetInt("HighScore")}";
			_scoreText.text = $"Score: {PlayerPrefs.GetInt("Score")}";
		}

		//private IEnumerator SpawnMonsters()
		//{
		//	yield return new WaitForSeconds(1f);

		//	StartCoroutine(DelayChangeWave());
		//	while (_isRunning)
		//	{
		//		Wave w = _waves[_actualWave];

		//		yield return new WaitForSeconds(Random.Range(w.MinRandom, w.MinRandom));

		//		Vector2 v = Random.insideUnitCircle.normalized * _posSpawnMonsters;
		//		GameObject original = w.Entities[Random.Range(0, w.Entities.Length)];

		//		if (_isRunning)
		//		{
		//			Instantiate(original, v, Quaternion.identity);
		//		}

		//		w = null;
		//	}
		//	yield break;
		//}

		//private IEnumerator DelayChangeWave()
		//{
		//	while (_actualWave < _waves.Length - 1)
		//	{
		//		yield return new WaitForSeconds(_timeChangeWaves);
		//		_actualWave++;
		//	}
		//	yield break;
		//}

		public void AddScore(int score, float timeShake, float magnitudeShake)
		{
			_actualScore += score;
			_scoreText.text = _actualScore.ToString();
		}

		//public void EndGame()
		//{
		//	_isRunning = false;
		//	PlayerPrefs.SetInt("Score", _actualScore);

		//	if (PlayerPrefs.GetInt("HighScore") < _actualScore)
		//	{
		//		PlayerPrefs.SetInt("HighScore", _actualScore);
		//	}

		//	Instantiate(_particuleDeath, _player.transform.position, Quaternion.identity);
		//	Destroy(_player);
		//}

		//private IEnumerator DelayTransition()
		//{
		//	yield return new WaitForSecondsRealtime(2f);
		//	SceneManager.LoadScene(0);
		//	yield break;
		//}

		//public IEnumerator Shake(float duration, float magnitude)
		//{
		//	Vector3 originalPos = _mainCamera.transform.localPosition;

		//	float elapsed = 0f;
		//	while (elapsed < duration)
		//	{
		//		float x = Random.Range(-1f, 1f) * magnitude;
		//		float y = Random.Range(-1f, 1f) * magnitude;

		//		_mainCamera.transform.localPosition = new Vector3(x, y, _mainCamera.transform.localPosition.z);
		//		elapsed += Time.deltaTime;

		//		yield return null;
		//	}
		//	_mainCamera.transform.localPosition = originalPos;
		//	yield break;
		//}

		//public void StartGame()
		//{
		//	Time.timeScale = 1f;
		//	_isRunning = true;
		//	_player.GetComponent<PlayerMovement>().enabled = true;
		//	StartCoroutine(SpawnMonsters());
		//	_scoreObject.SetActive(false);
		//}
	}
}