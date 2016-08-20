using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class CharController : MonoBehaviour {

    public PlayerIndex player_index;
    public GameObject char_light;

    public bool char_activated;
    private Rigidbody body;
    private Light char_spotlight;
    private GameObject head;

    private GameManager game_man;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody>();
        body.isKinematic = true;

        char_spotlight = char_light.GetComponent<Light>();
        char_spotlight.enabled = false;

        head = this.transform.Find("Sphere").gameObject;
        game_man = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        GamePadState currentState = GamePad.GetState(player_index);

        if (char_activated && game_man.game_started)
        {

            body.isKinematic = false;

            Vector3 stick_force = new Vector3(-5 * currentState.ThumbSticks.Left.X, 0.0f, -4 * currentState.ThumbSticks.Left.Y);
            body.AddForceAtPosition(stick_force, head.transform.position);

            if(Vector3.Dot(this.transform.up, new Vector3(0.0f, 1.0f, 0.0f)) < 0.2f)
            {
                SpringJoint[] springJoints = GetComponents<SpringJoint>();
                foreach (SpringJoint joint in springJoints)
                {
                    Destroy(joint);
                    char_activated = false;
                }
            }


        }
        else
        {
            if (currentState.Buttons.A == ButtonState.Pressed)
            {
                char_activated = true;
                char_spotlight.enabled = true;
                // remove "A" icon
            }
        }
		
		//Debug.Log (.ToString());

    }
}
