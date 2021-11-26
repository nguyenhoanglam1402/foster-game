using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class ChoiceSystem : MonoBehaviour
{
    [Header("Inker Script Source")]
    [SerializeField]
    private Story story;
    [SerializeField]
    private TextAsset textAsset;
    [SerializeField]
    private GameObject TextMessage;
    [SerializeField]
    private GameObject optionsUI;
    [SerializeField]
    private Animator npcAnimator;
    [SerializeField]
    private bool isMine;
    [SerializeField]
    private GameObject choiceButton;
    [SerializeField]
    private AudioClip[] audioList;

    // Start is called before the first frame update
    void Start()
    {
        optionsUI = GameObject.FindGameObjectWithTag("Options");
        npcAnimator = transform.GetComponent<Animator>();
        story = new Story(textAsset.text);
        ContinueStory();
    }

    // Update is called once per frame
    void ContinueStory()
    {
        if (story.canContinue && isMine)
        {
            TextMessage.GetComponent<TextMeshPro>().text = story.Continue();
            Debug.Log(story.canContinue);
        }
        RefreshChoice();
    }

    void RefreshChoice()
	{
        clearUI();
        foreach (Choice choice in story.currentChoices)
        {
            GameObject buttonObject = Instantiate(choiceButton, optionsUI.transform);
            buttonObject.GetComponentInChildren<Text>().text = choice.text;
            Button buttonComponent = buttonObject.GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => ChooseAnswer(choice.index));
            Debug.Log(choice.text);
        }
    }

    void clearUI() 
    {
        for (int index = 0; index < optionsUI.transform.childCount; index ++)
		{
            Destroy(optionsUI.transform.GetChild(index).gameObject);
            Debug.Log("Delete");
		}
    }

    void ChooseAnswer(int index)
	{
		if (isMine)
		{
            Debug.Log("Click on " + index);
            story.ChooseChoiceIndex(index);
            npcAnimator.SetTrigger("Conversation");
            ContinueStory();
        }
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
            isMine = true;
            ContinueStory();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
            isMine = false;
            clearUI();
            Debug.Log("Hi I'm out!");
		}
	}
}
