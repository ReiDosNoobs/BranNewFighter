using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
    public static PointScript instance;
    
    public Text pontosUI;// Arrastar da hierarquia Pontos para a variavel publica
                         // Pontos da Main Camera
    public Text recordeUI;// Arrastar da hierarquia Recorde para a variavel publica
                          // Recorde da Main Camera
    public int pontos = 0;// Dar acesso ao script nave, por isso public

    public int recorde = 0;

    /*private void Awake()
    {
        instance = this;
    }*/

    public void AddPoint(int iniValor)
    {
        pontos = pontos + iniValor;
        /*if (recorde < pontos)
        {
            PlayerPrefs.SetInt("recorde", pontos);
        }*/
    }

    void Update()
    {
        if (pontos > PlayerPrefs.GetInt("Recorde"))
        {
            PlayerPrefs.SetInt("Recorde", pontos);
        }
        pontosUI.text = "Pontos :" + pontos;
        recordeUI.text = "Recorde: " + PlayerPrefs.GetInt("Recorde");
    }
}
