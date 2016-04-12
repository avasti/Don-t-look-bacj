using UnityEngine;
using System.Collections;

public class DestroyPlatforms : MonoBehaviour {

    public float forceAmount = 1000f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "valla")
        {
            rb.AddForce(-transform.forward*forceAmount, ForceMode.Acceleration);
            rb.useGravity = true;
        }
    }
}
