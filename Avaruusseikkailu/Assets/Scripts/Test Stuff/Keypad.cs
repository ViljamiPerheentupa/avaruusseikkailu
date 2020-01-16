using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public bool testing;
    List<int> inputs = new List<int>();
    int pass1;
    int pass2;
    int pass3;
    int pass4;
    public Text inputText;
    bool stopTakingInput = false;
    int correctInputs = 0;
    public float incorrectTime = 2f;
    float timer = 0;
    float checkTimer = 0;
    bool wrong = false;
    public UnityEvent onCorrect;
    public UnityEvent onFail;

    void Start()
    {
        pass1 = Random.Range(0, 10);
        pass2 = Random.Range(0, 10);
        pass3 = Random.Range(0, 10);
        pass4 = Random.Range(0, 10);
        print(pass1 + "" + pass2 + "" + pass3 + "" + pass4);
    }


    void Update()
    {
        if (wrong) {
            Wrong();
        }
        if (inputs.Count >= 4) {
            stopTakingInput = true;
            CheckKeys();
        }
        if (!stopTakingInput) {
            if (testing) {
                GetInput();
            }
            UpdateKeypad();
        }
    }

    void CheckKeys() {
        checkTimer += Time.deltaTime;
        if (checkTimer >= 0.2f) {
            checkTimer = 0;
        } else return;
        if (inputs[0] == pass1) {
            correctInputs++;
        }
        if (inputs[1] == pass2) {
            correctInputs++;
        }
        if (inputs[2] == pass3) {
            correctInputs++;
        }
        if (inputs[3] == pass4) {
            correctInputs++;
        }
        if (correctInputs == 4) {
            correctInputs = 0;
            Correct();
            return;
        } else {
            correctInputs = 0;
            wrong = true;
            return;
        }
    }

    void Correct() {
        inputText.text = "Correct!";
        onCorrect.Invoke();
        return;
    }

    void Wrong() {
        inputs.Clear();
        inputText.text = "Wrong!";
        onFail.Invoke();
        timer += Time.deltaTime;
        if (timer >= incorrectTime) {
            timer = 0;
            wrong = false;
            inputText.text = ". . . .";
            stopTakingInput = false;
            return;
        }
    }

    void UpdateKeypad() {
        if (inputs.Count == 1) {
            inputText.text = "" + inputs[0] + " . . .";
        }
        if (inputs.Count == 2) {
            inputText.text = "" + inputs[0] + "" + inputs[1] + ". .";
        }
        if (inputs.Count == 3) {
            inputText.text = "" + inputs[0] + "" + inputs[1] + "" + inputs[2] + " .";
        }
        if (inputs.Count == 4) {
            inputText.text = "" + inputs[0] + "" + inputs[1] + "" + inputs[2] + "" + inputs[3];
        }
    }

    void GetInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            inputs.Add(1);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            inputs.Add(2);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            inputs.Add(3);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            inputs.Add(4);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            inputs.Add(5);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            inputs.Add(6);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            inputs.Add(7);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            inputs.Add(8);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            inputs.Add(9);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            inputs.Add(0);
            return;
        }
    }
}
