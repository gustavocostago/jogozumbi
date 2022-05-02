using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamage
{
    public GameObject player;
    private Status statusInimigo;
    private Vector3 direcao;
    private float distance;
    private PlayersAnimation enemyAnim;
    private CharacterMoviment enemyMov;
    public AudioClip deadAudio;
    private Vector3 posicaoAleatoria;
    private float contadorVagar;
    private float tempoEntrePosicoesAleatorias = 4;
    private void Start()
    {
        enemyAnim = GetComponent<PlayersAnimation>();
        enemyMov = GetComponent<CharacterMoviment>();
        statusInimigo = GetComponent<Status>();
        player = GameObject.FindWithTag("Player");
        ZombieRandom();
    }

    void FixedUpdate()
    {
        RotateEnemy();
        enemyAnim.AnimMove(direcao.magnitude);
        if(distance > 15){
            Vagar();
        }
        else if (distance > 2.5)
        {
            direcao = player.transform.position - transform.position;
            enemyMov.Moviment(direcao, statusInimigo.Velocidade);
            enemyAnim.Attack(false);
        }
        else
        {
            enemyAnim.Attack(true);
        }
    }
    void Vagar() {
        contadorVagar -= Time.deltaTime;
        if(contadorVagar <= 0)
        {
            posicaoAleatoria = AleatorizarPosicao();
            contadorVagar += tempoEntrePosicoesAleatorias;
        }
        bool ficouPertoOSuficiente = Vector3.Distance(transform.position, posicaoAleatoria) <= 0.05;
        if(ficouPertoOSuficiente == false)
        {
            direcao = posicaoAleatoria - transform.position;
            enemyMov.Moviment(direcao, statusInimigo.Velocidade);
        }
    }
    Vector3 AleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * 10;
        posicao += transform.position;
        posicao.y = transform.position.y;
        return posicao;
    }
    void PlayerAttack()
    {
        player.GetComponent<PlayerController>().Damage(25);
    }
    void RotateEnemy()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        enemyMov.Rotacionar(direcao);
    }
    void ZombieRandom()
    {
        int geraTipoZombie = Random.Range(1, 28);
        transform.GetChild(geraTipoZombie).gameObject.SetActive(true);
    }

    public void Damage(int dano)
    {
        statusInimigo.Vida -= dano;
        if(statusInimigo.Vida <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
        AudioController.instacia.PlayOneShot(deadAudio);
    }
}
