using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) 
    {
        Destroy(collision.gameObject);
    }
}
