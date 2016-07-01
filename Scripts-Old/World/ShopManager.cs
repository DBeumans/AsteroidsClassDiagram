using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {


    [SerializeField]
    Text UpgradeCounterTextDamage;
    [SerializeField]
    Text UpgradeCounterTextRange;

    [SerializeField]
    Text UpgradePriceRangeText;
    [SerializeField]
    Text UpgradePriceDamageText;

    Text _textEditor;
    ScoreHandler _ScoreHandler;
    EnemyHealth _EnemyHealth;
    Bullet _Bullet;

    int Upgrade_Gun_Damage_Level_Cap = 10;
    int Upgrade_Gun_Range_Level_Cap = 15;
    int Gun_Current_Damage_Level;
    int Gun_Current_Range_Level;

    bool canUpgrade = true;
    bool canUpgradeRange = true;
    public int Bullet_Damage = 20;
    public float Bullet_Range = 0.40f;
    int UpgradePriceDamage = 100;
    int UpgradePriceRange = 100;

    void Start()
    {
        _ScoreHandler = gameObject.GetComponent<ScoreHandler>();
        _textEditor = GameObject.FindObjectOfType<Text>();
        _Bullet = gameObject.GetComponent<Bullet>();
    }

    void Update()
    {
        UpgradeCounterTextDamage.text = Gun_Current_Damage_Level.ToString() + " / " + Upgrade_Gun_Damage_Level_Cap.ToString();
        UpgradeCounterTextRange.text = Gun_Current_Range_Level.ToString() + " / " + Upgrade_Gun_Range_Level_Cap.ToString();
        UpgradePriceDamageText.text = "Price: " + UpgradePriceDamage.ToString();
        UpgradePriceRangeText.text = "Price: " + UpgradePriceRange.ToString();

        //_EnemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        if (Gun_Current_Damage_Level >= Upgrade_Gun_Damage_Level_Cap)
        {
            // disable further upgrade.
            canUpgrade = false;
            UpgradeCounterTextDamage.color = Color.red;
            UpgradeCounterTextDamage.text = "MAX";
        }
        if(Gun_Current_Range_Level >= Upgrade_Gun_Range_Level_Cap)
        {
            canUpgradeRange = false;
            UpgradeCounterTextRange.color = Color.red;
            UpgradeCounterTextRange.text = "MAX";

        }
    }


    public void Upgrade_Gun_Damage()
    {
        // increase damage
        // first check if able to upgrade
        // if able to upgrade && if player have enough points
        // if player have enough points increase damage
        // increase Gun_Current_Level
        if(canUpgrade)
        {
            
            if (_ScoreHandler.Score >= UpgradePriceDamage)
            {
                //increase damage
                // increase upgrade level
                // withdraw points
                Bullet_Damage = Bullet_Damage + 5;
                Gun_Current_Damage_Level++;
                _ScoreHandler.Score -= UpgradePriceDamage;
                UpgradePriceDamage += 100;
                Debug.Log(Bullet_Damage);
            }
            else
            {
                // messange , not enough money OR max level for the upgrade.
                Debug.Log("Not Enough Points!" + Gun_Current_Damage_Level);
            }
        }
        else
        {
            Debug.Log("Upgrade Level Cap Reached!");
        }
    }

    public void Upgrade_Gun_Range()
    {
        if (canUpgradeRange)
        {
           
            if (_ScoreHandler.Score >= UpgradePriceRange)
            {
                Bullet_Range = Bullet_Range + 10f;
                Gun_Current_Range_Level++;
                _ScoreHandler.Score -= UpgradePriceRange;
                UpgradePriceRange += 100;
                Debug.Log(Bullet_Range);
            }
            else
            {
                // geen geld
                Debug.Log("Not enough points!");
            }
        }
        else
        {
            // upgrade level cap reached
            Debug.Log("Upgrade Level Cap Reached!");
        }
    }

}