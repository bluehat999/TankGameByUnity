using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    protected GameObject player1;
    protected GameObject player2;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("tank1");
        player2 = GameObject.Find("tank2");
    }

    // Update is called once per frame
    void Update()
    {
        if(!player1)
        {
            player1 = GameObject.Find("tank1");
        }
        if (!player2)
        {
            player2 = GameObject.Find("tank2");
        }
        if (player1.activeSelf)
        {
            transform.position = player1.transform.position + this.offset;
        }
        else
        {
            transform.position = player2.transform.position + this.offset;
        }
    }
}
/*
public class FollowTarget : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private Vector3 offset;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - (player1.position + player2.position) / 2;
        camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player1.position, player2.position);
        float size = 1.5f * distance;
        if (size > 90)
        {
            camera.fieldOfView = 90;
            transform.position = new Vector3(0, offset.y, 0);
        }
        else
        {
            camera.fieldOfView = size;
            transform.position = (player1.position + player2.position) / 2 + offset;
        }

    }
}*/