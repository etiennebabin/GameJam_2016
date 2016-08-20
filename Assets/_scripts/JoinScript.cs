using UnityEngine;
using System.Collections;

using XInputDotNetPure;

public class JoinScript : MonoBehaviour {

    PlayerIndex player_index;
    int nNbPlayerActivated;

    GameObject playerPrefab;
    GameObject playerInstance0;
    GameObject playerInstance1;
    GameObject playerInstance2;
    GameObject playerInstance3;

    bool bJoinPress;
    int[] nJoinedArray;

    // Use this for initialization
    void Start () {
        nNbPlayerActivated = 0;
        bJoinPress = false;

        nJoinedArray = new int[4];
        for (int j = 0; j < 4; j++)
        {
            nJoinedArray[j] = 4;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.LogFormat("OOOOOOH");
        if ((playerInstance0 == null && nNbPlayerActivated == 0) || (playerInstance1 == null && nNbPlayerActivated == 1) || (playerInstance2 == null && nNbPlayerActivated == 2) || (playerInstance3 == null && nNbPlayerActivated == 3))
        {
            for (int i = 0; i < 4; i++)
            {
                Debug.LogFormat("YEAAAAH");
                Debug.LogFormat(((PlayerIndex)i).ToString());
                GamePadState currentState = GamePad.GetState((PlayerIndex) i);

                bool bSkip = false;

                // skip, to not have multiple time the same player
                for (int j = 0; j < 4; j++)
                {
                     if (nJoinedArray[j] == i)
                        bSkip = true;
                }

                if (!bSkip)
                {
                    //check to see if the player pushed the A button
                    if (currentState.Buttons.A == ButtonState.Pressed)
                    {
                        bJoinPress = true;
                    }

                    if (currentState.Buttons.A == ButtonState.Released && bJoinPress)
                    {
                        bJoinPress = false;

                        Debug.LogFormat("SET ITTTTT***********************");
                        Debug.LogFormat(((PlayerIndex)i).ToString());

                        // Set player index
                        switch (i)
                        {
                            case 0:
                                Debug.LogFormat("FIRST");
                                playerInstance0 = GameObject.Find("Girouette");
                                playerInstance0.GetComponent<GirouetteController>().player_index = (PlayerIndex) i;
                                break;
                            case 1:
                                Debug.LogFormat("DOS");
                                playerInstance1 = GameObject.Find("Character (1)");
                                playerInstance1.GetComponent<CharController>().player_index = (PlayerIndex) i;
                                break;
                            case 2:
                                playerInstance2 = GameObject.Find("Character (2)");
                                playerInstance2.GetComponent<CharController>().player_index = (PlayerIndex) i;
                                break;
                            case 3:
                                playerInstance3 = GameObject.Find("Character (3)");
                                playerInstance3.GetComponent<CharController>().player_index = (PlayerIndex) i;
                                break;
                            default:
                                break;
                        }

                        StartCoroutine(Vibrate(0.25f, (PlayerIndex) i - 1));
                        nNbPlayerActivated++;
                    }
                }
            }
        }
        else
        {
            //NOTE:  Doesn't work with some XInput emulated device drivers like the popular PS3 Controller one
            //destroy the player instance if the controller disconnects
           /* if (currentState.IsConnected == false)
            {
                Destroy(playerInstance0);
                return;
            }
            else
            {

                //destroy the player instance if the player pushed the Back button
                if (currentState.Buttons.Back == ButtonState.Pressed)
                {
                    Destroy(playerInstance0);
                    return;
                }
            }*/
        }
    }

    IEnumerator Vibrate(float duration, PlayerIndex p_player)
    {
        GamePad.SetVibration(p_player, 1.0f, 0.0f);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(p_player, 0.0f, 0.0f);
    }
}
