using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyCollisionSounds : MonoBehaviour
{
    float timer = 0;
    public float cooldown = 0.2f;
    bool hasPlayed = false;

    private void Update() {
        if (hasPlayed) {
            timer += Time.deltaTime;
            if (timer >= cooldown) {
                timer -= cooldown;
                hasPlayed = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (!hasPlayed) {
            int rng = Random.Range(1, 3);
            AudioFW.Play("impact" + rng);
        }
    }
}
