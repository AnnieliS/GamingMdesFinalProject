using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Troll : GAgent
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    GameObject[] waypointsLocation;
    GameObject player;
    private NavMeshAgent agent;
    bool paused = false;
    GameObject trollGoTo;
    public bool EndGOAP = false;
    bool chasingPlayer = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("TrollEnd", 1, true);
        //Action + Priority - higher is earlier
        goals.Add(s1, 3);
        agent = GetComponent<NavMeshAgent>();
        waypointsLocation = GameObject.FindGameObjectsWithTag("enemyWaypoint");
        trollGoTo = GameObject.FindGameObjectWithTag("trollGoTo");
        animator.SetTrigger("run");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        
        if (!paused)
        {
            StartCoroutine(PauseAgent());
        }

        if(chasingPlayer){
            if(Vector3.Distance(player.transform.position, gameObject.transform.position) < 1.5f){
                GWorld.Instance.GetWorld().ModifyState(WorldTags.gworldStates.trollEnterBattle.ToString(), +2);
            }
        }
    }

    IEnumerator PauseAgent()
    {
        float time = Random.Range(0f, 3f);
        paused = true;
        yield return new WaitForSeconds(time);
        agent.isStopped = true;
        animator.SetTrigger("idle");
        StartCoroutine(ResumeAgent());
    }

    IEnumerator ResumeAgent()
    {
        float time = Random.Range(0f, 1f);
        yield return new WaitForSeconds(time);
        agent.isStopped = false;
        animator.SetTrigger("run");
        paused = false;
    }

    // Update is called once per frame

    public void SetNewWaypoint()
    {

        int i = Random.Range(0, waypointsLocation.Length);
        // agent.SetDestination(waypointsLocation[i].transform.position);
        trollGoTo.transform.position = waypointsLocation[i].transform.position;
        Vector2 agentPlace = new Vector2(transform.position.x, transform.position.z);
        Vector2 newPlace = new Vector2(trollGoTo.transform.position.x, trollGoTo.transform.position.z);
        Debug.Log(agentPlace.magnitude - newPlace.magnitude);
        //TODO: take into account also the players position
        if(agentPlace.magnitude - newPlace.magnitude < 0){
            Debug.Log("flip sprite");
            spriteRenderer.flipX = true;
        }
        else{
            Debug.Log("straight sprite");
            spriteRenderer.flipY = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            GWorld.Instance.GetWorld().ModifyState(WorldTags.gworldStates.trollEnemyinSight.ToString(), +2);
            chasingPlayer = true;
        }}

    public void ChasePlayer(){
        agent.SetDestination(player.transform.position);
    }
    }


