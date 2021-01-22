using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanels;

    public int stars;
    public MapSelection[] mapSelections;
    public TMP_Text starText;
    public TMP_Text[] unlockedStarstext; //alterar para crirar as variáveis de estrelas por fase e por mundo

    const int maxStarLevel = 30;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        PlayerPrefs.DeleteAll();    
    }
    private void Update()
    {
        UpdateStarsUI();
        UpdateUnlockedStarsUI();
    }

    private void UpdateStarsUI()
    { 
        starText.text = "x " + stars.ToString();
    }
    private void UpdateUnlockedStarsUI() // atualiza o número de estrelas conquistadas
    {
        for (int i = 0; i < mapSelections.Length; i++)
        {
            unlockedStarstext[i].text = stars.ToString() + "/" + maxStarLevel.ToString();
        }
    }

    public void PressMapButton(int _mapIndex) //controla a transação entre o mapa geral e os mapas específicos de cada mundo
    {
        if (mapSelections[_mapIndex].isUnlocked == true)
        {
            levelSelectionPanels[_mapIndex].gameObject.SetActive(true);
            mapSelectionPanel.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Você ainda não pode abrir essa fase");
        }
    }

    public void BackButton()
    {
        mapSelectionPanel.gameObject.SetActive(true);
        for (int i = 0; i < mapSelections.Length; i++)
        {
            levelSelectionPanels[i].gameObject.SetActive(false);
        }
    }
}
