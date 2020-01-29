using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private AudioSource audio;

    public static float speed = 4f; // High speed to account for drag along floor
    public  Vector3 moveVelocity; // velocity vectory to determine speed * direction
    public  Rigidbody rb; // Uce rigid body velocity to determine velocity of object

    public ShellBehavior shell;
    public float shotCD = .25f; // cooldown for tank canon
    public float shotTime = 0f;

    public Transform shellSpawn;

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode shoot;

    public ShellBehavior badShell;
    public Vector3 startPos;
    public Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to component
        rb = GetComponent<Rigidbody>();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        if (Input.GetKey(shoot))
        {
            Fire();
        }
        Move(ref moveInput);
       
        moveVelocity = moveInput * speed;

    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
        shotTime -= Time.deltaTime;

    }

    void Fire()
    {
        // Spawn projectile shells on timer
        if (shotTime <= 0)
        {
            shotTime = shotCD;
            ShellBehavior newShell = Instantiate(shell, shellSpawn.position, shellSpawn.rotation);

            audio.Play();
        }
    }

    void Move(ref Vector3 vec)
    {
        if (Input.GetKey(up))
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 180f); // -90f on X because of default rotation - model made in blender and me big dumb
            vec.z = 1f;
        }
        else if (Input.GetKey(down))
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            vec.z = -1f;

        }
        else if (Input.GetKey(left))
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, 90f);
            vec.x = -1f;
        }
        else if (Input.GetKey(right))
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, -90f);
            vec.x = 1f;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shell"))
        {
            Debug.Log(gameObject.name + " hit by enemy player");
            transform.position = startPos;
            transform.rotation = startRotation;
        }
    }
}
