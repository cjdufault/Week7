using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoQuizTwo
{
    public partial class Form1 : Form
    {
        readonly SortedList<string, string> questions = new SortedList<string, string>() // { question, answer }
        {
            { "What is the state capital of California?", "Sacramento" },
            { "What is the tallest mountain on Earth?",  "Everest" },
            { "What country extends the furthest south?", "Chile" }
        };
        List<string> answers = new List<string>();

        DateTime startTime; // the time the quiz starts
        int questionCounter = 0; // keep track of what question we're on
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }  

        private void Form1_Load(object sender, EventArgs e)
        {
            startTime = DateTime.Now; // record the start time
            ShowQuestion();
        }

        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            // check answer and add to list
            string answer = txtAnswer.Text.ToLower();
            CheckAnswer(answer);
            answers.Add(answer);

            // increment counter and show the next question if there are any left, game over if not
            questionCounter++;
            if (questionCounter < questions.Count)
            {
                txtAnswer.Clear();
                ShowQuestion();
            }
            else
            {
                GameOver();
            }
        }

        private void CheckAnswer(string answer)
        {
            string question = questions.Keys[questionCounter];
            string correctAnswer = questions[question];

            // if correct answer is in inputed answer, increment the score
            if (answer.Contains(correctAnswer.ToLower()))
            {
                score++;
                MessageBox.Show($"That's correct!\n\nScore = {score}", "Result");
            }
            else
            {
                MessageBox.Show($"That's wrong! The correct answer is {correctAnswer}.\n\nScore = {score}", "Result");

            }
        }

        // displays the question corresponding to the current state of the questionCounter
        private void ShowQuestion()
        {
            string nextQuestion = questions.Keys[questionCounter];
            lblQuestion.Text = $"Question {questionCounter + 1}:\n{nextQuestion}";
        }

        private void GameOver()
        {
            DateTime endTime = DateTime.Now;
            TimeSpan timeElapsed = endTime.Subtract(startTime);

            StringBuilder builder = new StringBuilder();

            // show all questions, the correct answers, and the player's answers
            for (int i = 0; i < questions.Count; i++)
            {
                string question = questions.Keys[i];
                builder.Append($"{question}\n\tCorrect Answer: {questions[question]}\n\tYour answer: {answers[i]}\n");
            }

            // show final stats
            builder.Append($"\nTime elapsed: {timeElapsed.ToString(@"hh\:mm\:ss")}\n");
            builder.Append($"Final Score: {score}");

            MessageBox.Show(builder.ToString(), "Final Results");

            this.Dispose(); // quit
        }
    }
}
