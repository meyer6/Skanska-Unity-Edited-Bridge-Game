using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject stonePrefab;

    private Plane bridgePlane;
    private float z = -7.0f;
    public Vector3 mousePosition;

    private int totCost;
    private int totWeight;
    private int totCarbon;
    private float totTensileStrength;
    public Text screenText;


    // Start is called before the first frame update
    void Start()
    {
        totCost = 0;
        totWeight = 0;
        totCarbon = 0;
        totTensileStrength = 0;

        bridgePlane = new Plane(Vector3.forward, new Vector3(0.0f, 0.0f, z));
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(ray);


        //variable to record distance along ray of intersect with plane
        float enter;// = 0.0f;

        if (bridgePlane.Raycast(ray, out enter))
        {
            mousePosition = ray.GetPoint(enter);
        }

    }


    public void makePrefab(GameObject prefab)
    {
        Instantiate(prefab);
        totCost += prefab.GetComponent<BuildingElementScript>().cost;
        totWeight += prefab.GetComponent<BuildingElementScript>().weight;
        totCarbon += prefab.GetComponent<BuildingElementScript>().carbonDioxide;
        totTensileStrength += prefab.GetComponent<BuildingElementScript>().tensileStrength;

        screenText.GetComponent<TotalQuantsScript>().FormatText(totCost, totWeight, totCarbon, totTensileStrength);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
