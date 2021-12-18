using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer.Unity;

namespace Common
{
    public sealed class ResultSceneLoadButton : MonoBehaviour
    {
        private const string ResultSceneName = "ResultScene";

        [SerializeField] private ProvideTypeConfig config = default;
        
        [SerializeField] private Button loadResultSceneButton = default;

        [SerializeField] private List<GameObject> disableOnAdditive = new List<GameObject>();

        [SerializeField] private LifetimeScope scoreLifetimeScope = default;
        
        private void Awake()
        {
            loadResultSceneButton.onClick.AddListener(LoadResultScene);
        }

        private void OnDestroy()
        {
            loadResultSceneButton.onClick.RemoveListener(LoadResultScene);
        }

        private void LoadResultScene()
        {
            switch (config.ProvideType)
            {
                case ProvideType.Additive:
                    DisableObjectsWhenAdditive();
                    SceneManager.LoadScene(ResultSceneName, LoadSceneMode.Additive);
                    break;
                case ProvideType.VContainer_EnqueueParent:
                    DisableObjectsWhenAdditive();
                    StartCoroutine(LoadSceneAsync());
                    break;
                default:
                    SceneManager.LoadScene(ResultSceneName);
                    break;
            }
        }

        private void DisableObjectsWhenAdditive()
        {
            foreach (var d in disableOnAdditive)
            {
                d.SetActive(false);
            }
        }
        
        private IEnumerator LoadSceneAsync()
        {
            // LifetimeScope generated in this block will be parented by `this.lifetimeScope`
            using (LifetimeScope.EnqueueParent(scoreLifetimeScope))
            {
                // If this scene has a LifetimeScope, its parent will be `parent`.
                var loading = SceneManager.LoadSceneAsync(ResultSceneName, LoadSceneMode.Additive);
                while (!loading.isDone)
                {
                    yield return null;
                }
            }
        }
    }
}