using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField] MoveGround groundMoving;
    [SerializeField] Ground ground;
    static public bool isGame = true;
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        isGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGame)
        {
            groundMoving.MovingGround(ground);
            groundMoving.RepeatGround(ground);
        }
    }

    public void OnPause()
    {
        isGame = false;
        pauseMenu.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void OnResume()
    {
        pauseMenu.SetActive(false);
        isGame = true;
        pauseButton.gameObject.SetActive(true);
    }
    
    public void OnExit()
    {
        SceneTransition.SwitchToScene("PostGameMenu");
    }
}
