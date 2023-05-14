using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonControllerRotation : MonoBehaviour
{
    [SerializeField] RotationSO rotacion;
    [SerializeField] Transform rotacionEarth;
    // Start is called before the first frame update
    void Start()
    {
        rotacion.GetTransform(transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(rotacionEarth.position, Vector3.up,0.05f);
    }
    private void FixedUpdate()
    {
        rotacion.Rotation();
    }
}
