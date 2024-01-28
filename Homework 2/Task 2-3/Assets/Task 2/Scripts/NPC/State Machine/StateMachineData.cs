using System;

public class StateMachineData
{
    public float WorkingTimer;
    public float RestingTimer;

    private float _speed;

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentNullException(value.ToString());

            _speed = value;
        }
    }
}
