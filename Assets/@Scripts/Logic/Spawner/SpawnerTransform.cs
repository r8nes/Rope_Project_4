using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RopeMaster.Logic
{
    [Serializable]
    public class SpawnerTransform
    {
        public Vector2 Transform;
        public SpawnerTransform(Vector2 transform) 
        {
            Transform = transform;
        }
    }
}
