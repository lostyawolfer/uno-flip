using System.Collections;
using System.Diagnostics;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

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
            while(true) {
                Main2();

                GlobalVars.main_side = true;
            }
        }



        public static void Main2() {
            Random random = new Random();

            List<int> deck = new List<int>();
            ShuffleDeck(ref deck);

            

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
                stack.RemoveAt(0);
                TakeCardFromDeck(ref deck, ref stack);
            }
            
            // ConsoleKeyInfo keyInfo = new();
            bool last_move = false;
            string bot_played = "";
            string info = "Play a card!";
            while (true){
                Console.Clear();

                SortDeck(ref opponent_cards);
                SortDeck(ref user_cards);
                ShowCardSituation(ref opponent_cards, ref deck, ref stack, ref user_cards);
                Console.WriteLine("\n\nwrite a card code (written in its bottom left) to play it\nif it's a wild add a color code at the end to set that color\n\t(r red, y yellow, g green, b blue; c cyan, p purple, m magenta, o orange)\n\"#\" to draw a card\nadd \"!\" at the end to call UNO!\n");
                
                if (last_move) {
                    input_output.InputOutput.WriteWithColor($"{info}\n", ConsoleColor.Green);
                    input_output.InputOutput.WriteWithColor($"Bot played {bot_played}\n", ConsoleColor.Yellow);
                    input_output.InputOutput.WriteWithColor($"Next move > ", ConsoleColor.Gray);
                } else {
                    if (bot_played != "") input_output.InputOutput.WriteWithColor($"\nBot played {bot_played}\n", ConsoleColor.Yellow);
                    else Console.Write("\n\n");
                    input_output.InputOutput.WriteWithColor($"{info}", ConsoleColor.Red);
                    input_output.InputOutput.WriteWithColor($" > ", ConsoleColor.Gray);
                }
                //Console.WriteLine($"{keyInfo.Key} pressed; it's {keyInfo.KeyChar} char");

                // keyInfo = Console.ReadKey(true);

                // if (keyInfo.Key == ConsoleKey.D1){
                //     TakeCardFromDeck(ref deck, ref user_cards);
                // } else if (keyInfo.Key == ConsoleKey.D2){
                //     TakeCardFromDeck(ref deck, ref opponent_cards);
                // } else if (keyInfo.Key == ConsoleKey.D0){
                //     if (GlobalVars.main_side){
                //         TakeCardFromDeck(ref deck, ref stack);
                //     } else {
                //         TakeCardFromDeck(ref deck, ref stack, false);
                //     }
                // } else if (keyInfo.Key == ConsoleKey.Spacebar){
                //     GlobalVars.main_side = !GlobalVars.main_side;
                // } else if (keyInfo.Key == ConsoleKey.Q){
                //     Environment.Exit(0);
                //     //System.Diagnostics.Process.GetCurrentProcess().Kill();
                // } else if (keyInfo.Key == ConsoleKey.R){
                //     return;
                //     //System.Diagnostics.Process.GetCurrentProcess().Kill();
                // }
                string input = Console.ReadLine();
                #pragma warning disable CS8604 // Possible null reference argument.
                last_move = ValidateMove(input, ref user_cards, ref stack, ref deck, out info);
                if (last_move) bot_played = BotMove(ref opponent_cards, ref stack, ref deck);
            }
        }

        public static void TakeCardFromDeck(ref List<int> deck, ref List<int> stack, bool to_end = true){
            if (deck.Count == 0) return;
            if (to_end) stack.Add(deck[0]);
            else stack.Insert(0, deck[0]);
            deck.RemoveAt(0);
        }


        public static void PlaceCard(ref List<int> stack, ref List<int> cards, int card){
            if (GlobalVars.main_side) stack.Add(card);
            else stack.Insert(0, card);
            cards.Remove(card);

            if ((GlobalVars.main_side && GlobalVars.cards[card].main_value == -4) || (!GlobalVars.main_side && GlobalVars.cards[card].reverse_value == -4))
                GlobalVars.main_side = !GlobalVars.main_side;
        }



        public static void ShuffleDeck(ref List<int> deck){
            int card;
            Random random = new Random();

            List<int> deck_new = new List<int>();
            for (int i = 0; i < 112; i++) deck_new.Add(i);

            for (int i = 0; i < 112; i++){
                card = random.Next(0, deck_new.Count);
                deck.Add(deck_new[card]);
                deck_new.RemoveAt(card);
            }
        }

        public static void SortDeck(ref List<int> deck){
            if (GlobalVars.main_side) {
                deck = deck.OrderBy(card => GlobalVars.cards[card].main_color).ThenBy(card => GlobalVars.cards[card].main_value).ThenBy(card => GlobalVars.cards[card].reverse_color).ThenBy(card => GlobalVars.cards[card].reverse_value).ToList();
            } else {
                deck = deck.OrderBy(card => GlobalVars.cards[card].reverse_color).ThenBy(card => GlobalVars.cards[card].reverse_value).ThenBy(card => GlobalVars.cards[card].main_color).ThenBy(card => GlobalVars.cards[card].main_value).ToList();
            }
        }

        public static void ShowCardSituation(ref List<int> opponent_cards, ref List<int> deck, ref List<int> stack, ref List<int> user_cards){
            InputOutput.PrintCards(InputOutput.GetCards(opponent_cards), main_side: !GlobalVars.main_side, show_other_side: false, compact: false, small: true);
            input_output.InputOutput.WriteWithColor($"cards: {opponent_cards.Count}\n", ConsoleColor.DarkGray);
            Console.WriteLine();
            Console.WriteLine();
            if (Console.WindowHeight > 40) Console.WriteLine();
            if (deck.Count > 0) InputOutput.PrintCards(InputOutput.GetCards(deck[0]), main_side: !GlobalVars.main_side, show_other_side: false, compact: true, small: false, spacing: "     ");
            else input_output.InputOutput.WriteWithColor("     ╭─────╮\n     │EMPTY│\n     ╰─────╯\n", ConsoleColor.DarkGray);
            if (GlobalVars.main_side) InputOutput.PrintCards(InputOutput.GetCards(stack.Last()), main_side: GlobalVars.main_side, show_other_side: false, compact: false, small: false, spacing: "     ");
            else InputOutput.PrintCards(InputOutput.GetCards(stack[0]), main_side: GlobalVars.main_side, show_other_side: false, compact: false, small: false, spacing: "     ");
            if (Console.WindowHeight > 40) Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            input_output.InputOutput.WriteWithColor($"cards: {user_cards.Count}   ", ConsoleColor.White);
            input_output.InputOutput.WriteWithColor("current side: ", ConsoleColor.White);
            if (GlobalVars.main_side) input_output.InputOutput.WriteWithColor("↑ light\n", ConsoleColor.Yellow);
            else input_output.InputOutput.WriteWithColor("↯ dark\n", ConsoleColor.Cyan);
            InputOutput.PrintCards(InputOutput.GetCards(user_cards), show_other_side: true, show_codes: true);
        }


        public static bool ValidateMove(string input, ref List<int> cards, ref List<int> stack, ref List<int> deck, out string info){
            info = "";
            input = input.Trim().ToLower();
            string no_uno_input = input.EndsWith('!') ? input[..^1] : input;

            if (input.StartsWith('#')) {
                TakeCardFromDeck(ref deck, ref cards);
                if (GlobalVars.main_side) info = $"You played #\tDrew 1 card: {GlobalVars.cards[cards.Last()].main_code}";
                else info = $"You played #\tDrew 1 card: {GlobalVars.cards[cards.Last()].reverse_code}";
                return true;
            }

        
            foreach (int card in cards) {
                if ((no_uno_input == $"{GlobalVars.cards[card].main_code}" && GlobalVars.main_side) || (no_uno_input == $"{GlobalVars.cards[card].reverse_code}" && !GlobalVars.main_side)) {
                    if ((GlobalVars.main_side &&
                            (GlobalVars.cards[card].main_color == GlobalVars.cards[stack.Last()].main_color || GlobalVars.cards[card].main_value == GlobalVars.cards[stack.Last()].main_value)) ||

                        (!GlobalVars.main_side &&
                            (GlobalVars.cards[card].reverse_color == GlobalVars.cards[stack[0]].reverse_color || GlobalVars.cards[card].reverse_value == GlobalVars.cards[stack[0]].reverse_value))) {


                        PlaceCard(ref stack, ref cards, card);
                        info = $"You played {input}";
                        if (cards.Count == 1) {
                            if (!input.EndsWith('!')){
                                TakeCardFromDeck(ref deck, ref cards);
                                TakeCardFromDeck(ref deck, ref cards);
                                info = $"You played {input}\t1 card, no \"uno\" => draw 2";
                            } else {
                                info = $"You played {input}; UNO!";
                            }
                        } else {
                            if (input.EndsWith('!')){
                                TakeCardFromDeck(ref deck, ref cards);
                                TakeCardFromDeck(ref deck, ref cards);
                                info = $"You played {input}; UNO!\t >1 card with \"uno\" => draw 2";
                            }
                        }
                        if (cards.Count == 0) {
                            info = $"You played {input}\tYou win!";
                        }
                        return true;
                    }
                    info = "This card can't be played. Try again";
                    return false;
                }
            }

            info = "Invalid syntax or you don't have that card. Try again";
            return false;
        }

        public static string BotMove(ref List<int> cards, ref List<int> stack, ref List<int> deck) {
            foreach (int card in cards) {
                if (GlobalVars.main_side) {
                    if (GlobalVars.cards[card].main_color == GlobalVars.cards[stack.Last()].main_color || GlobalVars.cards[card].main_value == GlobalVars.cards[stack.Last()].main_value) {
                        PlaceCard(ref stack, ref cards, card);
                        if (cards.Count > 1) return $"{GlobalVars.cards[card].main_code}";
                        else if (cards.Count == 1) return $"{GlobalVars.cards[card].main_code}; UNO!";
                        else return $"{GlobalVars.cards[card].main_code}\tYou lose!";
                    }
                } else {
                    if (GlobalVars.cards[card].reverse_color == GlobalVars.cards[stack[0]].reverse_color || GlobalVars.cards[card].reverse_value == GlobalVars.cards[stack[0]].reverse_value) {
                        PlaceCard(ref stack, ref cards, card);
                        if (cards.Count > 1) return $"{GlobalVars.cards[card].reverse_code}";
                        else if (cards.Count == 1) return $"{GlobalVars.cards[card].reverse_code}; UNO!";
                        else return $"{GlobalVars.cards[card].reverse_code}\tYou lose!";
                    }
                }
            }

            foreach (int card in cards) {
                if ((GlobalVars.main_side && GlobalVars.cards[card].main_color == 0) || (!GlobalVars.main_side && GlobalVars.cards[card].reverse_color == 0)) {
                    PlaceCard(ref stack, ref cards, card);
                    return $"{GlobalVars.cards[card].main_code}";
                }
            }

            TakeCardFromDeck(ref deck, ref cards);
            return "#";
        }
    }
}