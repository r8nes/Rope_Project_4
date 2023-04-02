using UnityEngine;

public class EntityMovement : MonoBehaviour
{
	[SerializeField] private float _minSpeed;
	[SerializeField]	private float _maxSpeed;
	[SerializeField]	private bool _canFollow = true;

	private float _speed;
	private Transform _target;

	private void Start()
	{
		_speed = Random.Range(_minSpeed, _maxSpeed);
		_target = FindObjectOfType<PlayerMovement>().transform;
		transform.up = _target.transform.position - transform.position;
	}

	private void FixedUpdate()
	{
		if (_canFollow && _target != null)
		{
			transform.up = _target.transform.position - transform.position;
		}
		transform.Translate(Vector3.up * Time.deltaTime * _speed);
		
		// TODO
		if (transform.position.x < -100f || transform.position.x > 100f || transform.position.y < -100f || transform.position.y > 100f)
		{
			Destroy(gameObject);
		}
	}
}