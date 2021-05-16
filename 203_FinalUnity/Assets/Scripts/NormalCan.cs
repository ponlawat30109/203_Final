using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCan : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject, 1f);
        }
    }
}
