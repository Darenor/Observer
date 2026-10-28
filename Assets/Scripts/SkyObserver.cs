using UnityEngine;

public class SkyObserver : DayNightObserver
{
    [SerializeField] private SpriteRenderer skyRenderer;

    [Header("Цвета неба")]
    [SerializeField] private Color nightColor =
        new Color(0.02f, 0.04f, 0.18f);

    [SerializeField] private Color morningColor =
        new Color(1f, 0.55f, 0.35f);

    [SerializeField] private Color dayColor =
        new Color(0.35f, 0.75f, 1f);

    [SerializeField] private Color eveningColor =
        new Color(0.9f, 0.3f, 0.25f);

    public override void OnTimeChanged(float time)
    {
        if (skyRenderer == null)
            return;

        if (time < 0.25f)
            skyRenderer.color = Blend(
                nightColor, morningColor, time / 0.25f);
        else if (time < 0.5f)
            skyRenderer.color = Blend(
                morningColor, dayColor, (time - 0.25f) / 0.25f);
        else if (time < 0.75f)
            skyRenderer.color = Blend(
                dayColor, eveningColor, (time - 0.5f) / 0.25f);
        else
            skyRenderer.color = Blend(
                eveningColor, nightColor, (time - 0.75f) / 0.25f);
    }

    private Color Blend(Color from, Color to, float t)
    {
        t = Mathf.SmoothStep(0f, 1f, t);
        return Color.Lerp(from, to, t);
    }
}
