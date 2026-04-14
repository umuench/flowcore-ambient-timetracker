namespace FlowCore.Client.Context;

/// <summary>
/// Normiertes Rechteck im Bereich von 0..1.
/// </summary>
public readonly record struct NormalizedRect(double X, double Y, double Width, double Height)
{
    public bool Contains(double normalizedX, double normalizedY)
    {
        return normalizedX >= X
            && normalizedX <= X + Width
            && normalizedY >= Y
            && normalizedY <= Y + Height;
    }
}
