using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPriceWareHouse : MonoBehaviour
{
    public int minSellPriceWood;
    public int maxSellPriceWood;
    public int minSellPricePlastic;
    public int maxSellPricePlastic;

    [Min(30)]
    public int roughChangeTime;

    private float oldSellPriceWood = 1;
    [HideInInspector]
    public float sellPriceWood;
    private int targetSellPriceWood = 2;

    private float oldSellPricePlastic = 1;
    [HideInInspector]
    public float sellPricePlastic;
    private int targetSellPricePlastic = 2;

    int randomDelayWood = 0;
    private float secondcounterWood = 0;

    int randomDelayPlastic = 0;
    private float secondcounterPlastic = 0;

    void Update()
    {
        UpdateWoodPrice();
        UpdatePlasticPrice();
    }

    void UpdateWoodPrice()
    {
        secondcounterWood += Time.deltaTime;
        if (secondcounterWood > roughChangeTime + randomDelayWood)
        {
            randomDelayWood = Random.Range(-30, 60);
            secondcounterWood = 0;
            targetSellPriceWood = Random.Range(minSellPriceWood, maxSellPriceWood + 1);
            oldSellPriceWood = sellPriceWood;
        }
        sellPriceWood = Mathf.Lerp(oldSellPriceWood, targetSellPriceWood, secondcounterWood / (roughChangeTime + randomDelayWood));
    }

    void UpdatePlasticPrice()
    {
        secondcounterPlastic += Time.deltaTime;
        if (secondcounterPlastic > 60 + randomDelayPlastic)
        {
            randomDelayPlastic = Random.Range(-30, 60);
            secondcounterPlastic = 0;
            targetSellPricePlastic = Random.Range(minSellPricePlastic, maxSellPricePlastic);
            oldSellPricePlastic = sellPricePlastic;
        }
        sellPricePlastic = Mathf.Lerp(oldSellPricePlastic, targetSellPricePlastic, secondcounterPlastic / (roughChangeTime + randomDelayPlastic));
    }
}
