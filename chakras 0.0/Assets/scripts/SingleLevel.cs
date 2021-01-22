using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{

    private int currentStarNum; 
    public int levelIndex;
    public void BackButton()
    {
        SceneManager.LoadScene("mapa_geral");
    }

    public void StarRank(int _starNum) //número de estrelas ganhas por fase
    {
        currentStarNum = _starNum;
        if (currentStarNum > PlayerPrefs.GetInt("Lv" + levelIndex)) // só salva a quantidader das estrelas se forem mais que as atuais
        {
            PlayerPrefs.SetInt("Lv" + levelIndex, _starNum);
        }
        BackButton();
        Debug.Log(PlayerPrefs.GetInt("Lv" + levelIndex, _starNum));

    }

}
