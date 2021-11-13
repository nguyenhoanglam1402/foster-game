using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string targetTag = "";
    [SerializeField]
    private int destinationScene = 1;
	// Start is called before the first frame update

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == targetTag)
		{
			SceneManager.LoadScene(destinationScene);
		}
	}
}
