using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temperature : MonoBehaviour
{
    // Get slider UI for the thermometer
    [SerializeField]
    private Slider thermometerSlider; // si Bug Drag and drop le GameObject Slider dans l'inspector (se trouve dans le canvas)

    [SerializeField]
    private GameObject RoomTemperatureGauge; // si Bug Drag and drop le GameObject RoomTemperatureGauge dans l'inspector (se trouve dans le canvas)

    private RectTransform roomTemperatureGaugeRectTransform;


    public float roomTemp = 20; // Temperature de la salle
    public float slimeTemp; // Temperature du slime
    public float localTemp; // Temperature autour du slime (change entre zone chaude/froide)
    public float heatTransferRate = 0.3f; // Vitesse de transfert de chaleur (plus c'est grand, plus le changement de temperature est rapide)

    // Start is called before the first frame update
    void Start()
    {
        localTemp = roomTemp;
        roomTemperatureGaugeRectTransform = RoomTemperatureGauge.GetComponent<RectTransform>();

        // rotation à 90° fait que x est la hauteur et y la largeur
        float SliderHeight = thermometerSlider.GetComponent<RectTransform>().rect.width;
        float SliderMaxValue = thermometerSlider.maxValue;
        float SliderMinValue = thermometerSlider.minValue;
        float TempGaugeHeight = SliderHeight * (roomTemp - SliderMinValue) / (SliderMaxValue - SliderMinValue);
        roomTemperatureGaugeRectTransform.anchoredPosition = new Vector2(TempGaugeHeight, 0);

        
    }

    public void enterNewTempZone(float newLocalTemp)
    {
        localTemp = newLocalTemp;
    }

    public void leaveTempZone()
    {
        localTemp = roomTemp;
    }

    // Update is called once per frame
    void Update()
    {
        slimeTemp += Time.deltaTime * heatTransferRate * (localTemp - slimeTemp);

        thermometerSlider.value = slimeTemp;
    }
}
