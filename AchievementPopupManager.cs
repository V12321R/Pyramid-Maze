
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementPopupManager : MonoBehaviour
{
    [Header("POPUP PANEL")]
    public GameObject popupPanel;

    [Header("ACHIEVEMENT TEXT")]
    public TMP_Text achievementTitle;
    public TMP_Text itemNameText;
    public TMP_Text achievementMessage;

    [Header("HISTORICAL FACT")]
    public TMP_Text factTitle;
    public TMP_Text factMessage;

    [Header("ARTEFACT PHOTOGRAPH")]
    public Image itemImage;

    [Header("CONTINUE BUTTON")]
    public Button continueButton;

    private float previousTimeScale;
    private bool popupOpen = false;

    void Start()
    {
        popupPanel.SetActive(false);

        continueButton.onClick.AddListener(ClosePopup);
    }

    public void ShowAchievement(
        string itemName,
        string fact,
        Sprite artefactPicture)
    {
        if (popupOpen)
            return;

        popupOpen = true;

        // Display the popup
        popupPanel.SetActive(true);

        // Display the achievement
        achievementTitle.text = "ACHIEVEMENT UNLOCKED!";

        // Display the artefact name
        itemNameText.text = itemName;

        // Display congratulations message
        achievementMessage.text =
            "Congratulations! You've found " + itemName + "!";

        // Display historical fact
        factTitle.text = "DID YOU KNOW?";

        factMessage.text = fact;

        // Display actual artefact photograph
        itemImage.sprite = artefactPicture;

        itemImage.preserveAspect = true;

        itemImage.gameObject.SetActive(
            artefactPicture != null
        );

        // Pause the game
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;

        // Show the mouse cursor for the button
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ClosePopup()
    {
        if (!popupOpen)
            return;

        popupPanel.SetActive(false);

        popupOpen = false;

        // Resume the game
        Time.timeScale = previousTimeScale;

        // Return cursor control to the player
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

