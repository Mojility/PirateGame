using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class MenuRenderer : MonoBehaviour {
    public Canvas canvas;
    public Text bodyText;
    public Text[] options;
    public GameEngineController gameEngineController;
    private int selectedOptionIndex;

    public bool menuIsActive;

    void Start() {
        dismissMenu();
        menuIsActive = false;
    }

    public void dismissMenu() {
        canvas.enabled = false;
        menuIsActive = false;
        gameEngineController.lostInteractable();
    }

    public void showCanvas(Menu menu) {
        canvas.enabled = true;
        menuIsActive = true;
        bodyText.text = menu.introduction;
        selectedOptionIndex = 0;
        highlightCurrentOption();
        clearOptionTexts();
        setOptionTexts(menu);
    }

    private void setOptionTexts(Menu menu) {
        for (int i = 0; i < menu.options.Length; i++) {
            options[i].text = menu.options[i].value;
        }
    }

    private void clearOptionTexts() {
        for (int i = 0; i < options.Length; i++) {
            options[i].text = "";
        }
    }


    public MenuOption.Action activateSelection() {
        return gameEngineController.select(selectedOptionIndex);
    }

    public void moveSelectionDown() {
        if (isNotAtEnd()) {
            selectedOptionIndex++;
            highlightCurrentOption();
        }
    }

    public void moveSelectionUp() {
        if (selectedOptionIndex > 0) {
            selectedOptionIndex--;
            highlightCurrentOption();
        }
    }

    private bool isNotAtEnd() {
        bool lessThanMax = selectedOptionIndex < options.Length - 1;
        bool nextNotBlank = options[selectedOptionIndex + 1].text != "";
        return lessThanMax && nextNotBlank;
    }

    private void LogInfo() {
        Debug.Log("Index = " + selectedOptionIndex);
        Debug.Log("Text = " + options[selectedOptionIndex].text);
    }

    void highlightCurrentOption() {
        for (int i = 0; i < options.Length; i++) {
            if (i == selectedOptionIndex) {
                options[i].color = Color.yellow;
            } else {
                options[i].color = Color.white;
            }
        }
    }
}