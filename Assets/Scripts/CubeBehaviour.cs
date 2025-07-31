using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Cube _cube;

    private void OnMouseUpAsButton()
    {
        if (TryDivide(_cube.Chance))
            _exploder.SpawnExplode(_spawner.SpawnCubes(_cube.Chance, _cube.transform.position, _cube.transform.localScale), _cube.transform.position);

        Destroy(gameObject);
    }

    private bool TryDivide(float chance)
    {
        float randomMin = 0;
        float randomMax = 100;
        float randomChance = Random.Range(randomMin, randomMax);

        if (randomChance <= chance)
            return true;
        else
            return false;
    }
}
