using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class GirouetteController : MonoBehaviour {

    public PlayerIndex player_index;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        GamePadState currentState = GamePad.GetState(player_index);
    }
}
