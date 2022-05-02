using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersAnimation : MonoBehaviour
{
    private Animator myAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    public void Attack(bool bee)
    {
        myAnimator.SetBool("Attack", bee);
    }
    public void AnimMove(float value)
    {
        myAnimator.SetFloat("Move", value);
    }
}
