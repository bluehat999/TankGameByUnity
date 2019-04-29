using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    private bool floatTop = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (floatTop)
        {
            this.transform.position -= new Vector3(0, Mathf.Lerp(0.002f,0.01f,0.5f), 0);
            if (this.transform.position.y - 0.2 < 0.01)
            {
                floatTop = false;
            }
            //Debug.Log("floating down: " + this.transform.position);
        }
        else
        {
            this.transform.position += new Vector3(0, Mathf.Lerp(0.002f, 0.01f, 0.5f), 0);
            if (1.0 - this.transform.position.y < 0.01)
            {
                floatTop = true;
            }
            //Debug.Log("floating up: " + this.transform.position);
        }
    }
}
