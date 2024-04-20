using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Spawner))]
public class Cube : MonoBehaviour
{
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }
    public void Initialize(Vector3 scale, float separateChance)
    {
        transform.localScale = scale / 2;
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        _spawner.Initialize(separateChance);
    }
}
