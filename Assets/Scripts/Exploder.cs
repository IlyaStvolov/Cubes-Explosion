using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    public void SpawnExplode(List<Cube> cubes, Vector3 position)
    {
        foreach (Cube cube in cubes)
            cube.Rigidbody.AddExplosionForce(_force, position, _radius);
    }
}
