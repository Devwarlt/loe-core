using System.Windows.Forms;

namespace LoESoft.AssetsManager.Core.GUI.HUD
{
    public partial class HelpObject : UserControl
    {
        public string Question
        {
            get => QuestionLabel.Text;
            set => QuestionLabel.Text = value;
        }

        public string Answer
        {
            get => AnswerLabel.Text;
            set => AnswerLabel.Text = value;
        }

        public HelpObject() => InitializeComponent();
    }
}