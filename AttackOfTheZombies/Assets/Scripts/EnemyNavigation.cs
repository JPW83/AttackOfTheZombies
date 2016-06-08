using UnityEngine;
using System.Collections;

public class EnemyNavigation : MonoBehaviour {
    public Vector3 targetPosition;
    public GameObject target;
    public NavMeshAgent myAgent;
	// Use this for initialization
	void Start ()
    {
        myAgent = GetComponent<NavMeshAgent>();
        targetPosition = target.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        myAgent.SetDestination(targetPosition);
	}



}
