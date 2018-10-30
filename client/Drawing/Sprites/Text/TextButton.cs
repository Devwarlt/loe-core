namespace LoESoft.Client.Drawing.Sprites.Text
{
    public class TextButton : SpriteNode
    {
        public int Size { get; set; }

        private TextDisplay _textDisplay;

        public TextDisplay TextDisplay
        {
            get => _textDisplay;
            set
            {
                _textDisplay = value;
                Width = _textDisplay.Width;
                Height = _textDisplay.Height;
            }
        }

        public TextButton(string text, int size)
            : base(0, 0, 0, 0)
        {
            Size = size;

            TextDisplay = new TextDisplay(0, 0, text, size);

            TextDisplay.IsEventApplicable = false;

            AddChild(TextDisplay);
        }
    }
}