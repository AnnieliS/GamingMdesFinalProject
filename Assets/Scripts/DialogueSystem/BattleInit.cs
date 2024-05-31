using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInit : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    private Animator enemyAnimator;

    private static BattleInit instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Battle Initiator in the scene");
        }
        instance = this;
    }

    public static BattleInit GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        enemyAnimator = enemyObject.GetComponent<Animator>();
        Debug.Log("enemy animator" + enemyAnimator);
    }

    public void InitiateEnemy(GameObject enemy, string newAnimatorName)
    {
        enemyObject = enemy;
        Debug.Log("current tag: " + enemyAnimator.gameObject.tag);
        Debug.Log("new tag: " + enemy.tag);
        // enemyAnimator.gameObject.tag = enemy.tag;
        Debug.Log("RuntimeAnimators/" + newAnimatorName);
        enemyAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("RuntimeAnimators/" + newAnimatorName);

    }

}
