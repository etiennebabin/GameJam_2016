using UnityEngine;
using System.Collections;

public class windScript : MonoBehaviour {

    public GameObject girouette;
    public GameObject char1, char2, char3;
    public float fBlowForce;
    public float wind_multiplier;


    public GameObject wind_particles;

    private Vector3 girouette_direction;
    private Vector3 wind_force;
    private GameObject head1, head2, head3;

    private GameManager game_man;

	// Use this for initialization
	void Start ()
    {
        fBlowForce = 0.0f;
        wind_particles = GameObject.Find("WindParticles");

        head1 = char1.transform.Find("Sphere").gameObject;
        head2 = char2.transform.Find("Sphere").gameObject;
        head3 = char3.transform.Find("Sphere").gameObject;

        game_man = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        girouette_direction = girouette.transform.right;
        wind_force = girouette_direction.normalized * fBlowForce * (wind_multiplier * game_man.timer_duration + 3);

        char1.GetComponent<Rigidbody>().AddForceAtPosition(wind_force, head1.transform.position);
        char2.GetComponent<Rigidbody>().AddForceAtPosition(wind_force, head2.transform.position);
        char3.GetComponent<Rigidbody>().AddForceAtPosition(wind_force, head3.transform.position);
    }

    public void ApplyForce(float p_fBlowForce)
    {
        // wind speed on particules
        if (fBlowForce < p_fBlowForce)
        {
            fBlowForce = p_fBlowForce;
            wind_particles.GetComponent<ParticleSystem>().playbackSpeed += fBlowForce;
        }
        else
        {
            wind_particles.GetComponent<ParticleSystem>().playbackSpeed = wind_particles.GetComponent<ParticleSystem>().playbackSpeed <= 1.0f ? 1.0f : wind_particles.GetComponent<ParticleSystem>().playbackSpeed - 0.15f;
            fBlowForce = p_fBlowForce;
        }

    }
}
