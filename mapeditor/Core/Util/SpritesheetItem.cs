namespace LoESoft.MapEditor.Core.Util
{
    public class SpritesheetItem
    {
        public int Index { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}