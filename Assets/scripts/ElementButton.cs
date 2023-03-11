﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public GameObject materialType;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(CreateElement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateElement()
    {

        gameManager.makePrefab(materialType);

    }
}
