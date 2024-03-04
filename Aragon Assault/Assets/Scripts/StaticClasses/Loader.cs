using UnityEngine.SceneManagement;

public static class Loader {

    public static void RestartLevel() {
        int currentSceneID = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneID);
    }
}