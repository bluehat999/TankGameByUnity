using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool roundOver = false;
    public GameObject tankPrefab;
    public GameObject mainCamera;
    public Material material2;
    private bool restart = false;
    private Rect rect1;
    private Rect rect2;
    private GameObject tank1;
    private GameObject tank2;
    private bool cameraActive = false;

    // Start is called before the first frame update
    void Start()
    {
        rect1 = new Rect(0,0,0.5f,1);
        rect2 = new Rect(0.5f, 0, 0.5f, 1);
        tank1 = CreateTank("tank1", 1, rect1);
        tank2 = CreateTank("tank2", 2, rect2);
    }

    // Update is called once per frame
    void Update()
    {
        if(restart || roundOver && Input.GetKeyDown(KeyCode.L))
        {
            nextRound();
        }
        if (roundOver && !cameraActive)
        {
            mainCamera.SetActive(true);
            cameraActive = true;
        }
        

    }
    public void RestartPress()
    {
        this.restart = true;
    }
    protected void nextRound()
    {
        /*
         * GameObject.Destroy(tank1);
        GameObject.Destroy(tank2);
        tank1 = CreateTank("tank1", 1, rect1);
        tank2 = CreateTank("tank2", 2, rect2);
        */
        tank1.transform.position = new Vector3(Random.Range(-40, 40), 0.127f, Random.Range(-40, 40));
        tank2.transform.position = new Vector3(Random.Range(-40, 40), 0.127f, Random.Range(-40, 40));
        tank1.transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360), 0f));
        tank2.transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 360), 0f));
        tank1.GetComponent<TankHealth>().initHealth();
        tank2.GetComponent<TankHealth>().initHealth();
        tank1.SetActive(true);
        tank2.SetActive(true);
        mainCamera.SetActive(false);
        cameraActive = false;
        this.roundOver = false;
        this.restart = false;
    }
    protected GameObject CreateTank(string name,int number,Rect viewPort,int hptotal=100,float speed=6)
    {
        GameObject tank = GameObject.Instantiate(tankPrefab,
            new Vector3(Random.Range(-40, 40), 0.127f, Random.Range(-40, 40)),
            Quaternion.Euler(new Vector3(0f, Random.Range(0, 360), 0f)));
        tank.name = name;
        tank.GetComponent<TankMove>().number = number;
        GameObject.Find(name+"/CameraTank").GetComponent<Camera>().rect = viewPort;
        tank.GetComponent<TankMove>().speed = speed;
        if (number == 2)
        {
            tank.GetComponent<TankAttack>().FireKey = KeyCode.Return;
            GameObject.Find(name + "/TankRenderers/TankChassis").GetComponent<MeshRenderer>().material= material2;
            GameObject.Find(name + "/TankRenderers/TankTracksLeft").GetComponent<MeshRenderer>().material = material2;
            GameObject.Find(name + "/TankRenderers/TankTracksRight").GetComponent<MeshRenderer>().material = material2;
            GameObject.Find(name + "/TankRenderers/TankTurret").GetComponent<MeshRenderer>().material = material2;
        }
        if (hptotal != 100)
        {
            tank.GetComponent<TankHealth>().hpTotal = hptotal;
        }
        return tank;
    }

}
