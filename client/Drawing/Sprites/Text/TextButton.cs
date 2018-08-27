using LoESoft.Client.Drawing.Sprites.Text;

namespace LoESoft.Client.Drawing.Sprites.Text
{
    public class TextButton : SpriteNode
    {
        private string _text;
        public string Text
        {
            get => _text; set
            {
                _text = value;

                var mesurements = TextDisplay.MeasureString(_text, Size);
                Width = (int)mesurements.X + 10;
                Height = (int)mesurements.Y + 10;

                TextDisplay = new TextDisplay(5, 5, _text, Size);
            }
        }
        public int Size { get; set; }

        public TextDisplay TextDisplay { get; set; }

        public TextButton(string text, int size)
            : base(0, 0, 0, 0)
        {
            Size = size;
            Text = text;

            AddChild(TextDisplay);
        }
    }
}
