using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class GirouetteController : MonoBehaviour {

    public PlayerIndex player_index;

    // Use this for initialization
    void Start () {
        player_index = (PlayerIndex) 4;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.LogFormat(player_index.ToString());
        GamePadState currentState = GamePad.GetState(player_index);
    }
}
