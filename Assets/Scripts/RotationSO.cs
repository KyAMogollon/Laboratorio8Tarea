using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RotationSO", menuName = "ScriptableObjects/RotationSO", order = 1)]
public class RotationSO : ScriptableObject
{
    [SerializeField] private Quaternion qy = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    public float speedRotation;
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotation()
    {
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * speedRotation * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * speedRotation * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);
        transform.rotation *= qy;
    }
    public void GetTransform(Transform transform)
    {
        this.transform = transform;
    }
    
}
