using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPCView : MonoBehaviour
{
    private const string IsMoving = "isMoving";
    private const string IsWorking = "isWorking";
    private const string IsResting = "isResting";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void StartMoving() => _animator.SetBool(IsMoving, true);
    public void StopMoving() => _animator.SetBool(IsMoving, false);
    public void StartWorking() => _animator.SetBool(IsWorking, true);
    public void StopWorking() => _animator.SetBool(IsWorking, false);
    public void StartResting() => _animator.SetBool(IsResting, true);
    public void StopResting() => _animator.SetBool(IsResting, false);
}
