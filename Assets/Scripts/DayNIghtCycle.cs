
using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Min(1f)]
    [SerializeField] private float dayDuration = 60f;

    [Range(0f, 1f)]
    [SerializeField] private float startTime = 0f;

    public event Action<float> TimeChanged;

    public float NormalizedTime { get; private set; }

    public int Phase => Mathf.FloorToInt(
        NormalizedTime * 4f
    ) % 4;

    private void Start()
    {
        NormalizedTime = startTime;
        TimeChanged?.Invoke(NormalizedTime);
    }

    private void Update()
    {
        NormalizedTime += Time.deltaTime / dayDuration;

        if (NormalizedTime >= 1f)
            NormalizedTime -= 1f;

        TimeChanged?.Invoke(NormalizedTime);
    }
}
