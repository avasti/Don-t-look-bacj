using UnityEngine;
using System.Collections;

public class DestroyPlatforms : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "valla")
        {
            Destroy(col.gameObject);
        }
    }
}
