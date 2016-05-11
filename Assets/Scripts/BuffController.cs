using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuffController : MonoBehaviour {
    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Speed Up")
        {
            
        }
        if (other.gameObject.tag == "Speed Down")
        {
            
        }
    }
}
