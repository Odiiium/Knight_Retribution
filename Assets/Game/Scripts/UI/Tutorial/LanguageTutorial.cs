using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LanguageTutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textArray;
    [SerializeField] private TextMeshProUGUI[] namesArray;

    void Start()
    {
        SwitchLanguage();
    }

    private void SwitchLanguage()
    {
        switch (PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                textArray[0].text = "Your healthbar and manabar.When your healthpoints will be less than zero, you will die.\nManabar shows how much mana you have. You need mana to cast spells.";
                textArray[1].text = "Attack and block icons. Tap to attack for attack.\nTap to block when enemy is about to attack you for decreasing dealt damage.";
                textArray[2].text = "Your skills. 2 standart abilities and ultimate ability at the center. Every ability has mana cost.\nAlso you have health potions at left and mana potions at right.\nUse them for restore 30 % health / mana pool";
                textArray[3].text = "An enemy. Kill him to get pass the wave.\nEnemy drops money and experience.Experience needed for getting level UP.You can spend money after game for upgrade.";
                textArray[4].text = "After passing 1, 10, 21, 32, 45, 60, 78, 99 waves, you will be able to start with this wave.\nEvery 7 waves you will meet the boss.";
                textArray[5].text = "Boss. There are 3 type of bosses in the game: Redhood, ArchMage and Dark Knight.\nYou will get a lot experience and money after killing him";
                textArray[6].text = "Passing the waves with some chance you can find chests. There are 4 rarity types of chests: wooden, iron, silver and golden.\nAt this image you can see iron chest.";
                textArray[7].text = "Strength, Agility and Intelligence.\nStrength increases your hp regeneration and maximum hp\nAgility increases your damage and block modifier\nIntelligence increases your mana pool and mana regen.";
                textArray[8].text = "Your healthpoints and damage. You can increase it using coins. Every upgrade increase your hp by 50 and damage by 20.";
                textArray[9].text = "Your health potions and mana potions. You can buy it using coins.\nEvery bottle of potion increase your current mana\nhp by 30 % ";
                textArray[10].text = "Your level and skillpoints. You will gain 1 skillpoint for every levelup. You can spend skillpoints for upgrading your abilities.";
                textArray[11].text = "Your abilities and their leveling.\nSpend Skill Points to upgrade your abilities and become the strongest mage of the world.";
                textArray[12].text = "Your character. You can unlock new characters in shop when watching ads. You can select character from character list.\nJust tap to 'Standart'.";
                textArray[13].text = "Watch ads to gain more coins. Also you can unlock new character for 50, 100 and 150 watched ads.\nAlso it is the only way to support author of this game.";
                textArray[14].text = "Your money. You can buy any things spending this coins.";
                textArray[15].text = "Leaderboard and shop. Set new records to reach unprecedented heights.\nAlso you can buy some characters and abilities in the shop.\nThat's all. Tap 'Play' for play.";
                namesArray[0].text = "Player Bars";
                namesArray[1].text = "Attack And Block";
                namesArray[2].text = "Player Ability Panel";
                namesArray[3].text = "Enemy";
                namesArray[4].text = "Waves";
                namesArray[5].text = "Boss";
                namesArray[6].text = "Chests";
                namesArray[7].text = "Stats";
                namesArray[8].text = "Hp and Damage";
                namesArray[9].text = "Potions";
                namesArray[10].text = "Level and Skillpoints";
                namesArray[11].text = "Ability leveling";
                namesArray[12].text = "Characters";
                namesArray[13].text = "Ads";
                namesArray[14].text = "Money";
                namesArray[15].text = "Shop and LeaderBoard";
                break;
            case 1:
                textArray[0].text = "T�� ����� ������'� �� ����. K��� ����� ������'� ����� ����� ����, �� �����.\n������� ���� ������ ������ ���� �� ���. ���� ��������� ��� ������������ �����.";
                textArray[1].text = "����� �� ���. ����� �� `A` ��� �����.\n������� �� ���, ���� ����� �������, ��� �������� ���� ���� �� ���.";
                textArray[2].text = "T�� �������. 2 ������� ����� �� ������������ ����� � �����. K���� ����� �� ���� � ���.\nT���� �� ��� ���� ������'� �� ����.\n���� ������ �������� 30% ���� ��� ������'�";
                textArray[3].text = "�����, ���� ����, ��� ������ �����.\n� ������ ��������� ������ �� ���� ������. ���� ������ �������� ��� ��������� ����.";
                textArray[4].text = "ϳ��� ����������� 1, 10, 21, 32, 45, 60, 78, 99 ����� �� ������ �������� ��� ���� � ���� ����.\n���� �'��������� ���� 7 �����";
                textArray[5].text = "����. ������ � 3 �������� �����: ���������, ������� �� T����� �����.\n� �� �������� �� ������� �������� ����� ����� �� ���� ������.";
                textArray[6].text = "������, � ������ ������ �� ������ ���������� �� ������ � �������.\n������ � 4 ���� ������: �����'���, ������, ����� �� ������.";
                textArray[7].text = "����, ���������, ��������\n���� ������ ��� ����� �� �� �� �����\n��������� ������ ��� ���� �� ����������� �����\n�������� ������ ������� ����";
                textArray[8].text = "T�� ���� ������'� �� �����. K���� ��������� ������  ����� ������'� �� 50, � ���� �� 20.";
                textArray[9].text = "T�� ���� ������'� �� ����.\nK���� ���� ���� ����������� �� 30% �� ������������� ������ ������'� ��� ����";
                textArray[10].text = "T�� ����� �� ���� ������. T� ����� ���������� �� 1 ���� ������� �� ����� ����� �����. T� ������ ��������� �� �� ��������� ���� ���� ���������.";
                textArray[11].text = "T�� ������� �� �� �����. �������� ���� ������� ��� ��������� ��� ������� �� ����� ����������� ����� �������!";
                textArray[12].text = "T�� ��������. T� ������ ������� ������ ��������� � �������, ��������� �������. T���� �� ����� ������� ��������� � ������, ������ ����� �� 'Standart'.";
                textArray[13].text = "������ �������, ��� ���������� ����� �����. T���� �� ������ ������� ������ ��������� �� 50, 100 �� 150 ������������ ������.\n�� ������ ������ �� ������ ����, ��� ��������� ������.";
                textArray[14].text = "T�� �����. T� ������ ������ ��� ������� ���� ��, �� �� ���� ������� ����.";
                textArray[15].text = "T������ ����� �� �������. ���� ��� ������� ��� ���������� ���������������� ������. T���� �� ����� ������ ����� ��������� ��� ������� � �������, �� ���, ������ ��� 'Play'.";
                namesArray[0].text = "������'� �� ����";
                namesArray[1].text = "����� �� ���";
                namesArray[2].text = "������ ����";
                namesArray[3].text = "�����";
                namesArray[4].text = "X���";
                namesArray[5].text = "����";
                namesArray[6].text = "�����";
                namesArray[7].text = "X�������������";
                namesArray[8].text = "������'� �� ����";
                namesArray[9].text = "ǳ���";
                namesArray[10].text = "г���� �� O��� ����";
                namesArray[11].text = "P����� ����";
                namesArray[12].text = "��������";
                namesArray[13].text = "�������";
                namesArray[14].text = "�����";
                namesArray[15].text = "������� �� ��������";
                break;
            case 2:
                textArray[0].text = "T��� ������� ����� � ����. K���� ������� ����� ������ ������ ��� ����, �� ������.\n������ ���� ����������, ������� ���� ���� � �������, ��� ����� ��� ������������� ����������.";
                textArray[1].text = "����� � ���. ����� 'A' ��� �����.\n������� ���, ����� ���� ������, ��� �� ��������� ��� ���� �� ����.";
                textArray[2].text = "T��� ������. 2 ������� ������ � ������������� � ������. K����� ������ ����� ������ ���� � ����.\nT���� � ���� ���� ����� ����� � ����.\nK����� ��������������� �� 30% ��������������.";
                textArray[3].text = "����. ���� ���, ��� �� ������ �����.\nC ����� �������� ������ � ����. O��� ����� ��� ���������� ������";
                textArray[4].text = "����� ����������� 1, 10, 21, 32, 45, 60, 78, 99 ���� �� ������� ������ ���� ���� � ������ �����.\n���� ���������� ������ 7 ����.";
                textArray[5].text = "����. E��� 3 ������������� ������: O�������, ������� � T����� ������.\nC �� �������� �� �������� ������� ������ ����� � �����.";
                textArray[6].text = "C ��������� ������, ������� �����, �� ������� ���������� �� �������.\nE��� 4 ������ ��������: ����������, ��������, ���������� � �������.";
                textArray[7].text = "����, ��������, ���������.\n���� ����������� ���� ������� ����� � �� �����.\n�������� ����������� ���� ���� � ����������� �����.\n��������� ����������� ������� ����";
                textArray[8].text = "T��� ���� �������� � �����. K����� ��������� ����������� ������� ����� �� 50, � ���� �� 20";
                textArray[9].text = "T��� ����� �������� � ����.\nK����� ����� ����� ������������ �� 30% �� ������������� ������ ����� ��� ����.";
                textArray[10].text = "T��� ������� � ���� �������. T� ������ �������� �� 1 ���� ������� �� ������ ����� �������. T� ������� ������� �� �� ���������� ������ ����� ������������.";
                textArray[11].text = "T��� ����������� � �� �������. T���� ���� �������, ��� �� �������� ���� ����������� � ����� ���������� ����� ���������!";
                textArray[12].text = "T��� ��������. T� ������� ������� ������ ��������� � �������� �� ��������� �������. T���� �� ������ ������� ��������� �� ������, ����� �� 'Standart' ";
                textArray[13].text = "������ �������, ��� �� �������� ������ �����. T�� �� �� ������� ������� ����� ���������� �� 50, 100 � 150 ������������� ������.\n�� ������ ������ �������� ������������ ����� ���������� ������������ ����.";
                textArray[14].text = "T��� ������. T� ������ ������ ��� �������� ��� ������, ���� ��� ����� ���� �������� ����.";
                textArray[15].text = "T������ ������� � �������. ����� ����� �������, ��� �� ���������� ��������������� ������. T�� �� �� ������ ������ ����� ���������� � ��������, ��� 'Play' ��� ������.";
                namesArray[0].text = "�������� � ����";
                namesArray[1].text = "����� � ���";
                namesArray[2].text = "������ ������";
                namesArray[3].text = "����";
                namesArray[4].text = "�����";
                namesArray[5].text = "����";
                namesArray[6].text = "�������";
                namesArray[7].text = "X�������������";
                namesArray[8].text = "�������� � ����";
                namesArray[9].text = "�����";
                namesArray[10].text = "������� � O��� ������";
                namesArray[11].text = "������� ������";
                namesArray[12].text = "���������";
                namesArray[13].text = "�������";
                namesArray[14].text = "������";
                namesArray[15].text = "������� � ���������";
                break;

        }
    }
}
