using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image lockedImage;
    public GameObject[] stars;

    public Sprite starSprite;

    void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            lockedImage.gameObject.SetActive(true);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else
        {
            lockedImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }    
        }
    }

    public void PressSelection(string _levelName)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(_levelName);
        }
    }


    private void UpdateLevelStatus()
    {
        int previousLevelNum = int.Parse(gameObject.name) -1;
        if (PlayerPrefs.GetInt("Lv" + previousLevelNum) > 0)
        {
            unlocked = true;
        }
    }

}
