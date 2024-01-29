using UnityEditor;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem;
using UnityEngine;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif

[DisplayStringFormat("{Negative}+{Positive} / {Speedup}+{Slowdown}")]
public class CustomComposite : InputBindingComposite<float>
{
    [InputControl(layout = "Button")]
    public int Negative;

    [InputControl(layout = "Button")]
    public int Positive;
    
    [InputControl(layout = "Button")]
    public int Speedup;

    [InputControl(layout = "Button")]
    public int Slowdown;

    public override float ReadValue(ref InputBindingCompositeContext context)
    {
        float value = 0f;

        var negativeValue = context.ReadValue<float>(Negative);
        var positiveValue = context.ReadValue<float>(Positive);
        var speedUpValue = context.ReadValue<float>(Speedup);
        var slowdownValue = context.ReadValue<float>(Slowdown);

        Debug.Log(negativeValue + " " + positiveValue);

        if (positiveValue == 1)
            value = 1f;
        else if (negativeValue == 1)
            value = -1f;

        if (speedUpValue == 1)
            value *= 2f;
        else if (slowdownValue == 1)
            value /= 2f;

        return value;
    }

    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
        return ReadValue(ref context) + 2f / 4f;
    }

    static CustomComposite()    
    {
        InputSystem.RegisterBindingComposite<CustomComposite>();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init() { }
}