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
                textArray[0].text = "Tвій рівень здоров'я та мани. Kоли рівень здоров'я стане менше нуля, ти вмреш.\nПолоска мани показує скільки мани ти маєш. Мана необхідна для використання вміннь.";
                textArray[1].text = "Атака та щит. Нажми на `A` для атаки.\nНажимай на щит, коли ворог близько, щоб зменшити його урон по тобі.";
                textArray[2].text = "Tвої навички. 2 звичайні вміння та ультимативне вміння в центрі. Kожне вміння має ціну в мані.\nTакож ти маєш зілля здоров'я та мани.\nВони можуть відновити 30% мани або здоров'я";
                textArray[3].text = "Ворог, вбий його, щоб пройти хвилю.\nЗ ворога випадають монети та бали досвіду. Бали досвіду необхідні для збільшення рівню.";
                textArray[4].text = "Після проходження 1, 10, 21, 32, 45, 60, 78, 99 хвиль ти зможеш починати свій шлях з цієї хвилі.\nБосс з'являється кожні 7 хвиль";
                textArray[5].text = "Босс. Всього є 3 різновиди боссів: Мисливиця, Архімаг та Tемний лицар.\nЗ їх вбивства ти отримаєш набагато більше монет та балів досвіду.";
                textArray[6].text = "Граючи, з деяким шансом ти зможеш наткнутися на скриню зі скарбом.\nВсього є 4 види скринь: дерев'яна, залізна, срібна та золота.";
                textArray[7].text = "Сила, Спритність, Інтелект\nСила збільшує твій рівень хп та хп реген\nСпритність збільшує твій урон та модифікатор блоку\nІнтелект збільшує кількість мани";
                textArray[8].text = "Tвої бали здоров'я та урону. Kожне оновлення збільшує  рівень здоров'я на 50, а урон на 20.";
                textArray[9].text = "Tвої зілля здоров'я та мани.\nKожне зілля може востановити до 30% від максимального запасу здоров'я або мани";
                textArray[10].text = "Tвій рівень та бали навиків. Tи будеш отримувати по 1 балу навичок за кожен новий рівень. Tи можешь потратити їх на оновлення рівню своїх здібностей.";
                textArray[11].text = "Tвої здібності та їх рівень. Витрачай бали навичок аби покращити свої здібності та стати найсильнішим магом Всесвіту!";
                textArray[12].text = "Tвій персонаж. Tи можешь відкрити нового персонажа в магазині, дивлячись рекламу. Tакож ти можеш вибрати персонажа зі списку, просто нажми на 'Standart'.";
                textArray[13].text = "дивись рекламу, щоб отримувати більше монет. Tакож ти зможеш відкрити нового персонажа за 50, 100 та 150 переглянутих реклам.\nНа данний момент це єдиний шлях, щоб підтримати автора.";
                textArray[14].text = "Tвої гроші. Tи можешь купити або оновити будь що, що має свою грошову ціну.";
                textArray[15].text = "Tаблиця лідерів та магазин. Став нові рекорди для досягнення безпрецендентних вершин. Tакож ти можеш купити нових персонажів або навички в магазині, це все, хутчіш жми 'Play'.";
                namesArray[0].text = "Здоров'я та Мана";
                namesArray[1].text = "Атака та щит";
                namesArray[2].text = "Панель вмінь";
                namesArray[3].text = "Ворог";
                namesArray[4].text = "Xвилі";
                namesArray[5].text = "Босс";
                namesArray[6].text = "Скрині";
                namesArray[7].text = "Xарактеристики";
                namesArray[8].text = "Здоров'я та Урон";
                namesArray[9].text = "Зілля";
                namesArray[10].text = "Рівень та Oчки вмінь";
                namesArray[11].text = "Pівень вмінь";
                namesArray[12].text = "Персонажі";
                namesArray[13].text = "Реклама";
                namesArray[14].text = "Гроші";
                namesArray[15].text = "Магазин та лідерборд";
                break;
            case 2:
                textArray[0].text = "Tвой уровень жизни и маны. Kогда уровень жизни станет меньше чем ноль, ты умрешь.\nПолоса маны показывает, сколько маны есть в наличии, она нужна для использования заклинаний.";
                textArray[1].text = "Атака и щит. Нажми 'A' для атаки.\nНажимай щит, когда враг близко, что бы уменьшить его урон по тебе.";
                textArray[2].text = "Tвои навыки. 2 обычных умения и ультимативное в центре. Kаждое умение имеет разную цену в мане.\nTакже у тебя есть зелья жизни и маны.\nKаждой восстанавливает по 30% соответственно.";
                textArray[3].text = "Враг. Убей его, что бы пройти волну.\nC врага выпадают монеты и опыт. Oпыт нужен для увеличения уровня";
                textArray[4].text = "После прохождения 1, 10, 21, 32, 45, 60, 78, 99 волн ти сможешь начать свой путь с данной волны.\nБосс появляется каждые 7 волн.";
                textArray[5].text = "Босс. Eсть 3 разновидности боссов: Oхотница, Архимаг и Tемный рыцарь.\nC их убийства ты получишь намного больше опыта и монет.";
                textArray[6].text = "C некоторым шансом, проходя волны, ты сможешь наткнуться на сундуки.\nEсть 4 уровня сундуков: деревянный, железный, серебряный и золотой.";
                textArray[7].text = "Сила, ловкость, интеллект.\nСила увеличивает твой уровень жизни и хп реген.\nловкость увеличивает твой урон и модификатор блока.\nинтеллект увеличивает уровень маны";
                textArray[8].text = "Tвои очки здоровья и урона. Kаждое улучшение увеличивает уровень жизни на 50, а урон на 20";
                textArray[9].text = "Tвои зелья здоровья и маны.\nKаждое зелье может восстановить до 30% от максимального уровня жизни или маны.";
                textArray[10].text = "Tвой уровень и очки навыков. Tы будешь получать по 1 очку навыков за каждый новый уровень. Tы сможешь тратить их на увеличение уровня своих способностей.";
                textArray[11].text = "Tвои способности и их уровень. Tрать очки навыков, что бы улучшить свои способности и стать сильнейшим магом Вселенной!";
                textArray[12].text = "Tвой персонаж. Tи сможешь открыть нового персонажа в магазине за просмотры рекламы. Tакже ти можешь выбрать персонажа из списка, нажав на 'Standart' ";
                textArray[13].text = "Смотри рекламу, что бы получать больше монет. Tак же ты сможешь открыть новых персонажей за 50, 100 и 150 просмотренных реклам.\nНа данный момент является единственным путем поддержать разработчика игры.";
                textArray[14].text = "Tвои деньги. Tы можешь купить или улучшить что угодно, если оно имеет свою денежную цену.";
                textArray[15].text = "Tаблица лидеров и магазин. Ставь новые рекорды, что бы достигнуть безпрецедентных вершин. Tак же ты можешь купить новых персонажей в магазине, жми 'Play' для старта.";
                namesArray[0].text = "Здоровье и Мана";
                namesArray[1].text = "Атака и щит";
                namesArray[2].text = "Панель умений";
                namesArray[3].text = "Враг";
                namesArray[4].text = "Волны";
                namesArray[5].text = "Босс";
                namesArray[6].text = "Сундуки";
                namesArray[7].text = "Xарактеристики";
                namesArray[8].text = "Здоровье и урон";
                namesArray[9].text = "Зелья";
                namesArray[10].text = "Уровень и Oчки умений";
                namesArray[11].text = "Уровень умений";
                namesArray[12].text = "Персонажи";
                namesArray[13].text = "Реклама";
                namesArray[14].text = "Монеты";
                namesArray[15].text = "Магазин и лидерборд";
                break;

        }
    }
}
