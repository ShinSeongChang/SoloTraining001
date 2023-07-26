using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource getCoin = default;

    public float rotateSpeed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        getCoin = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            getCoin.Play();
            gameObject.SetActive(false);

        }
    }
}
