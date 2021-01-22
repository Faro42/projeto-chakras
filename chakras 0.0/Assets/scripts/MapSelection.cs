using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
  public bool isUnlocked = false;
  public GameObject lockedGP;
  public GameObject unlockedGP;

  public int mapIndex;
  public int requestStars;
  public int startLevel;
  public int endLevel;

    private void Update() 
    {
        UpdateMapStatus();
        UnlockeMap();    
    }

    private void UpdateMapStatus()
    {
        if (isUnlocked) //mapa está aberto
        {
            unlockedGP.gameObject.SetActive(true);
            lockedGP.gameObject.SetActive(false);
        }else
        {
            unlockedGP.gameObject.SetActive(false);
            lockedGP.gameObject.SetActive(true);
        }
    }

    private void UnlockeMap() // destrava o mapa quando consegue o número de estrelas necessárias
    {
        if (UIManager.instance.stars >= requestStars)
        {
            isUnlocked = true;
        }
        else
        {
            isUnlocked = false;
        }
    }

}
