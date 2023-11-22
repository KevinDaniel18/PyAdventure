using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgNPC : MonoBehaviour
{
    int index = 0;
    public string[] msg = {
        "hola",
        "esta es la primera pregunta",
        "elige bien para pasar al siguiente nivel",
        "cual de esta es una variable en python?"
    };

    public string GetMsg()
    {
        return msg[index];
    }

    public void Next() {

        if (index < msg.Length - 1)
        {
            index++;
        }
    }

    public void Back()
    {

        index = 0;
    }

    public void Again (){

        index = 2;
    }

    public int GetIndex()
    {
        return index;
    }


}
