using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBehavior : MonoBehaviour
{
    //speed of shell
    public float speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed);
    }

    void OnCollisionEnter(Collision other)
    {

        Destroy(gameObject);
    }
}
