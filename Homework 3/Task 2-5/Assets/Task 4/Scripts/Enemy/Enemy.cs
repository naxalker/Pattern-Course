﻿using System;
using UnityEngine;

namespace Assets.Visitor
{
    public abstract class Enemy: MonoBehaviour
    {
        public event Action<Enemy> Died;

        //Какая то общая логика врага: передвижение, жизни и тп.

        public void MoveTo(Vector3 position) => transform.position = position + new Vector3(0f, 1f, 0f);

        public void Kill()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
