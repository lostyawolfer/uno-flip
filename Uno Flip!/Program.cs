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
        public static int last_played_wild_color = 0;
    }

    internal class Program
    {
        static void Main()
        {   
            bool win = false;
            Console.CursorVisible = false;
            Console.Clear();
            input_output.InputOutput.WriteWithColor("\n\n\n\t\t*** WELCOME TO UNO FLIP ***\n", ConsoleColor.Yellow);
            input_output.InputOutput.WriteWithColor("\n\n\tRules of the game", ConsoleColor.Red);
            input_output.InputOutput.WriteWithColor(
                "\n\tYou have your hand, you have the deck, and you have the stack.\n\tOn your turn, you can put a card from your hand to a stack if the card has the same color or same number/symbol.\n\tIf you don't have a card that fits, you grab 1 card from the deck.\n\tYour task is to get rid of all your cards.\n\tSay 'UNO!' before placing your second to last card to signify you only have 1 left.\n\tIf you don't, you are forced to grab 2 cards from the deck.", ConsoleColor.White);
            input_output.InputOutput.WriteWithColor("\n\n\tHow to convey things here", ConsoleColor.Red);
            input_output.InputOutput.WriteWithColor(
                "\n\tEvery card has a card code on its bottom left that you can use to signify your move.\n\tType in '#' or nothing and hit enter to grab a card from the deck.\n\tFinish a move by '!' to shout 'UNO!'.\n\tTo set a color on a wild card, add a color code after the card code.\n\t\tr for Red, y - Yellow, g - Green, b - Blue;\n\t\tc - Cyan, p - Purple, m - Magenta, o - Orange.", ConsoleColor.White);
            input_output.InputOutput.WriteWithColor(
                "\n\n\tYou are going to play against a robot that's supposed to play aggressively.\n\tIt is artificially slowed down so that you can properly percieve each its move.\n\tIt does not actually take your computer that long to get the move done.", ConsoleColor.Cyan);
            input_output.InputOutput.WriteWithColor(
                "\n\n\tThe only house rule in this game is 'Stacking', meaning if someone gives you a +1 you can +1 them back, for example.\n\tNo 'Challenging' wild plus cards btw.\n\tHave fun!", ConsoleColor.White);
            
            input_output.InputOutput.WriteWithColor("\n\n\n\t\tPress any key to contiune", ConsoleColor.Green);
            Console.ReadKey();
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

            DrawCards(ref deck, ref stack, ref user_cards, ref opponent_cards, ref deck, ref stack, out _);
            while (stack.Last() < 7){
                deck.Add(stack[0]);
                stack.RemoveAt(0);
                DrawCards(ref deck, ref stack, ref user_cards, ref opponent_cards, ref deck, ref stack, out _);
            }

            Console.CursorVisible = false;
            for (int i = 0; i < 7; i++){
                DrawCards(ref deck, ref opponent_cards, ref user_cards, ref opponent_cards, ref deck, ref stack, out _);
                SortDeckBot(ref opponent_cards);
                Console.Clear();
                ShowCardSituation(ref opponent_cards, ref deck, ref stack, ref user_cards);
                Thread.Sleep(75);

                DrawCards(ref deck, ref user_cards, ref user_cards, ref opponent_cards, ref deck, ref stack, out _);
                SortDeck(ref user_cards);
                Console.Clear();
                ShowCardSituation(ref opponent_cards, ref deck, ref stack, ref user_cards);
                Thread.Sleep(75);
            }
            Console.CursorVisible = true;
            
            // ConsoleKeyInfo keyInfo = new();
            bool last_move = false;
            string bot_played = "";
            string info = "Play a card!";
            bool player_skip = false;
            bool bot_skip = false;
            int draw_chain = 0;
            while (true){
                // if (info.Contains("win")) return true;
                // if (bot_played.Contains("lose")) return false;
                
                Console.Clear();

                SortDeckBot(ref opponent_cards);
                SortDeck(ref user_cards);
                ShowCardSituation(ref opponent_cards, ref deck, ref stack, ref user_cards, draw_chain);
                Console.WriteLine();
                //Console.WriteLine("\n\nwrite a card code (written in its bottom left) to play it\nif it's a wild add a color code at the end to set that color\n\t(r red, y yellow, g green, b blue; c cyan, p purple, m magenta, o orange)\n\"#\" to draw a card\nadd \"!\" at the end to call UNO!\n");
                
                if (last_move) {
                    if (!info.Contains("skipped")) input_output.InputOutput.WriteWithColor($"{info}\n", ConsoleColor.Green);
                    else input_output.InputOutput.WriteWithColor($"{info}\n", ConsoleColor.DarkGreen);
                    if (!bot_skip) {
                        input_output.InputOutput.WriteWithColor($"Waiting for bot...", ConsoleColor.DarkCyan);
                        //if (player_skip) input_output.InputOutput.WriteWithColor($"\t Bot: {bot_played}", ConsoleColor.DarkYellow);
                        input_output.InputOutput.WriteWithColor($"\n", ConsoleColor.DarkCyan);
                        Console.CursorVisible = false;
                        Thread.Sleep(1500);
                        bot_played = BotMove(ref opponent_cards, ref stack, ref deck, ref user_cards, ref opponent_cards, ref deck, ref stack, ref player_skip, ref draw_chain);
                    }
                    Console.Clear();

                    SortDeckBot(ref opponent_cards);
                    SortDeck(ref user_cards);
                    ShowCardSituation(ref opponent_cards, ref deck, ref stack, ref user_cards, draw_chain);
                    Console.WriteLine();

                    //Console.WriteLine("\n\nwrite a card code (written in its bottom left) to play it\nif it's a wild add a color code at the end to set that color\n\t(r red, y yellow, g green, b blue; c cyan, p purple, m magenta, o orange)\n\"#\" to draw a card\nadd \"!\" at the end to call UNO!\n");
                    input_output.InputOutput.WriteWithColor($"{info}\n", ConsoleColor.Green);
                    if (!bot_skip) input_output.InputOutput.WriteWithColor($"Bot: {bot_played}\n", ConsoleColor.Cyan);
                    else input_output.InputOutput.WriteWithColor($"Bot skipped\n", ConsoleColor.DarkCyan);
                    if (bot_played.Contains("lose")) return false;
                    if (!player_skip){
                        if (draw_chain <= 0) {
                            input_output.InputOutput.WriteWithColor($"\nNext move", ConsoleColor.Gray);
                        } else {
                            input_output.InputOutput.WriteWithColor($"\nchain: {draw_chain}", ConsoleColor.Magenta);
                        }
                        input_output.InputOutput.WriteWithColor($" > ", ConsoleColor.DarkGray);
                    } 
                    Console.CursorVisible = true;
                    bot_skip = false;
                } else {
                    if (bot_played != "") input_output.InputOutput.WriteWithColor($"\nBot: {bot_played}\n", ConsoleColor.Cyan);
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
                if (info.Contains("win")) return true;
                #pragma warning disable CS8604 // Possible null reference argument.
                string input;
                if (!player_skip) {
                    if (draw_chain >= 0) input = Console.ReadLine();
                    else {
                        input = "#";
                        Thread.Sleep(1000);
                    } 
                    last_move = ValidateMove(input, ref user_cards, ref stack, ref deck, ref user_cards, ref opponent_cards, ref deck, ref stack, ref bot_skip, ref draw_chain, out info);
                }
                else {
                    last_move = true;
                    info = "You skipped";
                    player_skip = false;
                }
            }
        }

        public static void DrawCards(ref List<int> deck, ref List<int> stack, ref List<int> game_user_cards, ref List<int> game_opponent_cards, ref List<int> game_deck, ref List<int> game_stack, out int took_amount, bool to_end = true, int amount = 1){
            took_amount = 0;
            if (amount < 0) {
                do {
                    Console.Clear();
                    SortDeckBot(ref game_opponent_cards);
                    SortDeck(ref game_user_cards);
                    ShowCardSituation(ref game_opponent_cards, ref game_deck, ref game_stack, ref game_user_cards);
                    Thread.Sleep(250);

                    if (deck.Count == 0) return;
                    took_amount++;
                    if (to_end) stack.Add(deck[0]);
                    else stack.Insert(0, deck[0]);
                    deck.RemoveAt(0);
                } while ( (GlobalVars.cards[deck[0]].main_color != amount*(-1) && GlobalVars.main_side) ||
                        (GlobalVars.cards[deck[0]].reverse_color != amount*(-1) &&!GlobalVars.main_side) );
                    Console.Clear();
                    ShowCardSituation(ref game_opponent_cards, ref game_deck, ref game_stack, ref game_user_cards);
                    Thread.Sleep(250);

                    //PlayCard(ref stack, ref deck, ref skip, stack.Last(), ref );


                return;
            }

            for (int i = 0; i < amount; i++) {
                if (deck.Count == 0) return;
                took_amount++;
                if (to_end) stack.Add(deck[0]);
                else stack.Insert(0, deck[0]);
                deck.RemoveAt(0);

                Console.Clear();
                SortDeckBot(ref game_opponent_cards);
                SortDeck(ref game_user_cards);
                ShowCardSituation(ref game_opponent_cards, ref game_deck, ref game_stack, ref game_user_cards);
                if (amount > 1) Thread.Sleep(75);
            }
        }


        public static void PlayCard(ref List<int> stack, ref List<int> cards, ref bool skip, int card, ref int draw_chain){
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
                
            if (( GlobalVars.main_side && GlobalVars.cards[card].main_value == 1 && GlobalVars.cards[card].main_color == 0) ||
                (!GlobalVars.main_side && GlobalVars.cards[card].reverse_value == 1 && GlobalVars.cards[card].reverse_color == 0)) {
                    if (GlobalVars.main_side) draw_chain += 2;
                    else draw_chain = -1;
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

        public static void SortDeckBot(ref List<int> deck){
            if (GlobalVars.main_side) {
                deck = deck
                    .OrderBy(card => GlobalVars.cards[card].main_color == 0)            // priority to non-wild
                    .ThenByDescending(card => GlobalVars.cards[card].main_value == -1)  // priority to reverse
                    .ThenByDescending(card => GlobalVars.cards[card].main_value == -2)  // priority to skip
                    .ThenByDescending(card => GlobalVars.cards[card].main_value == -3)  // priority to draw
                    .ThenBy(card => GlobalVars.cards[card].main_value == -4)         // flip last
                    .ThenBy(card => GlobalVars.cards[card].main_value)                  // sort by value
                    .ToList();
            } else {
                deck = deck
                    .OrderBy(card => GlobalVars.cards[card].reverse_color == 0)
                    .ThenByDescending(card => GlobalVars.cards[card].reverse_value == -1)
                    .ThenByDescending(card => GlobalVars.cards[card].reverse_value == -2)
                    .ThenByDescending(card => GlobalVars.cards[card].reverse_value == -3)
                    .ThenBy(card => GlobalVars.cards[card].reverse_value == -4)
                    .ThenBy(card => GlobalVars.cards[card].reverse_value)
                    .ToList();
            }
        }


        public static void SortDeck(ref List<int> deck){
            if (GlobalVars.main_side) {
                deck = deck
                    .OrderBy(card => GlobalVars.cards[card].main_color)
                    .ThenBy(card => GlobalVars.cards[card].main_value)
                    .ThenBy(card => GlobalVars.cards[card].reverse_color)
                    .ThenBy(card => GlobalVars.cards[card].reverse_value).ToList();
            } else {
                deck = deck
                    .OrderBy(card => GlobalVars.cards[card].reverse_color)
                    .ThenBy(card => GlobalVars.cards[card].reverse_value)
                    .ThenBy(card => GlobalVars.cards[card].main_color)
                    .ThenBy(card => GlobalVars.cards[card].main_value).ToList();
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

            if (GlobalVars.main_side) InputOutput.PrintCards(InputOutput.GetCards(stack.Last()), main_side: GlobalVars.main_side, show_other_side: false, compact: false, small: false, spacing: "     ", render_wilds_as: GlobalVars.last_played_wild_color);
            else InputOutput.PrintCards(InputOutput.GetCards(stack[0]), main_side: GlobalVars.main_side, show_other_side: false, compact: false, small: false, spacing: "     ", render_wilds_as: GlobalVars.last_played_wild_color);

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


        public static bool ValidateMove(string input, ref List<int> cards, ref List<int> stack, ref List<int> deck, ref List<int> game_user_cards, ref List<int> game_opponent_cards, ref List<int> game_deck, ref List<int> game_stack, ref bool skip, ref int draw_chain, out string info){
            info = "";
            input = input.Trim().ToLower();
            string no_uno_input = input.EndsWith('!') ? input[..^1] : input;

            // debug stuff
            if (input == "/flip") {
                GlobalVars.main_side =!GlobalVars.main_side;
                info = "Flipped";
                return false;
            }

            if (input.StartsWith("/draw ")) {
                string numberPart = input.Substring(6);
                int draw_count = int.TryParse(numberPart, out draw_count)? draw_count : 1;
                DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _, false, draw_count);
                info = $"Drew {draw_count}";
                return false;
            }

            if (input.StartsWith("/drawbot ")) {
                string numberPart = input.Substring(9);
                int draw_count = int.TryParse(numberPart, out draw_count)? draw_count : 1;
                DrawCards(ref deck, ref game_opponent_cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _, false, draw_count);
                info = $"Drew {draw_count}";
                return false;
            }



            if (input == "#" || input == "") {
                if (draw_chain == 0) draw_chain = 1;
                DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out draw_chain, false, draw_chain);
                if (draw_chain == 1) info = $"You: #\t\tDrew {draw_chain} card";
                else info = $"You: #\t\tDrew {draw_chain} cards";
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


                            PlayCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            info = $"You: {input}";
                            if (cards.Count == 1) {
                                if (!input.EndsWith('!')){
                                    DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _);
                                    DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _);
                                    info = $"You: {input}\t\tDrew 2 cards (no UNO when you have only 1 card)";
                                } else {
                                    info = $"You: {input}\t\tUNO!";
                                }
                            } else {
                                if (input.EndsWith('!')){
                                    DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _);
                                    DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _);
                                    info = $"You: {input}\t\tDrew 2 cards (UNO when you have other than 1 card)";
                                }
                            }
                            if (cards.Count == 0) {
                                info = $"You: {input}\tYou win!";
                            }
                            return true;
                        }
                        info = "This card can't be played. Try again";
                        return false;
                    }
                } else if (draw_chain > 0) {
                    if ((no_uno_input == $"{GlobalVars.cards[card].main_code}" && GlobalVars.main_side) || (no_uno_input == $"{GlobalVars.cards[card].reverse_code}" && !GlobalVars.main_side)) {
                        if ((GlobalVars.main_side &&
                                GlobalVars.cards[card].main_value == -3) ||

                            (!GlobalVars.main_side &&
                                GlobalVars.cards[card].reverse_value == -3) ||

                            (!GlobalVars.main_side &&
                                GlobalVars.cards[card].main_value == 1 && GlobalVars.cards[card].main_value == 0) ||

                            (!GlobalVars.main_side &&
                                GlobalVars.cards[card].reverse_value == 1 && GlobalVars.cards[card].reverse_value == 0)) {

                            PlayCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            info = $"You: {input}";
                            if (cards.Count == 1) {
                                if (!input.EndsWith('!')){
                                    DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _);
                                    DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _);
                                    info = $"You: {input}\t\tDrew 2 cards (no UNO when you have only 1 card)";
                                } else {
                                    info = $"You: {input}\t\tUNO!";
                                }
                            } else {
                                if (input.EndsWith('!')){
                                    DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _);
                                    DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out _);
                                    info = $"You: {input}\t\tDrew 2 cards (UNO when you have more than 1 card)";
                                }
                            }
                            if (cards.Count == 0) {
                                info = $"You: {input}\tYou win!";
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

        public static string BotMove(ref List<int> cards, ref List<int> stack, ref List<int> deck, ref List<int> game_user_cards, ref List<int> game_opponent_cards, ref List<int> game_deck, ref List<int> game_stack, ref bool skip, ref int draw_chain) {
            if (draw_chain == 0) {
                foreach (int card in cards) {
                    if (GlobalVars.main_side) {
                        if (GlobalVars.cards[card].main_color == GlobalVars.cards[stack.Last()].main_color || GlobalVars.cards[card].main_value == GlobalVars.cards[stack.Last()].main_value) {
                            PlayCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            if (cards.Count > 1) return $"{GlobalVars.cards[card].main_code}";
                            else if (cards.Count == 1) return $"{GlobalVars.cards[card].main_code}!\tUNO!";
                            else return $"{GlobalVars.cards[card].main_code}\tYou lose!";
                        }
                    } else {
                        if (GlobalVars.cards[card].reverse_color == GlobalVars.cards[stack[0]].reverse_color || GlobalVars.cards[card].reverse_value == GlobalVars.cards[stack[0]].reverse_value) {
                            PlayCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            if (cards.Count > 1) return $"{GlobalVars.cards[card].reverse_code}";
                            else if (cards.Count == 1) return $"{GlobalVars.cards[card].reverse_code}!\tUNO!";
                            else return $"{GlobalVars.cards[card].reverse_code}\tYou lose!";
                        }
                    }
                }

                foreach (int card in cards) {
                    if ((GlobalVars.main_side && GlobalVars.cards[card].main_color == 0) || (!GlobalVars.main_side && GlobalVars.cards[card].reverse_color == 0)) {
                        PlayCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                        if (GlobalVars.main_side) {
                            if (cards.Count > 1) return $"{GlobalVars.cards[card].main_code}";
                            else if (cards.Count == 1) return $"{GlobalVars.cards[card].main_code}!\tUNO!";
                            else return $"{GlobalVars.cards[card].main_code}\tYou lose!";
                        } else {
                            if (cards.Count > 1) return $"{GlobalVars.cards[card].reverse_code}";
                            else if (cards.Count == 1) return $"{GlobalVars.cards[card].reverse_code}!\tUNO!";
                            else return $"{GlobalVars.cards[card].reverse_code}\tYou lose!";
                        }
                    }
                }
            } else if (draw_chain > 0) {
                foreach (int card in cards) {
                    if (GlobalVars.main_side) {
                        if (GlobalVars.cards[card].main_value == -3) {
                            PlayCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            return $"{GlobalVars.cards[card].main_code}";
                        }
                    } else {
                        if (GlobalVars.cards[card].reverse_value == -3) {
                            PlayCard(ref stack, ref cards, ref skip, card, ref draw_chain);
                            return $"{GlobalVars.cards[card].reverse_code}";
                        }
                    }
                }
            }

            if (draw_chain == 0) draw_chain++;
            DrawCards(ref deck, ref cards, ref game_user_cards, ref game_opponent_cards, ref game_deck, ref game_stack, out draw_chain, amount:draw_chain);
            string ret;
            if (draw_chain == 1) ret = $"#\t\tDrew {draw_chain} card";
            else ret = $"#\t\tDrew {draw_chain} cards";
            draw_chain = 0;
            return ret;
        }
    }
}