using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rg;
    public GameObject player;
    public AudioClip deadAudio;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        rg = GetComponent<Rigidbody>();
        rg.MovePosition(rg.position + transform.forward * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider objectCollider)
    {   
        if(objectCollider.tag == "Enemy")
        {
            player.GetComponent<PlayerController>().Verifica(true);
            objectCollider.GetComponent<EnemyController>().Damage(1); 
        }
        Destroy(gameObject);
    }
}
