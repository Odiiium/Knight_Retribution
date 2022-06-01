using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownController : MonoBehaviour
{
    [SerializeField] GameObject[] charactersList;
    [SerializeField] GameObject lockPanel;

    public void ChangeCharacter(int index)
    {
        switch (index)
        {

            case 0:
                charactersList[0].SetActive(true);
                SpawnManager.playerIndex = 0;
                lockPanel.SetActive(false);
                for (int jvalue = 1; jvalue < 4; jvalue++)
                {
                    charactersList[jvalue].SetActive(false);
                }
                break;
            case 1:
                charactersList[1].SetActive(true);
                charactersList[0].SetActive(false);
                for (int jvalue = 2; jvalue < 4; jvalue++)
                {
                    charactersList[jvalue].SetActive(false);
                }
                SetPlayerIndex(1);
                break;
            case 2:
                charactersList[2].SetActive(true);
                charactersList[3].SetActive(false);
                for (int jvalue = 0; jvalue < 2; jvalue++)
                {
                    charactersList[jvalue].SetActive(false);
                }
                SetPlayerIndex(2);
                break;
            case 3:
                charactersList[3].SetActive(true);
                for (int jvalue = 0; jvalue < 3; jvalue++)
                {
                    charactersList[jvalue].SetActive(false);
                }
                SetPlayerIndex(3);
                break;
        }
    }

    private void SetPlayerIndex(int value)
    {
        if (PlayerPrefs.GetInt("adsWatched") >= value * 50)
        {
            SpawnManager.playerIndex = value;
            lockPanel.SetActive(false);
        }
        else
        {
            lockPanel.SetActive(true);
        }
    }


}
