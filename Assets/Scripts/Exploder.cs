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

    public void DestroyExplode(Cube cube, Vector3 initialScale)
    {
        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;
        float explosionModifier = initialScale.x - scale.x;

        foreach (Cube explodableCube in GetExplodableCubes(position))
        {
            float distance = Vector3.Distance(explodableCube.transform.position, position);

            explodableCube.Rigidbody.AddExplosionForce((_force * explosionModifier / distance), position, _radius * explosionModifier);
        }
    }

    private List<Cube> GetExplodableCubes(Vector3 position)
    {
        List<Cube> explodableCubes = new();
        Collider[] hits = Physics.OverlapSphere(position, _radius);

        foreach (Collider hit in hits)
        {
            if (hit.gameObject.TryGetComponent<Cube>(out Cube cube))
            {
                explodableCubes.Add(cube);
            }
        }

        return explodableCubes;
    }
}
