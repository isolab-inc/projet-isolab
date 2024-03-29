using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GreenDoor : MonoBehaviour
{
    
    public float speed = 3;
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject door_;
    public float smoothTime = 0.5f;
    public bool key = false;
    [SerializeField] public SightZone sketuve = null;
    public bool caca = false;

    // Start is called before the first frame update
    void Start()
    {
        door_ = this.gameObject;
        sketuve = GetComponentInChildren<SightZone>();
        sketuve.onStay += Open;
        sketuve.onEnter += Open;
    }
    void Open(GameObject player)
    {
        PlayerBody pb = player.gameObject.GetComponent<PlayerBody>();
        if (pb.GetGreenKey && Input.GetKeyDown(KeyCode.E))
        {
            
            door_.transform.Translate(-1 * transform.up * speed * Time.deltaTime);
            key = true;
            caca = true;
            pb.GetGreenKey = false;
            Debug.Log("test");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (caca)
        {
            door_.transform.Translate(-1 * transform.up * speed * Time.deltaTime);
        }
    }
}

