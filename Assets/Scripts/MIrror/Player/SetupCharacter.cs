using System;
using System.Collections;
using TMPro;
//using Mirror;
using Normal.Realtime;
using Classes;
using Player;
using UnityEngine;

namespace PlayerMirror
{
    public class SetupCharacter : MonoBehaviour
    {

        private RealtimeView _realtimeView;
       /* [SyncVar]*/ public string currentHead = "";
       /* [SyncVar]*/ public string currentShirt = "";
       /* [SyncVar]*/ public string currentPants = "";
       /* [SyncVar]*/ public string currentShoes = "";
       /* [SyncVar]*/ public string currentExtra = "";
        
        [SerializeField] private GameObject playerGeometric;

        [SerializeField] private GameObject[] heads;
        [SerializeField] private GameObject[] shirts;
        [SerializeField] private GameObject[] pants;
        [SerializeField] private GameObject[] shoes;
        [SerializeField] private GameObject[] extras;
      /*  [SyncVar(hook = "DisplayPlayerName")]*/ public string playerUsername;

        // username
        public TMP_Text userTitle;
        PlayerDataSyncEvents playerDataSyncEvents;

        private void Start()
        {
            _realtimeView = GetComponent<RealtimeView>();
            playerDataSyncEvents = GetComponent<PlayerDataSyncEvents>();
        }
        public void EnableComponent()
        {
            foreach (var head in heads)
            {
                if (currentHead == head.name)
                {
                    head.SetActive(true);
                    playerDataSyncEvents.ChangeHead(currentHead);
                }
            }
            foreach (var shirt in shirts)
            {
                if (currentShirt == shirt.name)
                {
                    shirt.SetActive(true);
                    playerDataSyncEvents.ChangeShirt(currentShirt);
                }
            }
            foreach (var pant in pants)
            {
                if (currentPants == pant.name)
                {
                    pant.SetActive(true);
                    playerDataSyncEvents.ChangePants(currentPants);
                }
            }
            foreach (var shoe in shoes)
            {
                if (currentShoes == shoe.name)
                {
                    shoe.SetActive(true);
                    playerDataSyncEvents.ChangeShoes(currentShoes);
                }
            }
            foreach (var extra in extras)
            {
                if (currentExtra == extra.name)
                {
                    extra.SetActive(true);
                    playerDataSyncEvents.ChangeExtras(currentExtra);
                }
            }
        }

        public void ShirtUpdate(string shirtName)
        {
            foreach (var shirt in shirts)
            {
                if (shirtName == shirt.name)
                {
                    shirt.SetActive(true);
                }
            }
        }
        public void HeadUpdate(string headName)
        {
            foreach (var head in heads)
            {
                if (headName == head.name)
                {
                    head.SetActive(true);
                }
            }
        }
        public void PantsUpdate(string pantName)
        {
            foreach (var pant in pants)
            {
                if (pantName == pant.name)
                {
                    pant.SetActive(true);
                }
            }
        }
        public void ShoesUpdate(string shoesName)
        {
            foreach (var shoe in shoes)
            {
                if (shoesName == shoe.name)
                {
                    shoe.SetActive(true);
                }
            }
        }
        public void ExtrasUpdate(string extraName)
        {
            foreach (var extra in extras)
            {
                if (extraName == extra.name)
                {
                    extra.SetActive(true);
                }
            }
        }

        private void OnEnable()
        {
            StartCoroutine(StartSetup());
        }

        public IEnumerator StartSetup()
        {
            yield return new WaitForSeconds(1);
            EnableComponent();
            if (_realtimeView.isOwnedLocallyInHierarchy) { CmdSendName(PlayerData.username); }
        }
        
        void CmdSendName(string playerName)
        {
            playerUsername = playerName;
            userTitle.text = playerUsername;
        }
        
        public void DisplayPlayerName(string oldName, string newName)
        {
            Debug.Log("Player changed name from " + oldName + " to " + newName);
            userTitle.text = newName;
        }
    }
}
