﻿using UnityEngine;
using System.Collections;

public class windScript : MonoBehaviour {

    public Vector3 wind_force;
    public GameObject char1, char2, char3;
    public float fBlowForce;

    public GameObject wind_particles;

    private GameObject head1, head2, head3;

	// Use this for initialization
	void Start ()
    {
        fBlowForce = 0.0f;
        wind_particles = GameObject.Find("WindParticles");

        head1 = char1.transform.Find("Sphere").gameObject;
        head2 = char2.transform.Find("Sphere").gameObject;
        head3 = char3.transform.Find("Sphere").gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
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
            wind_particles.GetComponent<ParticleSystem>().playbackSpeed = wind_particles.GetComponent<ParticleSystem>().playbackSpeed <= 1.0f ? 1.0f : wind_particles.GetComponent<ParticleSystem>().playbackSpeed - 0.2f;
            fBlowForce = p_fBlowForce;
        }
    }
}
