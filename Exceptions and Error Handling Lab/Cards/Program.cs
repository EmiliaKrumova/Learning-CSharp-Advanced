namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] pairs = Console.ReadLine().Split(", ");

            List<Card> cards = new List<Card>();

            for (int i = 0; i < pairs.Length; i++)
            {
                string[] currPair = pairs[i].Split();
                string currFace = currPair[0];
                string currSuit = currPair[1];

                try
                {
                    Card card = new Card(currFace, currSuit);
                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
                
            }

            foreach (Card card in cards)
            {
                Console.Write(card.ToString());
            }
        }
    }

  


    public class Card
    {


        private string face;
        private string suit;
       
        
        // задавам предварително възможни стойности за "Боя" и "Карта"


        private static readonly List<string> Faces = new List<string> 
        { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };


        private static readonly Dictionary<string, string> Suits = new Dictionary<string, string>

        {
            { "S", "\u2660" }, { "H", "\u2665" }, { "D", "\u2666" }, { "C", "\u2663" }
            // Unicode стойности на "спатия, купа, каро и пика"
        };


        public Card(string face, string suit)
        {
            Face = face; Suit = suit;

        }



        public string Face
        {
            get
            {
                return face;
            }
            set
            {
                if (!Faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");

                }
                face = value;
            }

        }



        public string Suit
        {
            get { return suit; }
            set
            {
                if (!Suits.Keys.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = Suits[value];//!!!
                // по този начин бъркам в речника от "боите" на картите
                // и взимам предварително заложената Unicode стойност като Value от речника
            }
        }
        public override string ToString()
        {
            return $"[{Face}{Suit}] ";
        }

    }
}