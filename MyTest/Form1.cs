using MyMLApp;
using System.Windows.Forms;

namespace MyTest
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// —\‘ªŒ‹‰Ê
        /// </summary>
        string mlResult = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mlResult = string.Empty;

            SentimentModel.ModelInput sampleData = new SentimentModel.ModelInput();
            sampleData.Col0 = textBox1.Text;

            var sortedScoresWithLabel = SentimentModel.PredictAllLabels(sampleData);

            foreach (var score in sortedScoresWithLabel)
            {
                mlResult += $"{GetScore(score.Key),-40}{GetScore(score.Value) + "%",-20}" + Environment.NewLine;
            }

            textBox2.Text = mlResult;
        }

        private string GetScore(string key)
        {
            if (key == "0")
            {
                return "ˆ«‚¢";
            }
            else
            {
                return "—Ç‚¢";
            }
        }

        private float GetScore(float value)
        {
            return (float)Math.Round(value * 100, 2);
        }
    }
}
