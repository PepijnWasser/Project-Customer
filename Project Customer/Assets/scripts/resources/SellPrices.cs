using UnityEngine;

public class SellPrices : MonoBehaviour
{
    public int minSellPriceWood;
    public int maxSellPriceWood;
    public int minSellPricePlastic;
    public int maxSellPricePlastic;
    public int minSellPriceOil;
    public int maxSellPriceOil;

    public int roughChangeTime;

    private float oldSellPriceWood;
    public float sellPriceWood;
    private int targetSellPriceWood;

    private float oldSellPricePlastic;
    public float sellPricePlastic;
    private int targetSellPricePlastic;

    private float oldSellPriceOil;
    public float sellPriceOil;
    private int targetSellPriceOil;

    int randomDelayWood = 0;
    private float secondcounterWood = 0;

    int randomDelayPlastic = 0;
    private float secondcounterPlastic = 0;

    int randomDelayOil = 0;
    private float secondcounterOil = 0;

    void Update()
    {
        UpdateWoodPrice();
        UpdatePlasticPrice();
        UpdateOilPrice();
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

    void UpdateOilPrice()
    {
        secondcounterOil += Time.deltaTime;
        if (secondcounterOil > roughChangeTime + randomDelayOil)
        {
            randomDelayOil = Random.Range(-30, 60);
            secondcounterOil = 0;
            targetSellPriceOil = Random.Range(minSellPriceOil, maxSellPriceOil);
            oldSellPriceOil = sellPriceOil;
        }
        sellPriceOil = Mathf.Lerp(oldSellPriceOil, targetSellPriceOil, secondcounterOil / (roughChangeTime + randomDelayOil));
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
