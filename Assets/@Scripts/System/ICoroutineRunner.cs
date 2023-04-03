using System.Collections;
using UnityEngine;

namespace RopeMaster.System
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}

