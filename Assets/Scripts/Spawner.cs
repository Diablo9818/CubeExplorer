using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
[RequireComponent (typeof(Exploder))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private float _separateChanse = 1.0f;
    [SerializeField] private int _maxCubs = 7;
    [SerializeField] private int _minCubs = 2;
    [SerializeField] private Cube _cube;

    private Exploder _exploder;

    private void Awake()
    {
        _exploder = GetComponent<Exploder>();
    }

    private void OnMouseDown() 
    {
        if(Random.value <= _separateChanse)
        {
            SpawnCube(CalculateCubs());
        }
        else
        {
            _exploder.Explode();
        }

        Destroy(gameObject);
        Debug.Log("Chance: " + _separateChanse);
    }

    public void Initialize(float separateChanse)
    {
        _separateChanse = separateChanse / 2;
    }

    private int CalculateCubs()
    {
        return Random.Range(_minCubs, _maxCubs);
    }

    private void SpawnCube(int cubsCount)
    {
        for (int i = 0; i < cubsCount; i++)
        {
            var cube = Instantiate(_cube, transform.position, transform.rotation);
            cube.Initialize(transform.localScale, _separateChanse);
            List<Rigidbody> cubes = new();
            cubes.Add(cube.GetComponent<Rigidbody>());

            foreach (Rigidbody exploadableObject in cubes)
            {
                exploadableObject.AddExplosionForce(_exploder.ExplosionForce, transform.position, _exploder.ExplosionRadius);
            }
        }
    }
}
