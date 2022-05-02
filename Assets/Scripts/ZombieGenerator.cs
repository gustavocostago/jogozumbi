using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject zombie;
    private float cont = 0;
    public float timeGenerator = 1;
    public LayerMask LayerZumbi;
    private float distanceDeGeracao = 3;
    private float DistanciaDoJogadorParaGeracao = 20;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.transform.position) > DistanciaDoJogadorParaGeracao){
            cont += Time.deltaTime;
            if (cont >= timeGenerator)
            {
                StartCoroutine(GerarNovoZumbi());
                cont = 0;
            }
        }  
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceDeGeracao);
    }
    IEnumerator GerarNovoZumbi()
    {
        Vector3 posicaoDeCriacao = AleatorizarPosicao();
        Collider[] colisores = Physics.OverlapSphere(posicaoDeCriacao, 1,LayerZumbi);
        while(colisores.Length > 0)
        {
            posicaoDeCriacao = AleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);
            yield return null;
        }
        Instantiate(zombie, posicaoDeCriacao, transform.rotation);
    }
    Vector3 AleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * distanceDeGeracao;
        posicao += transform.position;
        posicao.y = 0;
        return posicao;
    }
}
