using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class GameManager : MonoBehaviour {

    private PlayerIndex player_index;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    PlayerIndex GetPlayerIndex()
    {
        return player_index;
    }

    void SetPlayerIndex(PlayerIndex p_PlayerIndex)
    {
        player_index = p_PlayerIndex;
    }
}
