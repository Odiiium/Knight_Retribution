using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] EndGameMenu endGameMenu;
    [SerializeField] PlayerUI playerUI;
    void LateUpdate()
    {
        if (PlayerController.isDead & playerUI.gameObject.activeSelf)
        {
            FindObjectOfType<PlayerUI>().gameObject.SetActive(false);
            endGameMenu.gameObject.SetActive(true);
        }
    }

}
