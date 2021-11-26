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

    // Start is called before the first frame update
    void Start()
    {

    }

	// Update is called once per frame
	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Endpoint")
		{
			
		}
	}
}
