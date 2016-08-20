using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class CharController : MonoBehaviour {

    public PlayerIndex player_index;
    public GameObject char_light;

    private bool char_activated = false;
    private Rigidbody body;
    private Light char_spotlight;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;

        char_spotlight = char_light.GetComponent<Light>();
        char_spotlight.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        GamePadState currentState = GamePad.GetState(player_index);

        if (char_activated)
        {
            // inti dsgsdfgsfasfasdf
        }
        else
        {
            if (currentState.Buttons.A == ButtonState.Pressed)
            {
                char_activated = true;
                body.isKinematic = false;
                char_spotlight.enabled = true;
            }
        }
		
		//Debug.Log (.ToString());

    }
}
