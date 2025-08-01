using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.OnCubeHit += InitializeExplosion;
    }

    private void OnDisable()
    {
        _raycaster.OnCubeHit -= InitializeExplosion;
    }

    private void InitializeExplosion(Cube cube)
    {
        if (TryDivide(cube.Chance))
            _exploder.SpawnExplode(_spawner.SpawnCubes(cube.Chance, cube.transform.position, cube.transform.localScale), cube.transform.position);

        Destroy(cube.gameObject);
    }

    private bool TryDivide(float chance)
    {
        float randomMin = 0;
        float randomMax = 100;
        float randomChance = Random.Range(randomMin, randomMax);

        return randomChance <= chance;
    }
}
