using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    Animation Anim;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        Anim = GetComponent<Animation>();
        Transition("MainMenu");
        //SceneManager.LoadScene("MainMenu");
	}


    private void FixedUpdate()
    {
        if (Input.GetKeyDown("escape"))
        {
            Transition("MainMenu");
        }
    }


    public void Transition(string LevelName)
    {
        StartCoroutine(StartTransition(LevelName));
        Anim.Play();
    }


    public IEnumerator StartTransition(string LevelName)
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(LevelName);
    }
}
