using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    
    public float roomTemp = 20; // Temperature de la salle
    public float slimeTemp; // Temperature du slime
    public float localTemp; // Temperature autour du slime (change entre zone chaude/froide)
    public float heatTransferRate = 0.1f; // Vitesse de transfert de chaleur (plus c'est grand, plus le changement de temperature est rapide)

    // Start is called before the first frame update
    void Start()
    {
        localTemp = roomTemp;
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
    }
}
