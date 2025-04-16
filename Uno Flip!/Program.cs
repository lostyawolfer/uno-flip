using System.Collections;
using System.Diagnostics;
using System.Threading;
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
            bool win = false;
            while(true) {
                win = Game();
                Console.CursorVisible = false;
                if (win) input_output.InputOutput.WriteWithColor("\n\t\tYou win!", ConsoleColor.Green);
                else input_output.InputOutput.WriteWithColor("\n\t\tYou lose!", ConsoleColor.Red);
                Thread.Sleep(5000);
                Console.CursorVisible = true;
                GlobalVars.main_side = true;
            }
        }



        public static bool Game() {
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
            bool player_skip = false;
            bool bot_skip = false;
            int draw_chain = 0;
            while (true){
                if (info.Contains("win")) return true;
                if (bot_played.Contains("lose")) return false;
                
                Console.Clear();

                SortDeck(ref opponent_cards);
                SortDeck(ref user_cards);
                ShowCardSituation(ref opponent_cards, ref deck, ref stack, ref user_cards, draw_chain);
                Console.WriteLine();
                //Console.WriteLine("\n\nwrite a card code (written in its bottom left) to play it\nif it's a wild add a color code at the end to set that color\n\t(r red, y yellow, g green, b blue; c cyan, p purple, m magenta, o orange)\n\"#\" to draw a card\nadd \"!\" at the end to call UNO!\n");
                
                if (last_move) {
                    if (!info.Contains("skipped")) input_output.InputOutput.WriteWithColor($"{info}\n", ConsoleColor.Green);
                    else input_output.InputOutput.WriteWithColor($"{info}\n", ConsoleColor.DarkGreen);
                    if (!bot_skip) {
                        input_output.InputOutput.WriteWithColor($"Waiting for bot...", ConsoleColor.DarkCyan);
                        //if (player_skip) input_output.InputOutput.WriteWithColor($"\t Bot played {bot_played}", ConsoleColor.DarkYellow);
                        input_output.InputOutput.WriteWithColor($"\n", ConsoleColor.DarkCyan);
                        Console.CursorVisible = false;
                        Thread.Sleep(1500);
                        bot_played = BotMove(ref opponent_cards, ref stack, ref deck, ref player_skip, ref draw_chain);
                    }
                    Console.Clear();

                    SortDeck(ref opponent_cards);
                    SortDeck(ref user_cards);
                    ShowCardSituation(ref opponent_cards, ref deck, ref stack, ref user_cards, draw_chain);
                    Console.WriteLine();

                    //Console.WriteLine("\n\nwrite a card code (written in its bottom left) to play it\nif it's a wild add a color code at the end to set that color\n\t(r red, y yellow, g green, b blue; c cyan, p purple, m magenta, o orange)\n\"#\" to draw a card\nadd \"!\" at the end to call UNO!\n");
                    input_output.InputOutput.WriteWithColor($"{info}\n", ConsoleColor.Green);
                    if (!bot_skip) input_output.InputOutput.WriteWithColor($"Bot played {bot_played}\n", ConsoleColor.Cyan);
                    else input_output.InputOutput.WriteWithColor($"Bot skipped\n", ConsoleColor.DarkCyan);
                    if (!player_skip){
                        if (draw_chain == 0) {
                            input_output.InputOutput.WriteWithColor($"\nNext move", ConsoleColor.Gray);
                        } else {
                            input_output.InputOutput.WriteWithColor($"chain: {draw_chain}", ConsoleColor.Yellow);
                        }
                        input_output.InputOutput.WriteWithColor($" > ", ConsoleColor.DarkGray);
                    } 
                    Console.CursorVisible = true;
                    bot_skip = false;
                } else {
                    if (bot_played != "") input_output.InputOutput.WriteWithColor($"\nBot played {bot_played}\n", ConsoleColor.Cyan);
                    else Console.Write("\n\n");
                    input_output.InputOutput.WriteWithColor($"\n{info}", ConsoleColor.Red);
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
                #pragma warning disable CS8604 // Possible null reference argument.
                if (!player_skip) {
                    string input = Console.ReadLine();
                    last_move = ValidateMove(input, ref user_cards, ref stack, ref deck, ref bot_skip, ref draw_chain, out info);
                }
                else {
                    last_move = true;
                    info = "You skipped";
                    player_skip = false;
                }
            }
        }

        public static void TakeCardFromDeck(ref List<int> deck, ref List<int> stack, bool to_end = true, int amount = 1){
            for (int i = 0; i < amount; i++) {
                if (deck.Count == 0) return;
                if (to_end) stack.Add(deck[0]);
                else stack.Insert(0, deck[0]);
                deck.RemoveAt(0);
            }
        }


        public static void PlaceCard(ref List<int> stack, ref List<int> cards, ref bool skip, int card, ref int draw_chain){
            if (GlobalVars.main_side) stack.Add(card);
            else stack.Insert(0, card);
            cards.Remove(card);

            if (( GlobalVars.main_side && (GlobalVars.cards[card].main_value == -1 || GlobalVars.cards[card].main_value == -2)) ||
                (!GlobalVars.main_side && (GlobalVars.cards[card].reverse_value == -1 || GlobalVars.cards[card].reverse_value == -2)))
                    skip = true;
            

            if (( GlobalVars.main_side && GlobalVars.cards[card].main_value == -4) ||
                (!GlobalVars.main_side && GlobalVars.cards[card].reverse_value == -4))
                GlobalVars.main_side = !GlobalVars.main_side;

            if (( GlobalVars.main_side && GlobalVars.cards[card].main_value == -3) ||
                (!GlobalVars.main_side && GlobalVars.cards[card].reverse_value == -3)) {
                    if (GlobalVars.main_side) draw_chain++;
                    else draw_chain += 5;
                }
                

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

        public static void ShowCardSituation(ref List<int> opponent_cards, ref List<int> deck, ref List<int> stack, ref List<int> user_cards, int chain_length = 0){
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
            input_output.InputOutput.WriteWithColor($"cards: {user_cards.Count}\t", ConsoleColor.White);
            input_output.InputOutput.WriteWithColor("current side: ", ConsoleColor.White);
            if (GlobalVars.main_side) input_output.InputOutput.WriteWithColor("↑ light\t", ConsoleColor.Yellow);
            else input_output.InputOutput.WriteWithColor("↯ dark\t", ConsoleColor.Cyan);
            Console.WriteLine();
            InputOutput.PrintCards(InputOutput.GetCards(user_cards), show_other_side: true, show_codes: true);
        }


        public static bool ValidateMove(string input, ref List<int> cards, ref List<int> stack, ref List<int> deck, ref bool skip, ref int draw_chain, out string info){
            info = "";
            input = input.Trim().ToLower();
            string no_uno_input = input.EndsWith('!') ? input[..^1] : input;

            if (input == "#" || input == "") {
                if (draw_chain == 0) draw_chain++;
                TakeCardFromDeck(ref deck, ref cards, false, draw_chain);
                info = $"You played #\tDrew {draw_chain} card(s)";
                draw_chain = 0;
                return true;
            }

            
        
            foreach (int card in cards) {
                if (draw_chain == 0) {
                    if ((no_uno_input == $"{GlobalVars.cards[card].main_code}" && GlobalVars.main_side) || (no_uno_input == $"{GlobalVars.cards[card].reverse_code}" && !GlobalVars.main_side)) {
                        if ((GlobalVars.main_side &&
                                (GlobalVars.cards[card].main_color == GlobalVars.cards[stack.Last()].main_color || GlobalVars.cards[card].main_color == 0 || GlobalVars.cards[stack.Last()].main_color == 0 || GlobalVars.cards[card].main_value == GlobalVars.cards[stack.Last()].main_value)) ||

                            (!GlobalVars.main_side &&
                                (GlobalVars.cards[card].reverse_color == GlobalVars.cards[stack[0]].reverse_color || GlobalVars.cards[card].reverse_color == 0 || GlobalVars.cards[stack[0]].reverse_color == 0 || GlobalVars.cards[card].reverse_value == GlobalVars.cards[stack[0]].reverse_value))) {


                            PlaceCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            info = $"You played {input}";
                            if (cards.Count == 1) {
                                if (!input.EndsWith('!')){
                                    TakeCardFromDeck(ref deck, ref cards);
                                    TakeCardFromDeck(ref deck, ref cards);
                                    info = $"You played {input}\tDrew 2 cards (no UNO when you have only 1 card)";
                                } else {
                                    info = $"You played {input}\tUNO!";
                                }
                            } else {
                                if (input.EndsWith('!')){
                                    TakeCardFromDeck(ref deck, ref cards);
                                    TakeCardFromDeck(ref deck, ref cards);
                                    info = $"You played {input}\tDrew 2 cards (UNO when you have other than 1 card)";
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
                } else {
                    if ((no_uno_input == $"{GlobalVars.cards[card].main_code}" && GlobalVars.main_side) || (no_uno_input == $"{GlobalVars.cards[card].reverse_code}" && !GlobalVars.main_side)) {
                        if ((GlobalVars.main_side &&
                                GlobalVars.cards[card].main_value == -3) ||

                            (!GlobalVars.main_side &&
                                GlobalVars.cards[card].reverse_value == -3)) {

                            PlaceCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            info = $"You played {input}";
                            if (cards.Count == 1) {
                                if (!input.EndsWith('!')){
                                    TakeCardFromDeck(ref deck, ref cards);
                                    TakeCardFromDeck(ref deck, ref cards);
                                    info = $"You played {input}\tDrew 2 cards (no UNO when you have only 1 card)";
                                } else {
                                    info = $"You played {input}\tUNO!";
                                }
                            } else {
                                if (input.EndsWith('!')){
                                    TakeCardFromDeck(ref deck, ref cards);
                                    TakeCardFromDeck(ref deck, ref cards);
                                    info = $"You played {input}Drew 2 cards (UNO when you have more than 1 card)";
                                }
                            }
                            if (cards.Count == 0) {
                                info = $"You played {input}\tYou win!";
                            }
                            return true;
                        }
                        info = "Currently chaining; only +. Try again";
                        return false;
                    }
                }
            }

            info = "You don't have that card. Try again";
            return false;
        }

        public static string BotMove(ref List<int> cards, ref List<int> stack, ref List<int> deck, ref bool skip, ref int draw_chain) {
            if (draw_chain == 0) {
                foreach (int card in cards) {
                    if (GlobalVars.main_side) {
                        if (GlobalVars.cards[card].main_color == GlobalVars.cards[stack.Last()].main_color || GlobalVars.cards[card].main_value == GlobalVars.cards[stack.Last()].main_value) {
                            PlaceCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            if (cards.Count > 1) return $"{GlobalVars.cards[card].main_code}";
                            else if (cards.Count == 1) return $"{GlobalVars.cards[card].main_code}!\tUNO!";
                            else return $"{GlobalVars.cards[card].main_code}\tYou lose!";
                        }
                    } else {
                        if (GlobalVars.cards[card].reverse_color == GlobalVars.cards[stack[0]].reverse_color || GlobalVars.cards[card].reverse_value == GlobalVars.cards[stack[0]].reverse_value) {
                            PlaceCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            if (cards.Count > 1) return $"{GlobalVars.cards[card].reverse_code}";
                            else if (cards.Count == 1) return $"{GlobalVars.cards[card].reverse_code}!\tUNO!";
                            else return $"{GlobalVars.cards[card].reverse_code}\tYou lose!";
                        }
                    }
                }

                foreach (int card in cards) {
                    if ((GlobalVars.main_side && GlobalVars.cards[card].main_color == 0) || (!GlobalVars.main_side && GlobalVars.cards[card].reverse_color == 0)) {
                        PlaceCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                        return $"{GlobalVars.cards[card].main_code}";
                    }
                }
            } else {
                foreach (int card in cards) {
                    if (GlobalVars.main_side) {
                        if (GlobalVars.cards[card].main_value == -3) {
                            PlaceCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            return $"{GlobalVars.cards[card].main_code}";
                        }
                    } else {
                        if (GlobalVars.cards[card].reverse_value == -3) {
                            PlaceCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            return $"{GlobalVars.cards[card].reverse_code}";
                        }
                    }
                }
            }

            TakeCardFromDeck(ref deck, ref cards);
            if (draw_chain == 0) draw_chain++;
            string ret = $"#\tDrew {draw_chain} card(s)";
            draw_chain = 0;
            return ret;
        }
    }
}