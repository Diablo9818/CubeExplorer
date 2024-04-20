using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _increaseCount;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    public float ExplosionRadius => _explosionRadius;

    public float ExplosionForce => _explosionForce;

    public void Initialize(float explosionRadius, float explosionForce)
    {
        _explosionRadius = explosionRadius * _increaseCount;
        _explosionForce = explosionForce * _increaseCount;
    }

    public void Explode()
    {
        foreach (Rigidbody exploadableObject in GetExplodableObjects())
        {
            exploadableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Instantiate(_effect, transform.position, transform.rotation);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
