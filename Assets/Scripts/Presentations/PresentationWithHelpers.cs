using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Serialization;

public class PresentationWithHelpers : NetworkBehaviour
{
    [SerializeField] private Sprite[] _diapositive;

    [SerializeField] private SpriteRenderer spriteRendererPresentation;

    [SerializeField] private SpriteRenderer spriteRendererNext;
    [SerializeField] private SpriteRenderer spriteRendererPrev;
    // Start is called before the first frame update

    [SyncVar]
    public int currentDiapositive;
    private int _maxDiapositive = 0;

    void Start()
    {
        spriteRendererPresentation.sprite = _diapositive[currentDiapositive | 0];
        _maxDiapositive = _diapositive.Length;
    }


    [ClientRpc]
    public void NextDiapositive()
    {
        if (currentDiapositive + 1 < _maxDiapositive)
        {
            currentDiapositive++;
            spriteRendererPresentation.sprite = _diapositive[currentDiapositive];

            SetNextHelper();
            SetPreHelper();
        }
    }


    [ClientRpc]
    public void PrevDiapositive()
    {
        if (currentDiapositive - 1 >= 0)
        {
            Debug.Log("Change");
            currentDiapositive--;
            spriteRendererPresentation.sprite = _diapositive[currentDiapositive];
            SetNextHelper();
            SetPreHelper();
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

    private void SetNextHelper()
    {
        spriteRendererNext.sprite = currentDiapositive + 1 < _maxDiapositive ? _diapositive[currentDiapositive + 1] : null;
    }

    private void SetPreHelper()
    {
        if (currentDiapositive - 1 >= 0)
        {
            spriteRendererPrev.sprite = _diapositive[currentDiapositive - 1];
        }
        else
        {
            spriteRendererPrev.sprite = null;
        }
    }
}
