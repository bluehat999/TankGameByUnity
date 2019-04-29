using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellBang : MonoBehaviour
{
    public GameObject ShellExplosionPrefab;
    public AudioClip shotCharginigAudio;
    public AudioClip shellExplosionAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);
        GameObject.Instantiate(ShellExplosionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
        if (other.tag == "Player")
        {
            other.SendMessage("TakeDamage");
            AudioSource.PlayClipAtPoint(shotCharginigAudio, transform.position);
        }
    }
}
