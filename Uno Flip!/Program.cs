using System.Collections;

namespace uno_flip
{   
    public class GlobalVars{
        public static Card[] cards = [
            // full card list, according to https://boardgamegeek.com/thread/2731732/uno-flip-card-list
            // there are 112 cards in total

            new Card(0, 1,  4, 4),
            new Card(0, 1,  4, 7),
            new Card(0, 1,  3, 2),
            new Card(0, 1,  2, 9),

            new Card(0, 0,  3, 5),
            new Card(0, 0,  3, -4),
            new Card(0, 0,  2, 7),
            new Card(0, 0,  1, 3),

            new Card(4, 1,  2, -2),
            new Card(4, 1,  2, -2),
            new Card(4, 2,  4, 8),
            new Card(4, 2,  3, 6),
            new Card(4, 3,  2, 8),
            new Card(4, 3,  1, 2),
            new Card(4, 4,  2, 1),
            new Card(4, 4,  1, 5),
            new Card(4, 5,  4, -1),
            new Card(4, 5,  3, 9),
            new Card(4, 6,  2, -1),
            new Card(4, 6,  1, -2),
            new Card(4, 7,  4, 3),
            new Card(4, 7,  4, -2),
            new Card(4, 8,  1, 4),
            new Card(4, 8,  1, -1),
            new Card(4, 9,  4, 5),
            new Card(4, 9,  2, -4),
            new Card(4, -3, 3, 6),
            new Card(4, -3, 1, 6),
            new Card(4, -4, 2, 6),
            new Card(4, -4, 2, 7),
            new Card(4, -1, 4, 4),
            new Card(4, -1, 0, 0),
            new Card(4, -2, 3, 9),
            new Card(4, -2, 1, 1),

            new Card(3, 1,  4, 5),
            new Card(3, 1,  4, -4),
            new Card(3, 2,  1, -3),
            new Card(3, 2,  1, -2),
            new Card(3, 3,  3, -4),
            new Card(3, 3,  2, 2),
            new Card(3, 4,  3, 8),
            new Card(3, 4,  1, 9),
            new Card(3, 5,  4, 7),
            new Card(3, 5,  1, 4),
            new Card(3, 6,  3, 5),
            new Card(3, 6,  0, 1),
            new Card(3, 7,  4, 6),
            new Card(3, 7,  1, 2),
            new Card(3, 8,  3, -1),
            new Card(3, 8,  1, 9),
            new Card(3, 9,  4, -3),
            new Card(3, 9,  3, -1),
            new Card(3, -3, 4, 6),
            new Card(3, -3, 1, 6),
            new Card(3, -4, 1, 3),
            new Card(3, -4, 0, 1),
            new Card(3, -1, 4, 1),
            new Card(3, -1, 3, 7),
            new Card(3, -2, 4, 9),
            new Card(3, -2, 2, 4),

            new Card(1, 1,  3, 3),
            new Card(1, 1,  2, 2),
            new Card(1, 2,  4, -1),
            new Card(1, 2,  2, -3),
            new Card(1, 3,  3, 7),
            new Card(1, 3,  0, 1),
            new Card(1, 4,  4, -4),
            new Card(1, 4,  2, -3),
            new Card(1, 5,  3, 2),
            new Card(1, 5,  1, 5),
            new Card(1, 6,  4, 9),
            new Card(1, 6,  3, -2),
            new Card(1, 7,  4, 1),
            new Card(1, 7,  2, 5),
            new Card(1, 8,  2, -1),
            new Card(1, 8,  1, 7),
            new Card(1, 9,  2, 5),
            new Card(1, 9,  1, -1),
            new Card(1, -3, 3, 3),
            new Card(1, -3, 3, 4),
            new Card(1, -4, 3, 8),
            new Card(1, -4, 2, 3),
            new Card(1, -1, 2, 3),
            new Card(1, -1, 1, 7),
            new Card(1, -2, 4, -3),
            new Card(1, -2, 0, 0),

            new Card(2, 1,  3, -2),
            new Card(2, 1,  0, 0),
            new Card(2, 2,  1, 1),
            new Card(2, 2,  1, 8),
            new Card(2, 3,  3, -3),
            new Card(2, 3,  2, 1),
            new Card(2, 4,  3, -3),
            new Card(2, 4,  2, -4),
            new Card(2, 5,  2, 9),
            new Card(2, 5,  1, 8),
            new Card(2, 6,  4, -2),
            new Card(2, 6,  0, 1),
            new Card(2, 7,  4, 2),
            new Card(2, 7,  2, 6),
            new Card(2, 8,  4, 2),
            new Card(2, 8,  3, 1),
            new Card(2, 9,  2, 4),
            new Card(2, 9,  1, 5),
            new Card(2, -3, 3, 1),
            new Card(2, -3, 2, 8),
            new Card(2, -4, 4, 8),
            new Card(2, -4, 3, 4),
            new Card(2, -1, 1, -4),
            new Card(2, -1, 0, 0),
            new Card(2, -2, 4, 3),
            new Card(2, -2, 1, -4),
        ];

        public static bool main_side = true;
    }

    internal class Program
    {
        static void Main()
        {   
            Random random = new Random();

            List<int> deck_new = new List<int>();
                for (int i = 0; i < 112; i++){ deck_new.Add(i); }

            int card;
            List<int> deck = new List<int>();
                for (int i = 0; i < 112; i++){
                    card = random.Next(0, deck_new.Count);
                    deck.Add(deck_new[card]);
                    deck_new.RemoveAt(card);
                }
            
            for (int i = 0; i < 112; i++){ deck_new.Add(i); }
            

            List<int> user_cards = new List<int>();
            List<int> opponent_cards = new List<int>();
            List<int> stack = new List<int>();

            for (int i = 0; i < 7; i++){
                TakeCardFromDeck(ref deck, ref opponent_cards);
                TakeCardFromDeck(ref deck, ref user_cards);
            }

            TakeCardFromDeck(ref deck, ref stack);
            while (stack.Last() < 7){
                deck.Add(stack[0]);
                stack.RemoveAt(stack.Last());
                TakeCardFromDeck(ref deck, ref stack);
            }
            


            while (true){
                ShowCardSituation(ref opponent_cards, ref deck, ref stack, ref user_cards);
                Console.WriteLine("Backspace to take a card:");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Backspace){
                    if (stack.Count > 0){
                        TakeCardFromDeck(ref deck, ref user_cards);
                    }
                }
            }
        }


        public static void TakeCardFromDeck(ref List<int> deck, ref List<int> stack){
            stack.Add(deck[0]);
            deck.RemoveAt(0);
        }

        public static void ShuffleDeck(){

        }//todo

        public static void ShowCardSituation(ref List<int> opponent_cards, ref List<int> deck, ref List<int> stack, ref List<int> user_cards){
            InputOutput.PrintCards(InputOutput.GetCards(opponent_cards), main_side: !GlobalVars.main_side, show_other_side: false, compact: false, small: true);
            Console.WriteLine();
            Console.WriteLine();
            InputOutput.PrintCards(InputOutput.GetCards(deck[0]), main_side: !GlobalVars.main_side, show_other_side: false, compact: true, small: false, spacing: "     ");
            InputOutput.PrintCards(InputOutput.GetCards(stack.Last()), main_side: GlobalVars.main_side, show_other_side: false, compact: false, small: false, spacing: "     ");
            Console.WriteLine();
            Console.WriteLine();
            InputOutput.PrintCards(InputOutput.GetCards(user_cards), show_other_side: true);
        }
    }
}