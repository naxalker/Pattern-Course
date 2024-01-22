using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlaying == false)
            return;

        EnemySpawner.Instance.SpawnedBalls.Remove(this);
        Destroy(gameObject);
    }
}
