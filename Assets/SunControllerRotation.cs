using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunControllerRotation : MonoBehaviour
{
    [SerializeField] RotationSO rotacion;
    // Start is called before the first frame update
    void Start()
    {
        rotacion.GetTransform(transform);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rotacion.Rotation();
    }
}
