using UnityEngine;

public class JointObjectRotation : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }
}