using UnityEngine;

namespace RopeMaster.Logic
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _forceSawToPlayer = 300f;

		[SerializeField] private Transform _sawTransform;
		[SerializeField] private GameObject _particleForceSaw;

		private Camera _camera;
		private Rigidbody2D _rb;
		private LineRenderer _line;

		private void Start()
		{
			_camera = Camera.main;

			_rb = GetComponent<Rigidbody2D>();
			_line = GetComponent<LineRenderer>();
		}

		private void Update()
		{
			_line.SetPosition(0, transform.position);
			_line.SetPosition(1, _sawTransform.position);

			Vector3 vector = _camera.ScreenToWorldPoint(Input.mousePosition);

			_rb.position = new Vector3(vector.x, vector.y, 0f);

			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Instantiate(_particleForceSaw, _sawTransform.position, Quaternion.identity);
				Rigidbody2D component = _sawTransform.gameObject.GetComponent<Rigidbody2D>();
				component.velocity = Vector2.zero;
				component.AddForce((transform.position - _sawTransform.position).normalized * _forceSawToPlayer);
			}
		}
	}
}