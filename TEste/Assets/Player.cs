using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;


    public Rigidbody2D rig;

    private float direcao = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        direcao = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rig.velocity = new Vector2(direcao * Speed, rig.velocity.y);
    }


}