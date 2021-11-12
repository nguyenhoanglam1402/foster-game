using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerBackground : MonoBehaviour
{
	[SerializeField]
	private AudioSource AudioSource;

    [SerializeField]
    private AudioClip Soundtrack;

    [SerializeField]
    private string ObjectName;

	[SerializeField]
	private string AreaName;

	[SerializeField]
	private string Subtitle;

	[SerializeField]
	private Animator UITileAnimator;

	[SerializeField]
	private Text NameAreaUI;


	[SerializeField]
	private Text SubtitleAreaUI;

	[SerializeField]
	private bool isOnce = false;

	private void Start()
	{
		AudioSource = GetComponent<AudioSource>();
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == ObjectName)
		{
			AudioSource.PlayOneShot(Soundtrack);
			UITileAnimator.SetTrigger("isTrigger");
			NameAreaUI.text = AreaName;
			SubtitleAreaUI.text = Subtitle;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == ObjectName)
		{
			AudioSource.Stop();
		}
	}
}
