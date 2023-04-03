using UnityEngine;

namespace RopeMaster.Logic
{
	public class EntityMovement : MonoBehaviour
	{
		[SerializeField] private float _minSpeed;
		[SerializeField] private float _maxSpeed;
		[SerializeField] private bool _canFollow = true;

		private float _speed;
		private Transform _target;
		public SpriteRenderer _sprite;

		public void Construct(GameObject player) 
		{
			_target = player.transform;
		}

		private void Start()
		{
			_speed = Random.Range(_minSpeed, _maxSpeed);
			transform.up = _target.transform.position - transform.position;
		}

		private void FixedUpdate()
		{
			if (_canFollow && _target != null)
			{
				transform.up = _target.transform.position - transform.position;
			}

			transform.Translate(Vector3.up * Time.deltaTime * _speed);
			_sprite.transform.rotation = Quaternion.identity;

			// TODO
			if (transform.position.x < -100f || transform.position.x > 100f || transform.position.y < -100f || transform.position.y > 100f)
			{
				Destroy(gameObject);
			}
		}
	}
}