using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteracionNPC : MonoBehaviour
{
    [SerializeField] private GameObject marca;
    [SerializeField] private GameObject InteracionPanel;
    [SerializeField] private TMP_Text DialogoTexto;
    [SerializeField, TextArea(6,6)] private string[] DialogoLineas;

    private float typingTime = 0.02f;
    private bool IsPlayerInRange;
    private bool didDialogoStart;
    private int lineIndex;

    void Start()
    {
        
    }

    void Update()
    {
        if (IsPlayerInRange && Input.GetMouseButtonDown(0))
        {
            if (!didDialogoStart)
            {
                StartDialogo();
            }
            else if (DialogoTexto.text == DialogoLineas[lineIndex])
            {
                NextDialogoLine();
            }
            else
            {
                StopAllCoroutines();
                DialogoTexto.text = DialogoLineas[lineIndex];
            }

        }
    }
    private void StartDialogo()
    {
        didDialogoStart = true;
        InteracionPanel.SetActive(true);
        marca.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogoLine()
    {
        lineIndex++;
        if(lineIndex<DialogoLineas.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogoStart=false;
            InteracionPanel.SetActive(false);
            marca.SetActive(true) ;
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine() 
    {
        DialogoTexto.text = string.Empty;

        foreach(char ch in DialogoLineas[lineIndex])
        {
            DialogoTexto.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerInRange = true;
            marca.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerInRange = false;
            marca.SetActive(false);
        }
    }
}
