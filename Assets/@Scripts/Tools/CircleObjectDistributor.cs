using System.Collections.Generic;
using UnityEngine;

namespace RopeMaster.Utility
{
    public class CircleObjectDistributor : MonoBehaviour
    {
        public float Radius = 5f;
        private List<GameObject> Points = new List<GameObject>(10);

        private void OnValidate() => UpdateObjectPositions();

        private void Start() => UpdateObjectPositions();

        public void Construct(List<GameObject> points) 
        {
            Points = points;
        }

        public void UpdateObjectPositions()
        {
            if (Points.Count == 0) return;
            
            float angle = 360f / Points.Count;
            float currentAngle = 0f;

            for (int i = 0; i < Points.Count; i++)
            {
                Vector2 objectPosition = new Vector2(
                    Mathf.Cos(currentAngle * Mathf.Deg2Rad),
                    Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * Radius;

                Points[i].transform.position = (Vector2)transform.position + objectPosition;
                currentAngle += angle;
            }
        }
    }
}
