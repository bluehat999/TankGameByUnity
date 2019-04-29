using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    private int hp;
    public int hpTotal = 100;
    public GameObject TankExplosion;
    public AudioClip tankExplotionAudio;
    public AudioClip roundOverAudio;
    public Slider slider;
    public GameObject scoreManager;
    private GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        hp = hpTotal;
        slider.value = 1;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage()
    {
        if (hp <= 0) return;
        hp -= Random.Range(12, 18);
        if (hp <= 0)
        {
            slider.value = 0;
            //播放声音
            AudioSource.PlayClipAtPoint(tankExplotionAudio,transform.position);
            AudioSource.PlayClipAtPoint(roundOverAudio, transform.position);
            //播放爆炸动画
            GameObject.Instantiate(TankExplosion, transform.position + Vector3.up, transform.rotation);
            //移除当前玩家     GameObject.Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            //切换到主镜头
            gameManager.GetComponent<GameManager>().roundOver = true;
            //计算分数
            int playerNum = this.gameObject.GetComponent<TankMove>().number%2+1;
            scoreManager.GetComponent<ScoreManager>().addScore(playerNum);//scoreManager.SendMessage("addScore",playerNum);
            Debug.Log("Loser:"+this.gameObject.name);
        }
        else
        {
            slider.value = (float)hp / hpTotal;
        }
    }
    public void initHealth()
    {
        hp = hpTotal;
        slider.value = 1;
    }

}
