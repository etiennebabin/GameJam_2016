using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class GirouetteController : MonoBehaviour {

    public PlayerIndex player_index;
    public GameObject wind_particles;
    private windScript wind_script;

    public bool char_activated;

    // Use this for initialization
    void Start () {
        wind_particles = GameObject.Find("WindParticles");
        wind_script = GetComponent<windScript>();
    }
	
	// Update is called once per frame
	void Update () {
        // rotate girouette and wind
        if(char_activated)
        {
            GamePadState currentState = GamePad.GetState(player_index);
            this.transform.Rotate(new Vector3(0, -5 * currentState.ThumbSticks.Left.X, 0));
            wind_particles.GetComponent<Transform>().transform.RotateAround(Vector3.zero, Vector3.up, -5 * currentState.ThumbSticks.Left.X);
        }
        // modify speed of wind by using the micro
        wind_script.ApplyForce(MicInput.MicLoudness);

        if (!char_activated && GamePad.GetState(player_index).Buttons.A == ButtonState.Pressed)
        {
            char_activated = true;
            transform.Find("button_A").GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
