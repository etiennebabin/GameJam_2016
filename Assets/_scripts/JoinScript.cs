using UnityEngine;
using System.Collections;

using XInputDotNetPure;

public class JoinScript : MonoBehaviour {

    public GameManager gameManager;
    private PlayerIndex player_index;

    public GameObject playerPrefab;
    public GameObject playerInstance;

    // Use this for initialization
   /* void Start () {
        player_index = gameManager.GetPlayerIndex();
    }
	
	// Update is called once per frame
	void Update () {
        GamePadState currentState = GamePad.GetState(player_index);

        if (playerInstance == null)
        {
            //check to see if the player pushed the A button
            if (currentState.Buttons.A == ButtonState.Pressed)
            {
                playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, transform.rotation);
                playerInstance.GetComponent<CharacterControllerPotatoe>().playerIndex = player_index;
                StartCoroutine(Vibrate(0.25f));
            }
        }
        else
        {
            //NOTE:  Doesn't work with some XInput emulated device drivers like the popular PS3 Controller one
            //destroy the player instance if the controller disconnects
            if (currentState.IsConnected == false)
            {
                Destroy(playerInstance);
                return;
            }
            else
            {

                //destroy the player instance if the player pushed the Back button
                if (currentState.Buttons.Back == ButtonState.Pressed)
                {
                    Destroy(playerInstance);
                    return;
                }

                if (currentState.PacketNumber > lastPacketNumber)
                {
                    lastPacketNumber = currentState.PacketNumber;
                    lastPacketTime = Time.time;
                }
                else
                {
                    //NOTE:  Doesn't work with some XInput emulated device drivers like the popular PS3 Controller one
                    if (Time.time - lastPacketTime > 20)
                    {
                        //controller has been idle for 20 seconds
                        StartCoroutine(Vibrate(0.5f));
                        Destroy(playerInstance);
                    }
                }

            }
        }
    }

    IEnumerator Vibrate(float duration)
    {
        GamePad.SetVibration(player_index, 1.0f, 0.0f);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(player_index, 0.0f, 0.0f);
    }*/
}
