using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.Windows.Speech;

public class ChoiceSystem : MonoBehaviour
{
    [Header("Ink Script Source")]
    private Story story;
    [SerializeField]
    private TextAsset script;
    [Header("UI System")]
    private GameObject optionsUI;
    private Animator npcAnimator;
    [SerializeField]
    private GameObject choiceButtonPrefab;
    [SerializeField]
    private GameObject messagePanel;
    private TextMeshProUGUI textMessage;
    [SerializeField]
    private GameObject dialogUIPrefab;
    private GameObject dialogUI;
    [SerializeField]
    private GameObject pickButton;
    [Header("Audio System")]
    [SerializeField]
    private AudioClip[] audioList;
    private AudioSource audioSource;
    [Header("Logic System")]
    [SerializeField]
    private bool isMine = false;
    [Header("Personal of NPC Properties")]
    [SerializeField]
    private string fullname = "";
    [SerializeField]
    private string jobTitle = "";

    // Start is called before the first frame update
    void Start()
    {
        optionsUI = GameObject.FindGameObjectWithTag("Options");
        npcAnimator = transform.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        messagePanel = GameObject.FindGameObjectWithTag("MessagePanel");
        story = new Story(script.text);
        ContinueStory();
    }

	// Update is called once per frame
	void ContinueStory()
    {
        if (story.canContinue && isMine)
        {
            string respond = story.Continue();
            TextMeshProUGUI npcName = dialogUI.transform.Find("NPCName").GetComponent<TextMeshProUGUI>();

            if (respond.Split('-').Length == 2)
            {
                int index = 0;
                int indexAnimation = 0;
				if (int.TryParse(respond.Split('-')[0], out index) == true)
				{
                    textMessage.text = respond.Split('-')[1];
                    audioSource.PlayOneShot(audioList[index]);
                    animationController(0);
                }
				else if (int.TryParse(respond.Split('-')[1], out indexAnimation) == true)
				{
                    textMessage.text = respond.Split('-')[0];
                    animationController(indexAnimation);
                }
            }
            else if (respond.Split('-').Length == 3)
			{
                int index = int.Parse(respond.Split('-')[0]);
                int indexAnimation = int.Parse(respond.Split('-')[2]);
                textMessage.text = respond.Split('-')[1];
                audioSource.PlayOneShot(audioList[index]);
                animationController(indexAnimation);
            }
			else
			{
                textMessage.text = respond;
                animationController(0);
            }
            
            Debug.Log("Debug: " + story.canContinue + " | Story length: "+ respond.Split('-').Length);
            Debug.Log("Respond:[" + respond + "]");
        }
        RefreshChoice();
    }

    void RefreshChoice()
	{
        clearUI();
        foreach (Choice choice in story.currentChoices)
        {
            GameObject buttonObject = Instantiate(choiceButtonPrefab, optionsUI.transform);
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
            ContinueStory();
        }
	}

    void animationController(int indexAnimation)
	{
        switch (indexAnimation)
        {
            case 0:
                npcAnimator.SetTrigger("Yes");
                break;
            case 1:
                npcAnimator.SetTrigger("No");
                break;
            case 2:
                npcAnimator.SetTrigger("Loose");
                break;
            case 3:
                npcAnimator.SetTrigger("Shrug");
                break;
            case 4:
                npcAnimator.SetTrigger("Wave");
                break;
            case 5:
                npcAnimator.SetTrigger("Win");
                break;
            case 6:
                npcAnimator.SetTrigger("Dance");
                break;
            default:
                break;
        }
    }

    void ShowDialogUI () {
        dialogUI = Instantiate(dialogUIPrefab, messagePanel.transform);
        textMessage = dialogUI.transform.Find("Message").GetComponent<TextMeshProUGUI>();
        dialogUI.transform.Find("NPCName").GetComponent<TextMeshProUGUI>().text = fullname;
        dialogUI.transform.Find("NPCJobTitle").GetComponent<TextMeshProUGUI>().text = jobTitle;
        ContinueStory();
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
            isMine = true;
            GameObject button = Instantiate(pickButton, optionsUI.transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Talk with " + fullname;
            button.GetComponent<Button>().onClick.AddListener(()=> {
                ShowDialogUI();
                Destroy(button.gameObject);
            });
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
            isMine = false;
            clearUI();
            Debug.Log("Hi I'm out!");
            story.ResetState();
            Destroy(dialogUI);
        }
	}
}
