using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    public GameObject ShellPrefab;
    public float ShellSpeed = 20;

    public KeyCode FireKey = KeyCode.Space;
    public AudioClip fireAudio;
    private Transform firePosition;

    // Start is called before the first frame update
    void Start()
    {
        firePosition = transform.Find("FirePosition");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(FireKey))
        {
            AudioSource.PlayClipAtPoint(fireAudio, transform.position);
            GameObject go = GameObject.Instantiate(ShellPrefab, firePosition.position, firePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * ShellSpeed;
        }
        
    }
}
