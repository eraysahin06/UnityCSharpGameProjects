using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
