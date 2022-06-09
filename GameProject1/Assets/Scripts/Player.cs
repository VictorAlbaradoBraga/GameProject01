using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public LayerMask chao;
    public Transform posPe;
    

    private Rigidbody2D rig;
    private Animator anim;

    private float direcao = 0f;
    private bool estaNoChao;
    private int nJump;

    private float dashAtual;
    private bool canDash;
    private bool IsDashing;
    private float durationDash;
    private float dashSpeed;
    
    private bool olhandoDireita;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Dash();


    }

    void Move()
    {
        direcao = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(direcao, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (direcao > 0)
        {
            olhandoDireita = true;
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }
        if (direcao < 0)
        {
            olhandoDireita = false;
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        }

        if (direcao == 0f)
        {
            anim.SetBool("walk", false);
        }

    }
    void Jump()
    {
        estaNoChao = Physics2D.OverlapCircle(posPe.position, 0.3f, chao);
        anim.SetBool("EstaNoChao", estaNoChao);
        anim.SetFloat("velocidadeY", rig.velocity.y);
        if (estaNoChao)
        {
            nJump = 1;
        }
        if (Input.GetButtonDown("Jump") && nJump > 0)
        {
            nJump--;
            rig.velocity = Vector2.up * JumpForce;
        }


    }
    void Dash()
    {
        
        durationDash = 0.4f;
        dashSpeed = 10f;
        if (Input.GetButtonDown("Fire3") && canDash)
        {
            if (dashAtual <= 0)
            {
                StopDash();
                
            }
            
            else
            {
                IsDashing = true;
                dashAtual -= Time.deltaTime;
                anim.SetTrigger("dash");

                if (olhandoDireita)
                {
                    rig.velocity = Vector2.right * dashSpeed;
                    
                    
                }
                else
                {
                    rig.velocity = Vector2.left * dashSpeed;
                    
                }
            }
        }
        if (Input.GetButtonUp("Fire3"))
        {
            IsDashing = false;
            canDash = true;
            dashAtual = durationDash;
            

        }
    }

    private void StopDash()
    {
        rig.velocity = Vector2.zero;
        dashAtual = durationDash;
        IsDashing = false;
        canDash = false;
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            GameC.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }



}