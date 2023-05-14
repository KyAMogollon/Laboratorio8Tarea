using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SateliteControllerRotation : MonoBehaviour
{
    [SerializeField] Transform transformTierra;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transformTierra);
        //transform.RotateAround(transformTierra.position,Vector3.up,0.05f);
    }
    private void FixedUpdate()
    {
    }
}
