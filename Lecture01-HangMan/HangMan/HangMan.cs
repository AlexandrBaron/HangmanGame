namespace HangMan
{
    public class Hangman
    {
        public int Lives { private set; get; } = 5;

        private string image = " _____\n" +
                               " |/\n" +
                               " |\n" +
                               " |\n" +
                               " |\n" +
                               " |\n" +
                               " |\n" +
                               "========\n";

        public void RemoveOneLive()
        {
            if (Lives > 0)
            {
                Lives--;

            }
        }


        private void UpdateImage()
        {
            switch (Lives)
            {
                case 0:
                    image = " _____\n" +
                            " |/  |\n" +
                            " |   0\n" +
                            " |  -O-\n" +
                            " |   \" \n" +
                            " |\n" +
                            " |\n" +
                            "========\n";
                    break;

                case 1:
                    image = " _____\n" +
                            " |/  |\n" +
                            " |   0\n" +
                            " |  -O-\n" +
                            " |\n" +
                            " |\n" +
                            " |\n" +
                            "========\n";
                    break;

                case 2:
                    image = " _____\n" +
                            " |/  |\n" +
                            " |   0\n" +
                            " |  -O\n" +
                            " |\n" +
                            " |\n" +
                            " |\n" +
                            "========\n";
                    break;

                case 3:
                    image = " _____\n" +
                            " |/  |\n" +
                            " |   0\n" +
                            " |   O\n" +
                            " |\n" +
                            " |\n" +
                            " |\n" +
                            "========\n";
                    break;

                case 4:
                    image = " _____\n" +
                            " |/  |\n" +
                            " |   0\n" +
                            " |\n" +
                            " |\n" +
                            " |\n" +
                            " |\n" +
                            "========\n";
                    break;

                case 5:
                    image = " _____\n" +
                            " |/  |\n" +
                            " |\n" +
                            " |\n" +
                            " |\n" +
                            " |\n" +
                            " |\n" +
                            "========\n";
                    break;
            }
        }

        public void Draw()
        {
            UpdateImage();
            Console.Write(image);
        }

        public bool GameOverCheck()
        {
            return Lives == 0;
        }

    }
}
