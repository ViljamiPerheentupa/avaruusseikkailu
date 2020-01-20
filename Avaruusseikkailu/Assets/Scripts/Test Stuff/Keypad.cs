using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Keypad : MonoBehaviour, IKeypad
{
    public bool testing;
    List<int> inputs = new List<int>();
    public int pass1;
    public int pass2;
    public int pass3;
    public int pass4;
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
        if (testing) {
            print(pass1 + "" + pass2 + "" + pass3 + "" + pass4);
        }
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
            AddKey(1);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            AddKey(2);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            AddKey(3);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            AddKey(4);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            AddKey(5);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            AddKey(6);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            AddKey(7);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8)) {
            AddKey(8);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9)) {
            AddKey(9);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            AddKey(0);
            return;
        }
    }

    public void AddKey(int num) {
        inputs.Add(num);
        int rng = Random.Range(1, 4);
        AudioFW.Play("button" + rng);
    }
}
