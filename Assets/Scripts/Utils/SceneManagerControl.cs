using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Michsky.UI.ModernUIPack;

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


   public async void LoadScene(string nameScene)
   {
      var scene = SceneManager.LoadSceneAsync(nameScene);
      scene.allowSceneActivation = false;

      // TODO: Create animation
      animator.SetTrigger("FadeIn");
      do
      {
         await Task.Delay(100);

         progressBar.currentPercent = scene.progress * 100;
         Debug.Log(scene.progress);
      } while (scene.progress < 0.9f);


      await Task.Delay(1000);

      scene.allowSceneActivation = true;

      animator.SetTrigger("FadeOut");
   }
}
