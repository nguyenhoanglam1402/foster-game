using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBubble : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;
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
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        choiceUI = GameObject.FindGameObjectWithTag("ChoiceUI");
        optionsUI = choiceUI.transform.Find("Options");
        bubbleMessage = GameObject.FindGameObjectWithTag("BubbleMessage");
        contentBody = bubbleMessage.transform.Find("Content");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        distance = Vector3.Distance(transform.position, camera.transform.position);
        
        if (distance <= 5)
		{
            contentBody.gameObject.SetActive(true);
            optionsUI.gameObject.SetActive(true);
            transform.LookAt(camera.transform.position);
        }
        else
		{
            contentBody.gameObject.SetActive(false);
            optionsUI.gameObject.SetActive(false);
            transform.LookAt(camera.transform.position);
        }
    }
}
