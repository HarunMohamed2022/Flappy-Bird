namespace Flappy_bird
{
    public partial class Form1 : Form
    {
        int pipespeed = 8;
        int gravity = 15;
        int score=0;    
        public Form1()
        {
            InitializeComponent();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            pipeBottom.Left -= pipespeed;
            pipeTop.Left -= pipespeed;
            ScoreText.Text = "Score: "+ score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }

            if (FlappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(Ground.Bounds)
                )
            {
                endgame();
            }

            if (score > 5)
            {
                pipespeed = 15;
            }

            if (FlappyBird.Top < -25)
            {
                endgame();
            }

        }

        private void GameKeyDowm(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endgame()
        {
            gametimer.Stop();
            ScoreText.Text += "GameOver";
        }
    }
}