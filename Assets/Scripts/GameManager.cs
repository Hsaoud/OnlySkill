using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GUIStyle ScoreStyle = new GUIStyle();
    public Texture2D black;
    public Texture2D RepeatButtonTexture;
    public bool IsGameRunning = true;

    private string Score;
    private float ScreenHeight;
    private float ScreenWidth;
    private Color halfFade;
    private Color noFade;

    
    void Start() {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        ScreenHeight = Screen.height;
        ScreenWidth = Screen.width;
        IsGameRunning = true;
        halfFade = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 0.5f);
        noFade = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 1.0f);
    }

    private void OnGUI() {
        if (IsGameRunning) {
            DrawIngameScore();
        }
        else {
            DrawEndGameUI();
        }
    }

    private void DrawEndGameUI() {
        ScoreStyle.fontSize = 60;
        ScoreStyle.alignment = TextAnchor.MiddleCenter;

        DrawEndGameBackground();
        DrawEndGameScore();
        DrawReplayButton();
    }

    private void DrawReplayButton() {
        GUI.skin.button.normal.background = RepeatButtonTexture;
        GUI.skin.button.hover.background = RepeatButtonTexture;
        GUI.skin.button.active.background = RepeatButtonTexture;
        if (GUI.Button(new Rect(ScreenWidth * 2 / 8, ScreenHeight * 7 / 10, 2 * ScreenWidth / 9, ScreenHeight * 2 / 10), "")) {
            RestartCurrentScene();
        }
    }

    private void DrawEndGameBackground() {
        GUI.color = halfFade;
        GUI.DrawTexture(new Rect(0, 0, ScreenWidth, ScreenHeight), black, ScaleMode.StretchToFill);
        GUI.color = noFade;
    }

    private void DrawIngameScore() {
        Score = Time.timeSinceLevelLoad.ToString("F2");
        ScoreStyle.normal.textColor = Color.green;
        GUI.Label(new Rect(ScreenWidth / 2, 0, ScreenWidth / 2, ScreenHeight / 32), "Score", ScoreStyle);
        ScoreStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(ScreenWidth / 2, 0, ScreenWidth / 2, ScreenHeight / 10), Score, ScoreStyle);
    }

    public void DrawEndGameScore() {
        ScoreStyle.normal.textColor = Color.green;
        GUI.Label(new Rect(ScreenWidth / 4, ScreenHeight / 32, ScreenWidth / 2, ScreenHeight / 6), "Score", ScoreStyle);
        ScoreStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(ScreenWidth / 4, ScreenHeight / 10, ScreenWidth / 2, ScreenHeight / 4), Score, ScoreStyle);
    }

    public void RestartCurrentScene() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void PlayerTouched(Collision2D collision) {
        IsGameRunning = false;
    }

}
