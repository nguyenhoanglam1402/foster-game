using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBubble : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private float distance = 0f;
    [SerializeField]
    private GameObject bubbleMessage;
    [SerializeField]
    private Transform contentBody;
    [SerializeField]
    private GameObject choiceUI;
    [SerializeField]
    private Transform optionsUI;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        choiceUI = GameObject.FindGameObjectWithTag("ChoiceUI");
        optionsUI = choiceUI.transform.Find("Options");
        bubbleMessage = transform.Find("SpeedMessage").gameObject;
        contentBody = bubbleMessage.transform.Find("Content");
        bubbleMessage.transform.Find("Content").gameObject.SetActive(false);
    }

	private void Update()
	{
        distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        bubbleMessage.transform.LookAt(mainCamera.transform.position);
        if (distance <= 5)
		{
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
    }

	private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            contentBody.gameObject.SetActive(true);        
        }
    }

	private void OnTriggerExit(Collider other)
	{
        if (other.tag == "Player")
        {
            contentBody.gameObject.SetActive(false);
        }
    }
}
