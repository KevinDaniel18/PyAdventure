using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuFinal : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;


    public void Cerrar()
    {
        SceneManager.LoadScene(0);
    }

    public void MostrarMenuGameOver()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

        menuPausa.GetComponentInChildren<UnityEngine.UI.Button>().gameObject.SetActive(true); // Activa el botón de quitar
        menuPausa.GetComponentInChildren<UnityEngine.UI.Button>().gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = "Quit";

    }
}
