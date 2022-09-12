using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ChatManager : MonoBehaviour
{
    public bool openChat = false;

    [SerializeField] private Animator _animatorChat;
    [SerializeField] private TMP_InputField _inputField;
    private static readonly int Open = Animator.StringToHash("open");
    
    public UnityEvent eventsChat;

    public void ControlOpenChat()
    {
        _animatorChat.SetBool(Open, !openChat);
        openChat = !openChat;
        if (openChat)
        {
            _inputField.Select();
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void SendMessage()
    {
        eventsChat.Invoke();
    }
}
