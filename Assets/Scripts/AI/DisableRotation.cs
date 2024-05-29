using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRotation : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
    // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Check if the Rigidbody2D component is found
        if (rb != null)
        {
            // Freeze the rotation of the Rigidbody2D
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
