using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public Text pontosUI; 
    public int pontos = 0; 
    
    void Update()
    {
        if (pontos > PlayerPrefs.GetInt("Recorde"))
        {
            PlayerPrefs.SetInt("Recorde", pontos);
        }
        pontosUI.text = "Pontos :" + pontos;
    }
}
