using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using CustomEvents;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;


public class WalletBalance : MonoBehaviour
{
  [SerializeField] Text userName;
  [SerializeField] Text balance;
 /*  [SerializeField] GameObject popUp; */
  
  [DllImport("__Internal")]
  private static extern string GetAccountID();

  [DllImport("__Internal")]
  private static extern string BalanceWallet();

  [DllImport("__Internal")]
  private static extern bool WalletIsSignedIn();

  GameObject banner;
  string saldo;
  private bool flag = false;

  void Start() {
//#if UNITY_WEBGL  && !UNITY_EDITOR
    StartCoroutine(startWallet());
    banner = gameObject;
    banner.SetActive(false);
   /* if (!WalletIsSignedIn())
    {
      popUp.SetActive(true);
    }*/
//#endif
    

  }

  IEnumerator startWallet(){
    yield return new WaitForSeconds(3f);
    Debug.Log("startWallet");

    Balance();
  }

  public void Balance()
  {
    saldo = BalanceWallet();
    Debug.Log(saldo+" saldo");

    if (saldo != ""){
      banner.SetActive(true);
      userName.text = GetAccountID();
      balance.text = /* "Realities: " +  */saldo;
    }else{
      banner.SetActive(false);
    }
  }

  void Update()
  {
/*#if UNITY_WEBGL && !UNITY_EDITOR
    if (WalletIsSignedIn() && !flag){
      popUp.SetActive(false);
      flag = true;
    }
#endif    */
    
  }
 /*  public void ClosePopUp(){
    popUp.SetActive(false);
  } */
  public void GoToLoginNear(){
        PlayerPrefs.SetString("City", "true");
        SceneManager.LoadSceneAsync("LoginNear", LoadSceneMode.Additive);
    }
}
