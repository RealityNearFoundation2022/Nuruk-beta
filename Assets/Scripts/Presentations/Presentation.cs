using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

public class Presentation : NetworkBehaviour
{
   [SerializeField] private Sprite[] _diapositive;

   [SerializeField] private SpriteRenderer spriteRendererPresentation;
   // Start is called before the first frame update

   [SyncVar]
   public int _currentDiapositive;
   private int _maxDiapositive = 0;

   void Start()
   {
      spriteRendererPresentation.sprite = _diapositive[_currentDiapositive | 0];
      _maxDiapositive = _diapositive.Length;
   }


   [ClientRpc]
   public void NextDiapositive()
   {
      if (_currentDiapositive + 1 < _maxDiapositive)
      {
         _currentDiapositive++;
         spriteRendererPresentation.sprite = _diapositive[_currentDiapositive];
      }
   }


   [ClientRpc]
   public void PrevDiapositive()
   {
      if (_currentDiapositive - 1 >= 0)
      {
         Debug.Log("Change");
         _currentDiapositive--;
         spriteRendererPresentation.sprite = _diapositive[_currentDiapositive];
      }

   }

   [Command(requiresAuthority = false)]
   public void ChangeNext()
   {
      NextDiapositive();
   }


   [Command(requiresAuthority = false)]
   public void ChangePrev()
   {
      PrevDiapositive();
   }
}
