using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;

    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false;

    private Animator animator;
    private AsyncOperation loadingSceneOperation;

    public static void SwitchToScene(string name)
    {
        instance.animator.SetTrigger("sceneClosing");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(name);
        instance.loadingSceneOperation.allowSceneActivation = false;
    }

    private void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        if (shouldPlayOpeningAnimation)
        {
            animator.SetTrigger("sceneOpening");
        }
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            text.text = "Loading " + Mathf.RoundToInt(loadingSceneOperation.progress * 100) + " %";
            image.fillAmount = loadingSceneOperation.progress;
        }
    }

    void OnAnimationOver()
    {
        shouldPlayOpeningAnimation = true;
        loadingSceneOperation.allowSceneActivation = true;
    }



}
