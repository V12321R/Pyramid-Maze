
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [Header("ARTEFACT INFORMATION")]

    public string itemName;

    [TextArea(3, 5)]
    public string egyptianFact;

    public Sprite artefactPicture;

    [Header("ACHIEVEMENT MANAGER")]

    public AchievementPopupManager achievementManager;

    private bool collected = false;

    public void Collect()
    {
        // Prevent collecting the same item twice
        if (collected)
            return;

        if (achievementManager == null)
        {
            Debug.LogError(
                "Achievement Manager is not assigned!"
            );
            return;
        }

        collected = true;

        // Send the information to the achievement popup
        achievementManager.ShowAchievement(
            itemName,
            egyptianFact,
            artefactPicture
        );

        // Remove the 3D artefact from the maze
        gameObject.SetActive(false);
    }
}
