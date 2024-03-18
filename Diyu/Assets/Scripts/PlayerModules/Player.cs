using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    /*
     Contains every player module.
     */

    // Declare the player modules
    public GameObject Body;
    //public EntityIdentity Identity = new EntityIdentity(TypesEnum.Player,100); // Parameters: type, health/maxHealth
    public PlayerTeam Team = new PlayerTeam();

    public GameObject PlayerUI;


    // Start is called before the first frame update
    void Start()
    {
        PlayerUI.gameObject.GetComponent<MyNetworkRoomPlayer>().SetIndex(GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Hide or show the player body
    public void SetBodyVisibility(bool visible)
    {
        Body.SetActive(visible);
    }
}
