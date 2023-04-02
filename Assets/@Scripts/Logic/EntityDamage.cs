using UnityEngine;

public class EntityDamage : MonoBehaviour
{
    [SerializeField] private int life = 1;
    [SerializeField] private bool canEject;
    [SerializeField] private float forceEject = 1000f;

    [SerializeField] private GameObject particuleDeath;

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
                Instantiate(particuleDeath, transform.position, Quaternion.identity);
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
