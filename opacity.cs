/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opacity : MonoBehaviour
{
    [Range(0, 1)]
    public float Transparency = 0, TransitionSpeed = 1;
    public GameObject entrarObjeto;
    public SpriteRenderer spriteRenderer;
    private bool activated = false;
    public enum Modo
    {
        Show = 0,
        Hide = 1,
        Nothing = -1
    };

    public Modo modo;

    // Start is called before the first frame update
    void Start()
    {
        modo = Modo.Nothing;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    //trigger para que valide que el personaje está adentro de la cueva
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            entrarObjeto.SetActive(true);
            if (!activated)
            {
                activated = true;
            }
        }
    }

    //trigger para que valide que el personaje está afuera de la cueva
    private void OnTriggerExit(Collider other)
    {
        if(other.tag== "Player")
        {
            entrarObjeto.SetActive(false);
        }
    }

    // Update is called once per frame

    //se supone que invoco los triggers aqui pero hay error por ser tipo bool
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))//trigger de entrar invocado para cuando entre el personaje se baje la opacidad de la cueva... (ERROR)
        {
            modo = Modo.Hide;
        }
        if (Input.GetKeyDown(KeyCode.D))////trigger de salir invocado para cuando salga el personaje la opacidad sea normal de la cueva... (ERROR)
        {
            modo = Modo.Show;
        }
        if (modo.Equals(Modo.Hide))
        {
            if (Transparency <= 0)
                modo = Modo.Nothing;

            Transparency -= Time.deltaTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Transparency);
        }

        if (modo.Equals(Modo.Show))
        {
            if (Transparency >= 1)
                modo = Modo.Nothing;

            Transparency += Time.deltaTime / 2;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Transparency);
        }

    }

    //tomar descanso para no tener sobrecarga cognitiva :D

}*/
