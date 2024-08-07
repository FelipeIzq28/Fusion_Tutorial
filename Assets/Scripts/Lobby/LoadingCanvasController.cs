using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button cancelBtn;
    private NetworkRunnerController networkRunnerController;
    private void Start()
    {
        networkRunnerController = GlobalManagers.Instance.networkRunnerController;
        networkRunnerController.OnStartedRunnerconnection += OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSuccesfully += OnPlayerJoinedSuccesfully;

        cancelBtn.onClick.AddListener(networkRunnerController.ShutDownRunner);
        this.gameObject.SetActive(false);
    }

    private void OnPlayerJoinedSuccesfully()
    {
        const string CLIP_NAME = "Out";
        StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject, animator, CLIP_NAME, false));
    }

    private void OnStartedRunnerConnection()
    {
        this.gameObject.SetActive(true);
        const string CLIP_NAME = "In";
        StartCoroutine(Utils.PlayAnimAndSetStateWhenFinished(gameObject, animator, CLIP_NAME));
    }

    private void OnDestroy()
    {
        networkRunnerController.OnStartedRunnerconnection -= OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSuccesfully -= OnPlayerJoinedSuccesfully;
    }
}
