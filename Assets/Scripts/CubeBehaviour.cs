using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    private Vector3 _initialScale;
    private bool _isFirstTime = true;

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
        if (_isFirstTime)
        {
            _initialScale = cube.transform.localScale;
            _isFirstTime = false;
        }

        if (TryDivide(cube.Chance))
            _exploder.SpawnExplode(_spawner.SpawnCubes(cube.Chance, cube.transform.position, cube.transform.localScale), cube.transform.position);
        else
            _exploder.DestroyExplode(cube, _initialScale);

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
