using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject player;
    private bool MoveLeft = true;
    private bool autoRotate = false;
    private int auto = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveLeft)
        {
            this.transform.position -= new Vector3(Mathf.Lerp(0.05f, 0.08f, 0.5f),0, 0);
            if (this.transform.position.x +30 < 1)
            {
                MoveLeft = false;
                autoRotate = true;
                auto = 0;
            }
            //Debug.Log("floating down: " + this.transform.position);
        }
        else
        {
            this.transform.position += new Vector3(Mathf.Lerp(0.05f, 0.08f, 0.5f),0, 0);
            if (0 - this.transform.position.x < 1)
            {
                MoveLeft = true;
                autoRotate = true;
                auto = 0;
            }
            //Debug.Log("floating up: " + this.transform.position);
        }
        if (autoRotate)
        {
            if (auto < 180/3)
            {
                this.transform.Rotate(new Vector3(0, 3, 0));
                auto += 1;
            }
            else
            {
                this.transform.Rotate(new Vector3(0, 3, 0));
                auto += 1;
                autoRotate = false;
            }
            /*this.transform.Rotate(Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 10, 0), 0.3f));
            Debug.Log(lastOrientation.eulerAngles.y+","+ this.transform.rotation.eulerAngles.y);
            if (Mathf.Abs((lastOrientation.eulerAngles.y - this.transform.rotation.eulerAngles.y) - 90 )< 2)
            {
                autoRotate = false;
                lastOrientation = this.transform.rotation;
            }*/
        }
    }
}
