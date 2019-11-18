using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Dog dog;
    [SerializeField] GameObject hurdles;
  
    enum State
    {
        READY, PLAY, OVER
    }
    State state;
    int score;

    void Start()
    {
        hurdles.SetActive(false);
        state = State.READY;
        dog.SetKinematic(true);
    }
    void Update()
    {
    switch(state)
        {
            case State.READY:
                if(Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;
            case State.PLAY:
                if (dog.IsDead) GameOver();
                break;
            case State.OVER:
                break;
        }
    }

    public void GameStart()
    {
        state = State.PLAY;

        dog.SetKinematic(false);
        hurdles.SetActive(true);
    }
    void GameOver()
    {
        state = State.OVER;

        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        foreach(ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
