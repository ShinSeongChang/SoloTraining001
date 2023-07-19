using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherBall : MonoBehaviour
{    
    MeshRenderer mesh = default;
    Material material = default;

    // Start is called before the first frame update
    public void Start()
    {      
       mesh = GetComponent<MeshRenderer>();
        material = mesh.material;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
            material.color = new Color(0f, 0f, 0f);
        }

    }

}
