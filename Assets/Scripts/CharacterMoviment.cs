using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoviment : MonoBehaviour
{
    private Rigidbody rg;
    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }
    public void Moviment(Vector3 direcao, float speed)
    {
        rg.MovePosition(rg.position + direcao.normalized * Time.deltaTime * speed);
    }
    public void Rotacionar(Vector3 direcao)
    {
        Quaternion newRotate = Quaternion.LookRotation(direcao);
        rg.MoveRotation(newRotate);
    }
}
