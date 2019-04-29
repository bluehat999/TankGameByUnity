using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    public float speed = 10;
    public float angularSpeed = 5;
    public int number = 1;
    public AudioClip drivingAudio;
    public AudioClip idleAudio;
    private Rigidbody rigidbody;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxis("player"+number+"v");
        rigidbody.velocity = transform.forward * v * speed;

        float h = Input.GetAxis("player"+number+"h");
        rigidbody.angularVelocity = transform.up * h * angularSpeed;

        if (Mathf.Abs(v) > 0.1 || Mathf.Abs(h) > 0.1)
        {
            audioSource.clip = drivingAudio;
        }
        else
        {
            audioSource.clip = idleAudio;
            
        }
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
