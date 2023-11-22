using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadmovimiento = 3f;

    private Rigidbody2D jugadorrb;
    private Vector2 movimientoinput;
    private Animator jugadoranimacion;
    void Start()
    {
        jugadorrb = GetComponent<Rigidbody2D>();
        jugadoranimacion = GetComponent<Animator>();
      
    }
    void Update()
    {
        float movimientox = Input.GetAxisRaw("Horizontal");
        float movimientoy = Input.GetAxisRaw("Vertical");
        movimientoinput = new Vector2(movimientox, movimientoy).normalized;
        jugadoranimacion.SetFloat("horizontal", movimientox);
        jugadoranimacion.SetFloat("vertical", movimientoy);
        jugadoranimacion.SetFloat("velocidadmovimiento", movimientoinput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        jugadorrb.MovePosition(jugadorrb.position + movimientoinput * velocidadmovimiento * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("soy el jugador, entro en el trigger");
    }


}
