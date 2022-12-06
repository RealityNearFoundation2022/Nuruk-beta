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

  [SerializeField] GameObject banner;
  string saldo;
  private bool flag = false;

  void Start() {
    banner.SetActive(false);
#if UNITY_WEBGL  && !UNITY_EDITOR
    StartCoroutine("startWallet");
#endif
  }

  IEnumerator startWallet(){
    yield return new WaitForSeconds(3f);
    Balance();
  }

  public void Balance()
  {
    saldo = BalanceWallet();

    if (saldo != ""){
      banner.SetActive(true);
      userName.text = GetAccountID();
      balance.text = /* "Realities: " +  */saldo;
    }else{
      banner.SetActive(false);
    }
  }

  public void GoToLoginNear(){
    PlayerPrefs.SetString("City", "true");
    SceneManager.LoadSceneAsync("LoginNear", LoadSceneMode.Additive);
  }
}
