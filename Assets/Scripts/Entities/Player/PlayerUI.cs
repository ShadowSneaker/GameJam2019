using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    // Temp healthbard
    public Slider HealthBar;

    public Entity Player;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //HealthBar.value = Player.GetHealth() / Player.MaxHealth;
	}
}
