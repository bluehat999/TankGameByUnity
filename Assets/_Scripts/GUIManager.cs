using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public Rect rectBtn;
    public int SceneNum;
    public GameObject maskImage;
    public GameObject gameMenu;
    public float fadeSpeed = 1.0f;
    private float alpha = 1.0f;
    private CanvasGroup canvasGroup;
    private bool showMenu = false;
    private bool restart = false;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = maskImage.GetComponent<CanvasGroup>();
        FadeIn();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.MenuToggle();
        }
        if (restart)
        {
            this.MenuToggle();
            restart = false;
        }
        if (alpha != canvasGroup.alpha)
        {
            Debug.Log("遮罩渐变");
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, alpha, fadeSpeed * Time.deltaTime);
            if (Mathf.Abs(canvasGroup.alpha - alpha) < 0.05f)
            {
                canvasGroup.alpha = alpha;
            }
        }


    }
    private void OnGUI()
    {
        /*
        GUI.BeginGroup(new Rect(Screen.width * 0.4f, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.4f));
        GUI.EndGroup();
        if (showMenu)
        {
            if (GUI.Button(new Rect(Screen.width * rectBtn.x, Screen.height * rectBtn.y, Screen.width * rectBtn.width, Screen.height * rectBtn.height), "Back"))
            {
                SceneManager.LoadScene(0);
            }

            if (GUI.Button(new Rect(Screen.width * rectBtn.x, Screen.height * rectBtn.y + Screen.height * rectBtn.height, Screen.width * rectBtn.width, Screen.height * rectBtn.height), "ReStart"))
            {
                SceneManager.LoadScene(SceneNum);
            }
        }
        */
     }
    public void RestartPress()
    {
        this.restart = true;
    }
    public void FadeIn(float endAlpha = 0f)
    {
        alpha = 0f;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("FadeIn in GUIManager");
        
        
    }
    public void FadeOut(float endAlpha = 1.0f)
    {
        alpha = 1.0f;
        canvasGroup.blocksRaycasts = false;
    }
    public void BackPress()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    protected void MenuToggle()
    {
        showMenu = !showMenu;
        gameMenu.SetActive(showMenu);
        if (showMenu)
        {
            canvasGroup.alpha = 0.5f;
            Time.timeScale = 0;
        }
        else
        {
            this.FadeIn();
            Time.timeScale = 1;
        }
    }
}
