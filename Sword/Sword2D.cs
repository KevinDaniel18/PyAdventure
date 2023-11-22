using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword2D : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D collider2D;
    public Animator animator;
    public GameObject swordParent;

    void Start()
    {
        playerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Mathf.Abs(horizontalInput) > 0.01f || Mathf.Abs(verticalInput) > 0.01f)
        {
            SetSwordRotation(horizontalInput, verticalInput);
        }

    }

    void SetSwordRotation(float horizontal, float vertical)
    {
        if (horizontal < 0) // Movimiento hacia la izquierda
        {
            swordParent.transform.localPosition = new Vector3(0.3f, -0.7f, 0); // Ajusta la posición de la espada
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (horizontal > 0) // Movimiento hacia la derecha
        {
            swordParent.transform.localPosition = new Vector3(-0.3f, 0, 0); // Ajusta la posición de la espada
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 2);
        }
        else if (vertical < 0) // Movimiento hacia abajo
        {
            swordParent.transform.localPosition = new Vector3(0, 0.1f, 0); // Ajusta la posición de la espada
            swordParent.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (vertical > 0) // Movimiento hacia arriba
        {
            swordParent.transform.localPosition = new Vector3(0, -0.1f, 0); // Ajusta la posición de la espada
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

    }

    public void Attack()
    {
        Debug.Log("Attack method called");
        animator.Play("Attack");
        collider2D.enabled = true;
        Invoke("DisableAttack", 0.15f);
    }


    private void DisableAttack()
    {
        collider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponentInParent<JumpDamage>().LosseLifeAdnHit();
            collider2D.enabled = false;
        }
    }

}

