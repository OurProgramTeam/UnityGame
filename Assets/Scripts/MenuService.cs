using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class MenuService : MonoBehaviour, IMenuService
    {
        #region IMenuService members

        public void GoToMenu()
        {
            SceneManager.LoadScene("menu");
        }

        #endregion
    }
}