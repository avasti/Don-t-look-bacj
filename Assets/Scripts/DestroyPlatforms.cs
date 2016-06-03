using UnityEngine;
using System.Collections;

public class DestroyPlatforms : MonoBehaviour {

    public float forceAmount = 1000f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Platform")
        {
            rb.AddForce(-transform.forward*forceAmount, ForceMode.Acceleration);
            rb.useGravity = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Platform" || col.gameObject.tag == "Speed Down" || col.gameObject.tag == "Speed Up")
        {
            Destroy(col.gameObject);
        }
    }
}
