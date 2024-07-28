using System.Collections;
using UnityEngine;

public static class Utils
{
    public static IEnumerator PlayAnimAndSetStateWhenFinished(GameObject parent, Animator animator, string clipName,
        bool activeStateAtTheEnd = true)
    {
        animator.Play(clipName);
        var animationLenght = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLenght);
        parent.SetActive(activeStateAtTheEnd);
    }
}
