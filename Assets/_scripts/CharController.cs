using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class CharController : MonoBehaviour {

    public PlayerIndex player_index;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		GamePadState currentState = GamePad.GetState(player_index);
		Debug.Log (currentState.Buttons.A.ToString());
        /*currentState = GamePad.GetState(PlayerIndex.Two);
        Debug.Log(currentState);
        currentState = GamePad.GetState(PlayerIndex.Three);
        Debug.Log(currentState);
        currentState = GamePad.GetState(PlayerIndex.Four);
        Debug.Log(currentState);*/
    }
}
