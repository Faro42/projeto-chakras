using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

   public int maxVida;
   int vidaAtual;

   public Rigidbody2D frag;
   public Transform pedrapartida;
  
   void Start()
   {
       vidaAtual = maxVida;
   }

   public void RecebeDano(int dano)
   {
       vidaAtual -= dano;

       Instantiate(frag, pedrapartida.position, pedrapartida.rotation); 
       // animação recebendo dano - TODO

       if(vidaAtual <= 0)
        Morreu();
   }

    private void Morreu()
    {
        Destroy(gameObject);

        //animação de eliminação do inimigo - TODO
    }
}
