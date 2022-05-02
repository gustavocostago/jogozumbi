using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController playerController;
    public Slider SliderLife;
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SliderLife.value = playerController.statusJogador.Vida;
    }
    public void LifeUpdate()
    {
        SliderLife.value = playerController.statusJogador.Vida;
    }
}
