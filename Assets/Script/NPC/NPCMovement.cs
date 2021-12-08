using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
	[SerializeField]
	private NavMeshAgent navMeshAgent;
	[SerializeField]
	private GameObject [] endpoints;
	[SerializeField]
	private bool isStay = false;
	[SerializeField]
	private string targetTag = "";
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private float runSpeedAnimation = 1f;

	System.Random random = new System.Random();

	// Start is called before the first frame update
	void Start()
    {
		navMeshAgent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		endpoints = GameObject.FindGameObjectsWithTag(targetTag);
		int index = random.Next(endpoints.Length - 1);
		Debug.Log("Index: " + index);
		navMeshAgent.SetDestination(endpoints[index].transform.position);
	}

	private void Update()
	{
		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance || Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 2 )
		{
			animator.SetFloat("MoveSpeed", 0f);
		}
		else
		{
			animator.SetFloat("MoveSpeed", runSpeedAnimation);
		}
	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.tag);
		
		if(other.tag == targetTag && navMeshAgent.remainingDistance <= (navMeshAgent.stoppingDistance + 2))
		{
			Invoke("waitForWhile", random.Next(5, 10));
		} else if (other.tag == "Player")
		{
			transform.LookAt(other.transform.position);
			navMeshAgent.isStopped = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			navMeshAgent.isStopped = false;
		}
	}

	void waitForWhile()
	{
		float[] animationSpeed = new float[] { 0.5f, 1f };
		int index = random.Next(endpoints.Length - 1);
		Debug.Log("Index: " + index);
		runSpeedAnimation = animationSpeed[random.Next(0, 1)];
		Debug.Log("Run Speed: " + runSpeedAnimation);
		if (runSpeedAnimation == 0.5f)
		{
			navMeshAgent.speed = 1;
		}
		else
		{
			navMeshAgent.speed = 2.2f;
		}
		navMeshAgent.SetDestination(endpoints[index].transform.position);
	}
}
