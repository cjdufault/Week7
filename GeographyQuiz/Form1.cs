using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeographyQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            string answer = txtAnswer.Text.ToLower();
            bool containsWrongAnswer = CheckContainsWrongAnswer(answer);

            if (answer.Contains("pacific") && !containsWrongAnswer)
            {
                MessageBox.Show("Correct! The Pacific Ocean is the largest ocean.", "Result");
            }
            else
            {
                MessageBox.Show("Sorry, the correct answer is the Pacific Ocean.", "Result");
            }
        }

        private bool CheckContainsWrongAnswer(string answer)
        {
            bool containsWrongAnswer = false;
            string[] wrongAnswers = { "antarctic", "arctic", "atlantic", "indian", "southern" };

            foreach (string wrongAnswer in wrongAnswers)
            {
                if (answer.Contains(wrongAnswer))
                {
                    containsWrongAnswer = true;
                    break;
                }
            }

            return containsWrongAnswer;
        }
    }
}
