﻿using UnityEngine;
using System.Collections;

using XInputDotNetPure;

public class GameManager : MonoBehaviour {

    public GameObject[] players_chars;
    public bool game_started;

    private bool timer_started = false;

    private int nb_players = 0;
    private int nb_active_players = 0;
    public float timer_duration;

    private GUIText countdown_text;

    // Use this for initialization
    void Start () {
        players_chars[0].GetComponent<GirouetteController>().char_activated = false;
        for (int i = 1; i < 4; ++i)
        {
            players_chars[i].GetComponent<CharController>().char_activated = false;
        }

        game_started = false;
        countdown_text = GetComponent<GUIText>();
        countdown_text.text = "Join";
        countdown_text.pixelOffset = new Vector2((Screen.width / 2),(Screen.height / 3));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("You can't exit in debug mode");
        }

        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel("scene");


        if (game_started)
        {
            timer_duration += Time.deltaTime;
            return;
        }

        if (timer_started)
        {
            UpdateTimer();
            return;
        }

        nb_players = 0;
        for (PlayerIndex index = PlayerIndex.One; index <= PlayerIndex.Four; ++index)
        {
            if (GamePad.GetState(index).IsConnected)
                ++nb_players;
        }

        nb_active_players = 0;
        if (players_chars[0].GetComponent<GirouetteController>().char_activated)
            ++nb_active_players;
        for (int i = 1; i < 4; ++i)
        {
            if (players_chars[i].GetComponent<CharController>().char_activated)
                ++nb_active_players;
        }

        /*Debug.Log("nb players :" + nb_players);
        Debug.Log("nb active players :" + nb_active_players);*/

        if (nb_players >= 2 && nb_players == nb_active_players)
        {
            StartTimer();
        }
	
	}

    void StartGame()
    {
        game_started = true;
        Debug.Log("Start game!");
    }


    void StartTimer()
    {
        timer_started = true;
        timer_duration = 3.0f;
    }
    void UpdateTimer()
    {
        timer_duration -= Time.deltaTime;
        //Debug.Log(timer_duration);

        string text = Mathf.Round(timer_duration).ToString();

        if (text != "0")
            countdown_text.text = text;
        else
            countdown_text.text = "";

        if (timer_duration < 0)
        {
            timer_started = false;
            StartGame();
        }
    }
}
