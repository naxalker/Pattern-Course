using System;
using UnityEngine;

namespace sceneloader
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Ball : MonoBehaviour
    {
        public event Action<Ball> Popped;

        private BallType type;

        public void Initialize(BallType type, Color color)
        {
            this.type = type;
            GetComponent<MeshRenderer>().material.color = color;
        }

        public BallType Type => type;

        private void OnMouseDown()
        {
            Popped?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
