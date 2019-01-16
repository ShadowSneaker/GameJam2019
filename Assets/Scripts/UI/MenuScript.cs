using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string PlayScene;
    private TransitionScript Transition;

	// Use this for initialization
	void Start ()
    {
        Transition = FindObjectOfType<TransitionScript>();
        if (!Transition)
        {
            Debug.Log("Warning, Couldn't find Transition Script!");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		

	}


    public void Play()
    {
        if (Transition)
        {
            Transition.Transition(PlayScene);
        }
    }


    public void Quit()
    {
        Application.Quit();
    }
}
