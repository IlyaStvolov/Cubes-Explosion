using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    public List<Cube> SpawnCubes(float chance, Vector3 position, Vector3 scale)
    {
        List<Cube> cubes = new();

        int divider = 2;
        int minAmmount = 2;
        int maxAmmount = 6;
        int randomAmmount = Random.Range(minAmmount, maxAmmount + 1);

        for (int i = 0; i < randomAmmount; i++)
        {
            Cube newCube = Instantiate(_cube, position, Random.rotation);
            newCube.Initialize(chance / divider, scale / divider, Random.ColorHSV());
            cubes.Add(newCube);
        }

        return cubes;
    }
}
