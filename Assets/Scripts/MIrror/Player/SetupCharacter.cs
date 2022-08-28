using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Classes;
using UnityEngine;

namespace PlayerMirror
{
    public class SetupCharacter : NetworkBehaviour
    {
        [SyncVar] public string currentHead = "";
        [SyncVar] public string currentShirt = "";
        [SyncVar] public string currentPants = "";
        [SyncVar] public string currentShoes = "";
        [SyncVar] public string currentExtra = "";
        
        [SerializeField] private GameObject playerGeometric;

        [SerializeField] private GameObject[] heads;
        [SerializeField] private GameObject[] shirts;
        [SerializeField] private GameObject[] pants;
        [SerializeField] private GameObject[] shoes;
        [SerializeField] private GameObject[] extras;  
        
        public void EnableComponent()
        {
            foreach (var head in heads)
            {
                if (currentHead == head.name)
                {
                    head.SetActive(true);
                }
            }
            foreach (var shirt in shirts)
            {
                if (currentShirt == shirt.name)
                {
                    shirt.SetActive(true);
                }
            }
            foreach (var pant in pants)
            {
                if (currentPants == pant.name)
                {
                    pant.SetActive(true);
                }
            }
            foreach (var shoe in shoes)
            {
                if (currentShoes == shoe.name)
                {
                    shoe.SetActive(true);
                }
            }
            foreach (var extra in extras)
            {
                if (currentExtra == extra.name)
                {
                    extra.SetActive(true);
                }
            }
        }

        private void OnEnable()
        {
            StartCoroutine(StartSetup());
        }

        IEnumerator StartSetup()
        {
            yield return new WaitForSeconds(1);
            EnableComponent();
        }
    }

}
