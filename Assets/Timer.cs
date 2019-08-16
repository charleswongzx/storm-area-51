using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int totalTimerSeconds;
    bool gameEnded = false;
    float timeLeft;
    Text currentTimerText;

    // Start is called before the first frame update
    void Start()
    {
        currentTimerText = gameObject.GetComponent<Text>();
        timeLeft = totalTimerSeconds + 5;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        string minSec = string.Format("{0}:{1:00}", (int)timeLeft / 60, (int)timeLeft % 60);
        currentTimerText.text = minSec;

        if (timeLeft < 0 && !gameEnded)
        {
            gameEnded = !gameEnded;
            GameObject castleMultiplayer = GameObject.Find("Castle (multiplayer)(Clone)");

            // fetch castle object
            CastleMultiplayer castleController = castleMultiplayer.GetComponent<CastleMultiplayer>();
            float masterStrength = castleController.masterCastleStrength;
            float clientStrength = castleController.clientCastleStrength;

            // compare strengths to determine winner
            if (masterStrength > clientStrength)
            {
                castleController.EndBattle(true);
            } else
            {
                castleController.EndBattle(false);
            }
        }
    }
}
