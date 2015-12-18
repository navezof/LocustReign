using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhaseTimer : MonoBehaviour {

    CombatManager combat;

    bool isRunning;
    float timer;
    
    public float phaseDuration;
    public Text text_timer;

    void Awake()
    {
        combat = GetComponent<CombatManager>();
        text_timer.text = "";
    }

    void Update()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;
            text_timer.text = timer.ToString();
            if (timer <= 0)
            {
                combat.EndPhase();
                StopTimer();
            }
        }
    }

    public void ResetTimer()
    {
        text_timer.text = "";
        timer = 0;
    }

    public void StopTimer()
    {
        isRunning = false;
        text_timer.text = "";
    }

    public void StartTimer()
    {
        isRunning = true;
        timer = phaseDuration;
    }

}
