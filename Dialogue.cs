using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI DialogoText;
    [SerializeField, TextArea(5, 3)] private string[] DialogoLineas;
    public string[] lines;
    private float typingTime = 0.05f;
    int index;



    void Start()
    {
        DialogoText.text = string.Empty;
        StartDialogo();
    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0)) 
        { 
            if(DialogoText.text == lines[index]) 
            { 
                NextLine();
            }
            else
            {
                
                StopAllCoroutines();
                DialogoText.text = lines[index];
            }
        }
    }

    public void StartDialogo()
    {
       
        index = 0;
        StartCoroutine(WriteLine());
        Time.timeScale = 0f;

    }
    

    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            DialogoText.text += letter;
            yield return new WaitForSecondsRealtime(typingTime);
        }

    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            DialogoText.text = string.Empty;
            StartCoroutine (WriteLine());
        }
        else 
        {
            gameObject.SetActive(false);
            Time.timeScale= 1f ;
        }
    }
}

