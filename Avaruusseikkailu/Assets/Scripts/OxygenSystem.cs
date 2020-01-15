using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSystem : MonoBehaviour, IOxygen
{
    public bool usingOxygen;
    public int minutesLeft;
    public int secondsLeft;
    public int maxOxygenMinutes = 3;
    public bool testing;
    float timer;
    bool ranOutOfAir = false;
    void Start()
    {
        secondsLeft = 0;
        minutesLeft = maxOxygenMinutes;
    }

    void Update()
    {
        if (!usingOxygen) {
            return;
        } else {
            if (ranOutOfAir) {
                print("Dead: Ran out of oxygen");
                return;
            }
            ClampMaxValues();
            if (secondsLeft < 0) {
                minutesLeft--;
                secondsLeft = 59;
            }
            timer += Time.deltaTime;
            if (timer >= 1f) {
                timer -= 1f;
                secondsLeft--;
            }
            if (minutesLeft <= 0 && secondsLeft <= 0) {
                ranOutOfAir = true;
            }
            if (testing) {
                TestAddOxygen();
                if (secondsLeft < 10) {
                    print(minutesLeft + ":" + "0" + secondsLeft);
                } else
                    print(minutesLeft + ":" + secondsLeft);
            }
        }
    }

    public void AddOxygen(int amount) {
        secondsLeft += amount;
        if (secondsLeft > 59) {
            minutesLeft++;
            secondsLeft -= 60;
            if (minutesLeft >= maxOxygenMinutes) {
                minutesLeft = maxOxygenMinutes;
                secondsLeft = 0;
                timer = 0;
            }
        }
    }

    void ClampMaxValues() {
        if (minutesLeft > maxOxygenMinutes) {
            minutesLeft = maxOxygenMinutes;
        }
        if (minutesLeft == maxOxygenMinutes && secondsLeft > 0) {
            secondsLeft = 0;
        }
        if (secondsLeft > 59) {
            secondsLeft = 0;
            minutesLeft++;
        }
    }

    void TestAddOxygen() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            AddOxygen(15);
        }
    }
}
