using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Emote Animator")]
    [SerializeField] private Animator emoteAnimator;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [SerializeField] Text msgText;

    [SerializeField] Button next;
    [SerializeField] Button back;
    [SerializeField] Button resCorrecta;//boton correcto y se quita el sistema de dialogo
    [SerializeField] Button resIncorrecta;//boton incorrecto y se reinicia el sistema de dialogo

    GameObject actualNPC;

    private bool playerInRange;

    [SerializeField] GameObject msgPanel;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
    }

    void Start()
    {
        msgPanel.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualCue.SetActive(true);
            resCorrecta.gameObject.SetActive(false);
            resIncorrecta.gameObject.SetActive(false);

            if (actualNPC.GetComponent<MsgNPC>().GetIndex() == actualNPC.GetComponent<MsgNPC>().msg.Length - 1)
            {
                // Activar los botones de respuesta
                resCorrecta.gameObject.SetActive(true);
                resIncorrecta.gameObject.SetActive(true);
            }
        }
        else
        {
            visualCue.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            actualNPC = collider.gameObject;
            string msg = actualNPC.GetComponent<MsgNPC>().GetMsg();
            msgText.text = msg;
            msgPanel.SetActive(true);
            playerInRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            msgPanel.SetActive(false);

            if (actualNPC)
            {
                actualNPC.GetComponent<MsgNPC>().Back();
                string msg = actualNPC.GetComponent<MsgNPC>().GetMsg();
                msgText.text = msg;

                // Desactivar los botones de respuesta
                resCorrecta.gameObject.SetActive(false);
                resIncorrecta.gameObject.SetActive(false);
            }
        }
    }

    public void Next()
    {
        if (actualNPC)
        {
            actualNPC.GetComponent<MsgNPC>().Next();
            string msg = actualNPC.GetComponent<MsgNPC>().GetMsg();
            msgText.text = msg;
            resCorrecta.gameObject.SetActive(false);
            resIncorrecta.gameObject.SetActive(false);

            if (actualNPC.GetComponent<MsgNPC>().GetIndex() == actualNPC.GetComponent<MsgNPC>().msg.Length - 1)
            {
                // Activar los botones de respuesta
                resCorrecta.gameObject.SetActive(true);
                resIncorrecta.gameObject.SetActive(true);

            }

        }
    }

    public void Back()
    {
        if (actualNPC)
        {
            actualNPC.GetComponent<MsgNPC>().Back();
            string msg = actualNPC.GetComponent<MsgNPC>().GetMsg();
            msgText.text = msg;
        }
    }

    public void ResCorrecta()
    {
        GameObject puertaNivel3 = GameObject.FindGameObjectWithTag("PuertaNivel3");
        if (puertaNivel3 != null)
        {
            puertaNivel3.SetActive(false);
        }

        GameObject npc = GameObject.FindGameObjectWithTag("npc");
        if (npc != null)
        {
            npc.SetActive(false);
        }


        msgPanel.SetActive(false);
        resCorrecta.gameObject.SetActive(false);
        resIncorrecta.gameObject.SetActive(false);
    }

    public void ResIncorrecta()
    {

        if (actualNPC)
        {
            actualNPC.GetComponent<MsgNPC>().Again();
            string msg = actualNPC.GetComponent<MsgNPC>().GetMsg();
            msgText.text = msg;
        }
    }
}
