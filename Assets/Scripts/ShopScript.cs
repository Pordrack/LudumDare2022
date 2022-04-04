using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    private static ShopScript _instance;

    public static ShopScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ShopScript>();
            }

            return _instance;
        }
    }

    public Text MoneyText;
    private float money;
    public float Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            MoneyText.text = Mathf.FloorToInt(money).ToString();
        }
    }

    public GameObject TurretPreviz;
    public GameObject TurretPrefab;
    public bool willPlaceTurret=false;
    

    // Start is called before the first frame update
    void Start()
    {
        Money = 0;
    }

    private void Update()
    {
        if (!willPlaceTurret)
        {
            return;
        }

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        TurretPreviz.transform.position = mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            PlaceTurret();
        }
    }


    public void BuyWaterCollector(BuySlotScript slot)
    {
        if (Money < slot.Price)
        {
            return;
        }

        Money -= slot.Price;
        WaterCanScript.Instance.WaterReserve = Random.Range(0.3f, 0.7f) * WaterCanScript.Instance.WaterMaxReserve;
        WaterCanScript.Instance.WaterReserve = Mathf.Clamp(WaterCanScript.Instance.WaterReserve, 0, WaterCanScript.Instance.WaterMaxReserve);
    }

    public void BuyFrogTurret(BuySlotScript slot)
    {
        if (Money < slot.Price || willPlaceTurret)
        {
            return;
        }

        Money -= slot.Price;
        willPlaceTurret = true;
        TurretPreviz.SetActive(true);
    }

    public void PlaceTurret()
    {
        willPlaceTurret = false;
        GameObject newTurret = Object.Instantiate(TurretPrefab);
        newTurret.transform.position = TurretPreviz.transform.position;
        TurretPreviz.SetActive(false);
    }
}
