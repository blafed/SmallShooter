using UnityEngine;
[System.Serializable]
public struct MinMax
{
    public float min;
    public float max;
    public float random => Random.Range(min, max);
    public float averagefloat => (min + max) / 2;
    public float average => (min + max) * .5f;
    public float difference => max - min;
    public MinMax(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
    public float Lerp(float t) => Mathf.Lerp(min, max, t);
}