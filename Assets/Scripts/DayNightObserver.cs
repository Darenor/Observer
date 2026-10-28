using UnityEngine;

public abstract class DayNightObserver : MonoBehaviour,
    IDayNightObserver
{
    [SerializeField] protected DayNightCycle cycle;

    protected virtual void OnEnable()
    {
        if (cycle == null)
            cycle = FindFirstObjectByType<DayNightCycle>();

        if (cycle != null)
            cycle.TimeChanged += OnTimeChanged;
    }

    protected virtual void Start()
    {
        if (cycle != null)
            OnTimeChanged(cycle.NormalizedTime);
    }

    protected virtual void OnDisable()
    {
        if (cycle != null)
            cycle.TimeChanged -= OnTimeChanged;
    }

    public abstract void OnTimeChanged(float normalizedTime);
}
