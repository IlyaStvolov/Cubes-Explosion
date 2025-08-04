using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _divisionChance;

    public Rigidbody Rigidbody { get; private set; }
    public float Chance => _divisionChance;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(float chance, Vector3 scale, Color color)
    {
        _divisionChance = chance;
        transform.localScale = scale;
        GetComponent<Renderer>().material.color = color;
    }
}
