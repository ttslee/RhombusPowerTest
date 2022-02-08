using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;
    public Slider bar;
    public TMP_Text progressText;
    private void Awake() 
    {
        instance = this;
        
        SceneManager.LoadSceneAsync((int)SceneIndexes.TITLESCREEN, LoadSceneMode.Additive);
    }
    
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>(); 
    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLESCREEN));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.GAME, LoadSceneMode.Additive));
        StartCoroutine(GetSceneLoadProgress());
    }
    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        foreach(AsyncOperation a in scenesLoading)
        {
            while(!a.isDone)
            {
                totalSceneProgress = 0;
                yield return null;
                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }
                totalSceneProgress = (totalSceneProgress/scenesLoading.Count) *100f;
            }
        }
        bar.value = Mathf.RoundToInt(totalSceneProgress);
        progressText.text = totalSceneProgress * 100 + "%";
        loadingScreen.gameObject.SetActive(false);
    }
}
