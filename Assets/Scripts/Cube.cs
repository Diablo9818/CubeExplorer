using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Exploder))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _decreaseCount = 2;
    private Spawner _spawner;
    private Exploder _exploder;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _exploder = GetComponent<Exploder>();
    }

    public void Initialize(Vector3 scale, float separateChance, float explosionRadius, float explosionForce)
    {
        transform.localScale = scale / _decreaseCount;
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        _spawner.Initialize(separateChance);
        _exploder.Initialize(explosionRadius, explosionForce);
    }
}
