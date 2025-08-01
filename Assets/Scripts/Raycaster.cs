using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;

    private int _leftMouseButton = 0;

    public event Action<Cube> OnCubeHit;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.TryGetComponent<Cube>(out Cube cube))
                {
                    OnCubeHit?.Invoke(cube);
                }
            }
        }
    }
}
