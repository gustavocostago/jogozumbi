using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour,IDamage
{
    Vector3 move_direction;
    public LayerMask floorMask;
    public GameObject GameOver;
    public Button playAgain;
    public Text TextPlacar;
    private int armazenascore;
    public Text TextLife;
    public InterfaceController InterfaceController;
    public AudioClip DamageAudio;
    private PlayerMoviment myMovePlayer;
    private PlayersAnimation aniPlayer;
    public Status statusJogador;
    private void Start()
    {
        Time.timeScale = 1;
        myMovePlayer = GetComponent<PlayerMoviment>();
        aniPlayer = GetComponent<PlayersAnimation>();
        statusJogador = GetComponent<Status>();
    }
    void Hud()
    {
        TextPlacar.text = "Kills: " + armazenascore;
        TextLife.text = "Life " + statusJogador.Vida;
    }
    public void Verifica(bool verifica)
    {
        if (true)
        {
            armazenascore = MaisUm(armazenascore);
        }
    }
    int MaisUm(int score)
    {
        score += 1;
        return score;
    }
    void Update()
    {
        MovePlayer();
        RestartGame(true);
        Hud();
    }

    void FixedUpdate()
    {

        myMovePlayer.Moviment(move_direction, statusJogador.Velocidade);
        myMovePlayer.MovePlayer(floorMask);

    }
    void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void RestartGame(bool vivo)
    {
        if (vivo == false)
        {
            playAgain.onClick.AddListener(LoadScene);
        }
    }
    void MovePlayer()
    {
        move_direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        aniPlayer.AnimMove(move_direction.magnitude);
    }
    public void Damage(int dano)
    {
        statusJogador.Vida -= dano;
        AudioController.instacia.PlayOneShot(DamageAudio);
        InterfaceController.LifeUpdate();
        if (statusJogador.Vida <= 0) {
           Dead();
           RestartGame(false);
        }
    }
    public void Dead()
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }
}
