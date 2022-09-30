using UnityEngine;
using CustomEvents;

[System.Serializable]
public class Sit
{
    public Transform sitPosition;
    public GameObject cameraToLook;
    public bool sitPlayer;

}
public class SitPlayer : MonoBehaviour
{
    public Sit sitData = new Sit();
    public GameObject fx;

    private bool _canSit = false;
    private bool _alreadySit = false;
    private float _timeStamp;

    [SerializeField] private float coolDownSecondsSit = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canSit = true;
            // TODO: manager actions

            // SitPlayer sitPlayer = other.gameObject.GetComponent<SitPlayer>();
            // Debug.Log(sitPlayer.sitPosition);
            fx.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _canSit = false;
        fx.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && _canSit && !_alreadySit && (_timeStamp <= Time.time))
        {
            sitData.sitPlayer = true;
            Debug.Log("Se sienta");
            Events.SitPlayer.Invoke(sitData);
            _alreadySit = true;
            _timeStamp = Time.time + coolDownSecondsSit;
        }
        
        if (Input.GetKey(KeyCode.E) && _canSit && _alreadySit && (_timeStamp <= Time.time))
        {
            sitData.sitPlayer = false;
            Debug.Log("Se levanta");
            Events.SitPlayer.Invoke(sitData);
            _alreadySit = false;
            _timeStamp = Time.time + coolDownSecondsSit;
        }
    }
}
