using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour 
{
	public Text textVelocity;
	public Text textPosition;
	public Text textLap;
	public GameObject gameOver;

	public Auto playerAuto;
	public Racer playerRacer;

	public static UiManager singleton;

	// Use this for initialization
	void Start () {
		if (singleton != null) {
			Destroy (this);
			return;
		}
		singleton = this;

	}
	
	// Update is called once per frame
	void Update () 
	{
		textVelocity.text = (int)playerAuto.currentSpeed + "MPH";
		textLap.text = "LAP: "  + (int)playerRacer.Lap + "/" + (int)LapManager.singleton.Laps;

	}

	public void UpdatePosition(int position, int length)
	{
		textPosition.text = "POS:" + (int)position + "/" + (int)length;
	}

	public void ActivateGameOver(){
		gameOver.SetActive (true);
	}
}
