using System.Collections;
using Modules.Ticks.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace TEW.Common.Game
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private int _loadingLevel;
        [SerializeField] private GameObject _statusBar;
        private LoadingScene _loadingScene;
        private void OnTriggerEnter(Collider other)
        {
            _loadingScene = Instantiate(_statusBar).GetComponent<LoadingScene>();
            StartCoroutine(LoadAsynchronoysly(_loadingLevel));
        }

        IEnumerator LoadAsynchronoysly(int levelToLoad)
        {
            while (_loadingScene.CheckIsAnimationEnd())
            {
                yield return null;
            }
            
            AsyncOperation loading = Application.LoadLevelAsync(_loadingLevel);
            //TickManager.
            while (!loading.isDone)
            {
                var progress = Mathf.Clamp01(loading.progress / 0.9f);
                _loadingScene.SetSliderValue(progress);
                yield return null;
            }
        }
    }
}
