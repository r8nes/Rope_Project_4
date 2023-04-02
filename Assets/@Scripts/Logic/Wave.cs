using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Wave", menuName = "Entity")]
public class Wave : ScriptableObject
{
	public float MinRandom = 0.5f;
	public float MaxRandom = 3f;

	public GameObject[] Entities;
}