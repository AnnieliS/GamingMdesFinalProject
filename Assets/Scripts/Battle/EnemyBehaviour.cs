using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SelectAnimation(int i){
        if (animator == null)
        return;
        
        switch (i){
            case 1:
            EnemyAttack();
            break;

            case 2:
            EnemyDamaged();
            break;

            case 3:
            EnemyDeath();
            break;

            default:
            break;
        }
    }

    void EnemyAttack(){
        animator.SetTrigger("attack");
    }

    void EnemyDamaged(){
        animator.SetTrigger("damage");
    }

    void EnemyDeath(){
        animator.SetTrigger("death");
    }
}
