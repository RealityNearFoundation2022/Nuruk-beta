using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Michsky.UI.ModernUIPack;
using CustomEvents;

public class SceneManagerControl : MonoBehaviour
{

   public static SceneManagerControl Instance;
   public ProgressBar progressBar;

   [SerializeField]
   GameObject loadingCanvas;

   private Animator animator;

   void Awake()
   {

      if (Instance == null)
      {
         Instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
         Destroy(gameObject);
      }
   }

   void Start()
   {
      animator = GetComponent<Animator>();
   }

   IEnumerator LoadScene(string nameScene)
   {
      animator.SetTrigger("FadeIn");
      
      yield return new WaitForSeconds(0.5f);
      
      var scene = SceneManager.LoadSceneAsync(nameScene);
      scene.allowSceneActivation = false;
      do
      {
         yield return new WaitForSeconds(0.1f);

         progressBar.currentPercent = scene.progress * 100;
      } while (scene.progress < 0.9f);


      yield return new WaitForSeconds(1);

      scene.allowSceneActivation = true;

      animator.SetTrigger("FadeOut");
   }

   void LoadSceneCoroutine(string scene)
   {
      StartCoroutine("LoadScene", scene);
   }

   private void OnEnable()
   {
      Events.ChangeScene.AddListener(LoadSceneCoroutine);
   }
   
   private void OnDisable()
   {
      Events.ChangeScene.RemoveListener(LoadSceneCoroutine);
   }
}
