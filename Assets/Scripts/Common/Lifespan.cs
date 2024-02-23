using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    [SerializeField, Range(0, 10)] float lifespan = 1;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }
}
