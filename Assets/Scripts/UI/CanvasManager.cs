using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

public class CanvasManager : MonoBehaviour
{
    public float intervalActions = 0.5f;
    
    #region Audio
    
    [SerializeField] private Sprite onStateMic;
    [SerializeField] private Sprite offStateMic;
    [SerializeField] private Image micImage;

    private TestHome _testHome;
    private bool _currentStateAudio = false;
    
    
    #endregion

    #region General

    [SerializeField] private GameObject menuObject;
    private ChatManager _chatManager;
    private bool _isLock = false;

    
    #endregion

    #region Timers Cooldown
    private float _timeActions;
    private float _timeMuted;

    #endregion


    #region Input
    private PlayerInputs _playerInputs;
    #endregion
    
    void Start()
    {
        _testHome = FindObjectOfType<TestHome>();
        _chatManager = FindObjectOfType<ChatManager>();
    }

    
    void Update()
    {
        #region Mouse
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ShowCursor();
            PlayerData.InMenus = true;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            HideCursor();
            PlayerData.InMenus = false;
        }
        #endregion

        #region Chat

        if (Input.GetKey(KeyCode.Escape) && Time.time > _timeActions)
        {
            if (_chatManager.openChat)
            {
                _chatManager.ControlOpenChat();
                PlayerData.InChat = false;
            }
            else
            {
                menuObject.SetActive(true);
                PlayerData.InMenus = true;
                ShowCursor();
            }
            
            
            _timeActions = Time.time + intervalActions;

        }
        // Open chat
        if (Input.GetKey(KeyCode.C) && Time.time > _timeActions && !_chatManager.openChat)
        {
            _chatManager.ControlOpenChat();
            _timeActions = Time.time + intervalActions;
            PlayerData.InChat = true;
        }
        
        // Send Message chat

        if (Input.GetKey(KeyCode.Return) && _chatManager.openChat)
        {
            _chatManager.SendMessage();
        }

        #endregion
        
        
        // Mic
        if (!Input.GetKey(KeyCode.V) || !(Time.time > _timeMuted)) return;
        micImage.sprite = _currentStateAudio ? onStateMic : offStateMic;
        _testHome.MuteAudio(_currentStateAudio);
        _currentStateAudio = !_currentStateAudio;
        _timeMuted = Time.time + 0.5f;
        // --
        
        
        
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _isLock = true;
    }
    
    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _isLock = false;
    }


    public void CloseMenu()
    {
        menuObject.SetActive(false);
        PlayerData.InMenus = false;
    }
}
