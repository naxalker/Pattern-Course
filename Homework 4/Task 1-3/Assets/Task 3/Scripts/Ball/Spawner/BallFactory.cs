using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace sceneloader
{
    [CreateAssetMenu(fileName = "BallFactory", menuName = "Factory/BallFactory")]
    public class BallFactory : ScriptableObject
    {
        [SerializeField] private Ball _ballPrefab;

        public Ball Get(BallType type)
        {
            Ball ball = Instantiate(_ballPrefab);
            ball.Initialize(type, GetColor(type));
            ball.transform.localScale *= Random.Range(.8f, 1.2f);

            return ball;
        }

        private Color GetColor(BallType type)
        {
            switch (type)
            {
                case BallType.Red:
                    return Color.red;

                case BallType.Green:
                    return Color.green;

                case BallType.Yellow:
                    return Color.yellow;

                default:
                    throw new ArgumentException(nameof(type));
            }
        }
    }
}