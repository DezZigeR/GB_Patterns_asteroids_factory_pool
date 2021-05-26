using UnityEngine;

namespace General
{
    [CreateAssetMenu(fileName = "UiConfig", menuName = "Configs/UiConfig", order = 0)]
    public class UiConfig : ScriptableObject
    {
        public GameObject score;
        public GameObject destroyedEnemies;
        public GameObject endGame;
        public GameObject pauseMenu;
    }
}