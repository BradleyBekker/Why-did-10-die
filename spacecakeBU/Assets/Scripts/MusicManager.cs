﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public GameObject rocketPlayer1;
	public GameObject rocketPlayer2;


	public GameObject theme1;
	//private AudioSource source1;
	public bool source1Finished = false;

	public GameObject theme2;
	//private AudioSource source2;
	public bool source2Finished = false;

	public GameObject theme3;
	//private AudioSource source3;
	public bool source3Finished = false;

	public bool transDefaultRunning;
	public bool trans1Running;
	public bool trans2Running;

	public float volumeAdjustmentPerFrame;

	// Update is called once per frame
	void Update () {
		checkParts();

		if(transDefaultRunning) {
			transitionDefault();
		}
		if(trans1Running) {
			transition1();
		}
		if(trans2Running) {
			transition2();
		}
	}

	private void checkParts()
	{
		int player1Parts= 0;
		int player2Parts= 0;

		if(rocketPlayer1.GetComponent<P1rocket>().part1) {
			player1Parts++;
		}
		if(rocketPlayer1.GetComponent<P1rocket>().part2) {
			player1Parts++;
		}
		if(rocketPlayer1.GetComponent<P1rocket>().part3) {
			player1Parts++;
		}
		if(rocketPlayer1.GetComponent<P1rocket>().part4) {
			player1Parts++;
		}
		if(rocketPlayer1.GetComponent<P1rocket>().part5) {
			player1Parts++;
		}

		if(rocketPlayer2.GetComponent<P2rocket>().part1) {
			player2Parts++;
		}
		if(rocketPlayer2.GetComponent<P2rocket>().part2) {
			player2Parts++;
		}
		if(rocketPlayer2.GetComponent<P2rocket>().part3) {
			player2Parts++;
		}
		if(rocketPlayer2.GetComponent<P2rocket>().part4) {
			player2Parts++;
		}
		if(rocketPlayer2.GetComponent<P2rocket>().part5) {
			player2Parts++;
		}

		int finalValue;
		if(player1Parts > player2Parts && player1Parts != player2Parts) finalValue = player1Parts;
		else finalValue = player2Parts;

		if(finalValue < 3 && !transDefaultRunning)
		{
			transDefaultRunning = true;
			trans1Running = false;
			trans2Running = false;
		}
		else if(finalValue >= 3 && finalValue < 5 && !trans1Running)
		{
			trans1Running = true;
			transDefaultRunning = false;
			trans2Running = false;
		}
		else if(finalValue == 5 && !trans2Running)
		{
			trans2Running = true;
			transDefaultRunning = false;
			trans1Running = false;
		}
	}

	// change themesong back to default
	public void transitionDefault()
	{
		if(theme1.GetComponent<AudioSource>().volume <= 1 && !source1Finished) {
			if(theme1.GetComponent<AudioSource>().volume + volumeAdjustmentPerFrame >= 1) {
				theme1.GetComponent<AudioSource>().volume = 1;
				source1Finished = true;
			}
			else theme1.GetComponent<AudioSource>().volume += volumeAdjustmentPerFrame;
		}

		if(theme2.GetComponent<AudioSource>().volume >= 0 && !source2Finished) {
			if(theme2.GetComponent<AudioSource>().volume - volumeAdjustmentPerFrame <= 0) {
				theme2.GetComponent<AudioSource>().volume = 0;
				source2Finished = true;
			}
			else theme2.GetComponent<AudioSource>().volume -= volumeAdjustmentPerFrame;
		}

		if(theme3.GetComponent<AudioSource>().volume >= 0 && !source3Finished) {
			if(theme3.GetComponent<AudioSource>().volume - volumeAdjustmentPerFrame <= 0) {
				theme3.GetComponent<AudioSource>().volume = 0;
				source3Finished = true;
			}
			else theme3.GetComponent<AudioSource>().volume -= volumeAdjustmentPerFrame;
		}

		if(source1Finished && source2Finished && source3Finished) {
			transDefaultRunning = false;
			trans2Running = false;
			source1Finished = false;
			source2Finished = false;
			source3Finished = false;
		}
	}

	// change themesong to 2nd fase
	public void transition1()
	{
		if(theme1.GetComponent<AudioSource>().volume >= 0 && !source1Finished) {
			if(theme1.GetComponent<AudioSource>().volume - volumeAdjustmentPerFrame <= 0) {
				theme1.GetComponent<AudioSource>().volume = 0;
				source1Finished = true;
			}
			else theme1.GetComponent<AudioSource>().volume -= volumeAdjustmentPerFrame;
		}

		if(theme2.GetComponent<AudioSource>().volume <= 1 && !source2Finished) {
			if(theme2.GetComponent<AudioSource>().volume + volumeAdjustmentPerFrame >= 1) {
				theme2.GetComponent<AudioSource>().volume = 1;
				source2Finished = true;
			}
			else {
				theme2.GetComponent<AudioSource>().volume += volumeAdjustmentPerFrame;
			}
		}

		if(theme3.GetComponent<AudioSource>().volume >= 0 && !source3Finished) {
			if(theme3.GetComponent<AudioSource>().volume - volumeAdjustmentPerFrame <= 0) {
				theme3.GetComponent<AudioSource>().volume = 0;
				source3Finished = true;
			}
			else theme3.GetComponent<AudioSource>().volume -= volumeAdjustmentPerFrame;
		}

		if(source1Finished && source2Finished && source3Finished) {
			transDefaultRunning = false;
			trans1Running = false;
			source1Finished = false;
			source2Finished = false;
			source3Finished = false;
		}
	}

	// change themesong to final fase
	public void transition2()
	{
		if(theme1.GetComponent<AudioSource>().volume >= 0 && !source1Finished) {
			if(theme1.GetComponent<AudioSource>().volume - volumeAdjustmentPerFrame <= 0) {
				theme1.GetComponent<AudioSource>().volume = 0;
				source1Finished = true;
			}
			else theme1.GetComponent<AudioSource>().volume -= volumeAdjustmentPerFrame;
		}

		if(theme2.GetComponent<AudioSource>().volume >= 0 && !source2Finished) {
			if(theme2.GetComponent<AudioSource>().volume - volumeAdjustmentPerFrame <= 0) {
				theme2.GetComponent<AudioSource>().volume = 0;
				source2Finished = true;
			}
			else theme2.GetComponent<AudioSource>().volume -= volumeAdjustmentPerFrame;
		}

		if(theme3.GetComponent<AudioSource>().volume <= 1 && !source3Finished) {
			if(theme3.GetComponent<AudioSource>().volume + volumeAdjustmentPerFrame >= 1) {
				theme3.GetComponent<AudioSource>().volume = 1;
				source3Finished = true;
			}
			else theme3.GetComponent<AudioSource>().volume += volumeAdjustmentPerFrame;
		}

		if(source1Finished && source2Finished && source3Finished) {
			trans1Running = false;
			trans2Running = false;
			source1Finished = false;
			source2Finished = false;
			source3Finished = false;
		}
	}

}
