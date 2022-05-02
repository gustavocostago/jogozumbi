using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public GameObject CanoArma;
    public AudioClip SomTiro;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, CanoArma.transform.position, CanoArma.transform.rotation);
            AudioController.instacia.PlayOneShot(SomTiro);
        }        
    }
}
