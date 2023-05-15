using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 angulos;
    [SerializeField] private Quaternion qx = Quaternion.identity;
    [SerializeField] private Quaternion qy = Quaternion.identity;
    [SerializeField] private Quaternion qz = Quaternion.identity;

    [SerializeField] private Quaternion r = Quaternion.identity;

    float horizontal;
    float vertical;
    private float anguloSen;
    private float anguloCos;
    public int speed;
    public int speedRotation;
    public float ImpulsoZ = 1;
    public float ImpulsoX = 1;
    Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -250, 250), Mathf.Clamp(transform.position.y, -150, 150));

        if (horizontal < 0)
        {
            if (angulos.z < 35)
            {
                ImpulsoZ = ImpulsoZ + Time.deltaTime * speedRotation;
                angulos.z = ImpulsoZ;
            }
        }
        else if (horizontal == 0)
        {
            ImpulsoZ = 0;
            angulos.z = ImpulsoZ;
        }
        else if (horizontal > 0)
        {
            if (angulos.z > -35)
            {
                ImpulsoZ = ImpulsoZ + Time.deltaTime * speedRotation;
                angulos.z = ImpulsoZ * -1;
            }
        }
        if (vertical < 0)
        {
            if (angulos.x < 35)
            {
                ImpulsoX = ImpulsoX + Time.deltaTime * speedRotation;
                angulos.x = ImpulsoX;
            }
        }
        else if (vertical == 0)
        {
            ImpulsoX = 0;
            angulos.x = ImpulsoX;
        }
        else if (vertical > 0)
        {
            if (angulos.x > -35)
            {
                ImpulsoX = ImpulsoX + Time.deltaTime * speedRotation;
                angulos.x = ImpulsoX * -1;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MovePlane();
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.z * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.z * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.y * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.y * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy * qx * qz;

        transform.rotation = r;
        int direction=0;
        int speedTwoDirection = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            direction = 1;
        }
        _rb.velocity = new Vector3(horizontal*speed, vertical*speed, speedTwoDirection * direction);
    }
    private void MovePlane()
    {
    }
}
