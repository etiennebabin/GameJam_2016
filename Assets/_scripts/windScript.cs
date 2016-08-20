using UnityEngine;
using System.Collections;

public class windScript : MonoBehaviour {

    public Vector3 wind_force;
    public GameObject char1, char2, char3;

    private GameObject head1, head2, head3;

	// Use this for initialization
	void Start ()
    {
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
}
