using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : CharacterMoviment
{
    public void MovePlayer(LayerMask floorMask)
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);
        RaycastHit impact;
        if (Physics.Raycast(raio, out impact, 100, floorMask))
        {
            Vector3 aimPosition = impact.point - transform.position;
            aimPosition.y = transform.position.y;
            Rotacionar(aimPosition);
        }
    } 
}
