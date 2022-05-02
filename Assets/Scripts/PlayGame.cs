using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public Button botao;
    // Start is called before the first frame update
    void Start()
    {
        botao.onClick.AddListener(IniciaGame);
    }
    void IniciaGame()
    {
        SceneManager.LoadScene("Game");
    }
}
