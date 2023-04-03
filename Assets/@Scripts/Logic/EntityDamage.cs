using UnityEngine;

namespace RopeMaster.Logic
{
    public class EntityDamage : MonoBehaviour
    {
        [SerializeField] private int life = 1;
        [SerializeField] private bool canEject;
        [SerializeField] private float forceEject = 1000f;

        [SerializeField] private GameObject particuleDeath;

        private GameObject _target;

        public void Construct(GameObject target) 
        {
            _target = target;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Saw"))
            {
                life--;

                if (canEject)
                {
                    ActiveSaw(collision);
                }

                if (life <= 0)
                {
                    Vector3 enemyDirection = _target.transform.position - transform.position;
                    Vector3 bloodDirection = -enemyDirection.normalized;

                    Quaternion bloodRotation = Quaternion.LookRotation(bloodDirection);
                    bloodRotation.y = 0;

                    Instantiate(particuleDeath, transform.position, bloodRotation);
                    Destroy(gameObject);
                    return;
                }
            }
        }

        private void ActiveSaw(Collider2D collision)
        {
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position) * forceEject);
        }
    }
}
