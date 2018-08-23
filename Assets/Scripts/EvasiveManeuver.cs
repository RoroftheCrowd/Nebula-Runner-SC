using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

    public float dodge;
    public float smoothing;
    public Vector2 startWait;
    public Vector2 manueverTime;
    public Vector2 manueverWait;
    public Boundary boundary;

    private float currentSpeed;
    private float targetManeuver;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range (1, dodge) * (transform.position.x);
            yield return new WaitForSeconds (Random.Range (manueverTime.x ,manueverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(manueverWait.x, manueverWait.y));
        }
    }
	
	void FixedUpdate ()
    {
        float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
        
	}
}
