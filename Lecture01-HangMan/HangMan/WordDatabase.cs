using CrypticWizard.RandomWordGenerator;
using static CrypticWizard.RandomWordGenerator.WordGenerator;



namespace HangMan
{
    public class WordDatabase
    {
        protected string[] Words = new string[] { "Car", "Rocket", "Motorbike", "Skateboard" };
        protected Random randomGenerator = new Random();

        static WordGenerator myWordGenerator = new WordGenerator();
        static string word = myWordGenerator.GetWord(PartOfSpeech.noun);

        public string GetRandomWord()
        {
            return word;
        }
    }
}
