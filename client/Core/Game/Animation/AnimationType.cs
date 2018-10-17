namespace LoESoft.Client.Core.Game.Animation
{
    public enum AnimationType : byte
    {
        Singular = 0, // For enemies with only 1 type of animation EX: Monsters, Decor entities/tiles
        Forward = 1,
        Backward = 2,
        Left = 3,
        Right = 4,
        Fighting = 5
    }
}