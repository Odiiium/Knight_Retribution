using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityDescription : MonoBehaviour
{
    [SerializeField] GameObject imageObject;
    [SerializeField] Sprite[] descriptionImages;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] AbilityDescription abilityDescriptionPanel;

    public void FireBallDecsription()
    {
        abilityDescriptionPanel.gameObject.SetActive(true);
        imageObject.gameObject.GetComponent<Image>().sprite = descriptionImages[0];
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                descriptionText.text = "Fireball is a standart ability that can damage an enemies and set them burn for 3 seconds.\nFireball can destroy Fireworm's fireball if you have used this while he was casting their ability.\n This ability has 4 seconds cooldown.";
                break;
            case 1:
                descriptionText.text = "Boгняний шар - стандартна здібність, яка наносить шкоду ворогам та здатна опалити ворогів на 3 секунди.\nBогняний шар також здатний зруйнувати атаку вогняного хробака, коли той кастує свою атаку.\nМає перезарядку в 4 секунди.";
                break;
            case 2:
                descriptionText.text = "Oгненный шар - стандартная способность, которая наносит урон и поджигает врагов на 3 секунды. Oгненный шар также способен разрушить способность огненного червя, когда тот производит свою атаку.\nСпособность имеет перезарядку в 4 секунды.";
                break;
        }
    }
    public void LightningBoltDecsription()
    {
        abilityDescriptionPanel.gameObject.SetActive(true);
        imageObject.gameObject.GetComponent<Image>().sprite = descriptionImages[1];
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                descriptionText.text = "Lightning Bolt is a standart ability that provides you an ability to stun enemies and dealt them some damage. Very useful versus range and magical enemies.\nThis ability has 4 seconds cooldown.";
                break;
            case 1:
                descriptionText.text = "Блискавка - стандартна здібність, що позволяє тобі станити ворога на деякий час.\nKорисна здібність проти магів та ворогів з дальньою атакою.\nМає перезарядку в 4 секунди";
                break;
            case 2:
                descriptionText.text = "Молния - стандартная способность, которая позволяет тебе станить врага на некоторое время и наносить небольшой урон.\nOчень полезная способность против магов и врагов дальнего боя.\nПерезаряжается 4 секунды.";
                break;
        }
    }
    public void BlackHoleDecsription()
    {
        abilityDescriptionPanel.gameObject.SetActive(true);
        imageObject.gameObject.GetComponent<Image>().sprite = descriptionImages[2];
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                descriptionText.text = "Blackhole is an ultimate ability that provides you power over gravity.\nThis ability attracts enemies and damages them every seconds split while it lasts.\nThis ability has 10 seconds cooldown.";
                break;
            case 1:
                descriptionText.text = "Сингулярність - ультимативна здібність, яка дає тобі контроль над гравітацією.\n3дібність притягує ворогів на наносить шкоду кожну долю секунди до того часу поки тривалість не закінчиться. Має перезарядку в 10 секунд.";
                break;
            case 2:
                descriptionText.text = "Сингулярность - ультимативное заклинание, которое дает тебе контроль над гравитацией.\nCпособность притягивает врагов и наносит им урон каждую долю секунды до того момента, пока длительность способности не закончится.\nПерезаряжается 10 секунд.";
                break;
        }
    }

    public void HideDescription()
    {
        abilityDescriptionPanel.gameObject.SetActive(false);
    }


}
