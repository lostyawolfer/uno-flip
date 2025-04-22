namespace input_output
{
    public static class InputOutput
    {
        public static void WriteWithColor(string message, ConsoleColor color, ConsoleColor background = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            if (background!=ConsoleColor.Black) Console.BackgroundColor = background;
            Console.Write(message);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}




namespace uno_flip{

    public struct Card{
        public int main_color;
        public int main_value;
        public int reverse_color;
        public int reverse_value;

        public string main_code;
        public string reverse_code;


        public Card(int card_main_color, int card_main_value, int card_reverse_color, int card_reverse_value){
            main_color = card_main_color;
            main_value = card_main_value;
            reverse_color = card_reverse_color;
            reverse_value = card_reverse_value;

            if (main_color == 1) main_code = "r";
            else if (main_color == 2) main_code = "y";
            else if (main_color == 3) main_code = "g";
            else if (main_color == 4) main_code = "b";
            else main_code = "w";

            if (reverse_color == 1) reverse_code = "c";
            else if (reverse_color == 2) reverse_code = "p";
            else if (reverse_color == 3) reverse_code = "m";
            else if (reverse_color == 4) reverse_code = "o";
            else reverse_code = "w";

            if (card_main_value > 0 && card_main_color != 0) main_code = $"{main_code}{card_main_value}";
            else if (card_main_value == -1 && card_main_color != 0) main_code = $"{main_code}r";
            else if (card_main_value == -2 && card_main_color != 0) main_code = $"{main_code}s";
            else if (card_main_value == -3 && card_main_color != 0) main_code = $"{main_code}+1";
            else if (card_main_value == -4 && card_main_color != 0) main_code = $"{main_code}f";

            if (card_main_value == 0 && card_main_color == 0) main_code = $"{main_code}";
            else if (card_main_value == 1 && card_main_color == 0) main_code = $"{main_code}+2";



            if (card_reverse_value > 0 && card_reverse_color != 0) reverse_code = $"{reverse_code}{card_reverse_value}";
            else if (card_reverse_value == -1 && card_reverse_color != 0) reverse_code = $"{reverse_code}r";
            else if (card_reverse_value == -2 && card_reverse_color != 0) reverse_code = $"{reverse_code}s";
            else if (card_reverse_value == -3 && card_reverse_color != 0) reverse_code = $"{reverse_code}+5";
            else if (card_reverse_value == -4 && card_reverse_color != 0) reverse_code = $"{reverse_code}f";

            if (card_reverse_value == 0 && card_reverse_color == 0) reverse_code = $"{reverse_code}";
            else if (card_reverse_value == 1 && card_reverse_color == 0) reverse_code = $"{reverse_code}*";
        }
    }

    public static class InputOutput{
        public static void ParseCard(out ConsoleColor true_color, out string true_value, out string type, out string code, Card card, bool main_side = true, char back = ' ', int render_wilds_as = 0){
            /*
            this function is supposed to take your card, parse it and output results for easier card rendering.
            inputs:
                card: Card struct
                main_side (optional = true): declares if the card parser should output info about card's main side or reverse side if false
            outputs:
                true_color: ConsoleColor corresponding to the card's encoded color
                    (0 = wild, 1 = red/cyan, 2 = yellow/purple(dark_magenta), 3 = green/pink(magenta), 4 = blue/orange(dark_yellow))
                true_value: actual card's value to be displayed. includes special markings for special cards
                type: converted color to classical card marking (to avoid color confusion at any cost)
                    (wild = J (for Joker), red/cyan = ♥, yellow/purple = ♦, green/pink = ♠, blue/orange = ♣)
            */



            true_color = ConsoleColor.White;
            true_value = $"{back}{back}";
            int color = main_side ? card.main_color : card.reverse_color;
            int value = main_side ? card.main_value : card.reverse_value;

            if (color == 0) type = main_side ? "J" : "j";
            else if (color == 1) type = main_side ? "♥" : "♡";
            else if (color == 2) type = main_side ? "♦" : "♢";
            else if (color == 3) type = main_side ? "♠" : "♤";
            else type = main_side ? "♣" : "♧";


            if (color != 0){
                if (value > 0) true_value = $"{back}{value}";
                else if (value == -1) true_value = $"{back}⇵";    // reverse
                else if (value == -2) true_value = main_side ? $"{back}Ø" : $"{back}↻";    // block
                else if (value == -3) {
                    if (main_side) true_value = "+1";
                    else true_value = "+5";
                } 
                else if (value == -4) true_value = $"{back}↯";    // flip
            } else {
                if (value == 0) true_value = $"{back}W";
                else {
                    if (main_side) true_value = "W2";
                    else true_value = "W*";
                } 
            }


            if (color == 0) color = render_wilds_as;

            if (main_side){
                if (color == 0) true_color = ConsoleColor.White;    // wild
                else if (color == 1) true_color = ConsoleColor.Red;
                else if (color == 2) true_color = ConsoleColor.Yellow;
                else if (color == 3) true_color = ConsoleColor.Green;
                else if (color == 4) true_color = ConsoleColor.Blue;
            } else {
                // Console.BackgroundColor = ConsoleColor.White;
                if (color == 0) true_color = ConsoleColor.Gray;    // wild
                else if (color == 1) true_color = ConsoleColor.DarkCyan;
                else if (color == 2) true_color = ConsoleColor.DarkMagenta;
                else if (color == 3) true_color = ConsoleColor.Magenta;
                else if (color == 4) true_color = ConsoleColor.DarkYellow;
            }


            code = main_side ? card.main_code : card.reverse_code;
            while (code.Length < 3) code = $"{code}{back}";
        }

        public static void ParseCard(out ConsoleColor true_color, out string true_value, out string type, out string code, int card, bool main_side = true, char back = ' ', int render_wilds_as = 0){
            // this overload takes an integer ID of the card instead of the card itself
            Card real_card = GlobalVars.cards[card];
            ParseCard(out true_color, out true_value, out type, out code, real_card, main_side, back, render_wilds_as);
        }



        public static Card[] GetCards(List<int> cards){
            Card[] res = new Card[cards.Count];
            for (int i = 0; i < cards.Count; i++){
                res[i] = GlobalVars.cards[cards[i]];
            }
            return res;
        }

        public static Card GetCards(int card){
            Card res;
            res = GlobalVars.cards[card];
            return res;
        }





        public static void PrintCards(Card[] cards, bool? main_side = null, bool show_other_side = false, bool small = false, bool compact = false, bool show_codes = false, string spacing = "", int render_wilds_as = 0){
            ConsoleColor color;
            string value;
            string type;
            string code;

            if (cards.Length == 0) {

                if (!small) {
                    if (show_other_side) input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮\n{spacing}│     │\n", ConsoleColor.DarkGray);
                    if (compact) input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮\n{spacing}│EMPTY│\n{spacing}╰─────╯\n", ConsoleColor.DarkGray);
                    else input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮\n{spacing}│    /│\n{spacing}│   / │\n{spacing}│  /  │\n{spacing}│ /   │\n{spacing}│/    │\n{spacing}╰─────╯\n", ConsoleColor.DarkGray);
                } else {
                    if (show_other_side) input_output.InputOutput.WriteWithColor($"{spacing}╭───╮\n", ConsoleColor.DarkGray);
                    if (compact) input_output.InputOutput.WriteWithColor($"{spacing}╭───╮\n{spacing}│ / │\n{spacing}╰───╯\n", ConsoleColor.DarkGray);
                    else input_output.InputOutput.WriteWithColor($"{spacing}╭───╮\n{spacing}│  /│\n{spacing}│ / │\n{spacing}│/  │\n{spacing}╰───╯\n", ConsoleColor.DarkGray);
                }

                return;
            }

            int _MAX_CARD_WIDTH = Console.WindowWidth / 6;
            int _MAX_CARDS_UNTIL_COMPACT = _MAX_CARD_WIDTH;
            int _MAX_CARDS_UNTIL_SMALL = _MAX_CARD_WIDTH / 2;
            int _MAX_CARDS_UNTIL_NO_SIDE = _MAX_CARD_WIDTH*2;

            if (cards.Length > _MAX_CARDS_UNTIL_COMPACT) compact = true;
            if (cards.Length > _MAX_CARDS_UNTIL_SMALL) small = true;
            if (cards.Length > _MAX_CARDS_UNTIL_NO_SIDE) show_other_side = false;

            if (Console.WindowHeight < 30) compact = true;

            main_side ??= GlobalVars.main_side;
            bool real_main_side = main_side.GetValueOrDefault();


            // if (render_wilds_as != 0) Console.WriteLine($"rendering wilds as {render_wilds_as} (ConsoleColor.{true_render_wilds_as})");

            Card[] cards_part = new Card[_MAX_CARD_WIDTH];
            bool flag = false;
            int card_division = cards.Length / _MAX_CARD_WIDTH;
            if (cards.Length % _MAX_CARD_WIDTH != 0) card_division++;

            for (int i=0; i < card_division; i++){
                for (int j=0; j < _MAX_CARD_WIDTH; j++){
                    try { 
                        cards_part[j] = cards[i*_MAX_CARD_WIDTH + j];
                    } catch (IndexOutOfRangeException) { 
                        flag = true;
                        break;
                    }
                }

                if (flag){
                    for (int j=0; j < _MAX_CARD_WIDTH; j++){
                        cards_part[j] = new Card(-1, 0, 0, 0);
                    }
                    for (int j=0; j < _MAX_CARD_WIDTH; j++){
                        try { 
                            cards_part[j] = cards[i*_MAX_CARD_WIDTH + j];
                        } catch (IndexOutOfRangeException) { 
                            break;
                        }
                    }
                }


                if (!small){
                    if (show_other_side){
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, !real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, !real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}{value}  │ ", color);
                        } Console.WriteLine();
                    }

                    if (!compact){   
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}    │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│     │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│ {value}  │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│     │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│    {type}│ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, back: '─', render_wilds_as:render_wilds_as);
                            if (show_codes) input_output.InputOutput.WriteWithColor($"{spacing}╰{code}──╯ ", color);
                            else input_output.InputOutput.WriteWithColor($"{spacing}╰─────╯ ", color);
                        } Console.WriteLine();
                    } else {
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}{value}  │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, back: '─', render_wilds_as:render_wilds_as);
                            if (show_codes) input_output.InputOutput.WriteWithColor($"{spacing}╰{code}──╯ ", color);
                            else input_output.InputOutput.WriteWithColor($"{spacing}╰─────╯ ", color);
                        } Console.WriteLine();
                    }
                } else {
                    if (show_other_side){
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, !real_main_side, back: '─', render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}╭{type}{value}╮ ", color);
                        } Console.WriteLine();
                    }

                    if (!compact) {
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}╭───╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}  │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│{value} │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│  {type}│ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, back: '─', render_wilds_as:render_wilds_as);
                            if (show_codes) input_output.InputOutput.WriteWithColor($"{spacing}╰{code}╯ ", color);
                            else input_output.InputOutput.WriteWithColor($"{spacing}╰───╯ ", color);
                        } Console.WriteLine();
                    } else {
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}╭───╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, render_wilds_as:render_wilds_as);
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}{value}│ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, back: '─', render_wilds_as:render_wilds_as);
                            if (show_codes) input_output.InputOutput.WriteWithColor($"{spacing}╰{code}╯ ", color);
                            else input_output.InputOutput.WriteWithColor($"{spacing}╰───╯ ", color);
                        } Console.WriteLine();
                    }
                }
            }
        }

        public static void PrintCards(Card card, bool? main_side = null, bool show_other_side = false, bool small = false, bool compact = false, bool show_codes = false, string spacing = "", int render_wilds_as = 0){
            Card[] cards = [card];
            PrintCards(cards, main_side, show_other_side, small, compact, show_codes, spacing, render_wilds_as);
        }







        public static void ShowScreen(List<int> opponent_cards, ref List<int> deck, ref List<int> stack, ref List<int> user_cards, int chain_length = 0){
            Console.Clear();


            PrintCards(GetCards(opponent_cards), main_side: !GlobalVars.main_side, show_other_side: false, compact: false, small: true);
            input_output.InputOutput.WriteWithColor($"cards: {opponent_cards.Count}\n", ConsoleColor.DarkGray);
            Console.WriteLine();
            Console.WriteLine();
            if (Console.WindowHeight > 40) Console.WriteLine();


            Card[] empty_stack = [];

            try {
                PrintCards(GetCards(deck[0]), main_side: !GlobalVars.main_side, show_other_side: false, compact: true, small: false, spacing: "     ");
            } catch {
                PrintCards(empty_stack, main_side: !GlobalVars.main_side, show_other_side: false, compact: true, small: false, spacing: "     ");
            }

            try {
                if (GlobalVars.main_side) PrintCards(GetCards(stack.Last()), main_side: GlobalVars.main_side, show_other_side: false, compact: false, small: false, spacing: "     ", render_wilds_as:GlobalVars.last_played_wild_color);
                else PrintCards(GetCards(stack[0]), main_side: GlobalVars.main_side, show_other_side: false, compact: false, small: false, spacing: "     ", render_wilds_as:GlobalVars.last_played_wild_color);
            } catch {
                PrintCards(empty_stack, main_side: GlobalVars.main_side, show_other_side: false, compact: false, small: false, spacing: "     ", render_wilds_as:GlobalVars.last_played_wild_color);
            }

            if (Console.WindowHeight > 40) Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            input_output.InputOutput.WriteWithColor($"cards: {user_cards.Count}\t", ConsoleColor.White);
            input_output.InputOutput.WriteWithColor("current side: ", ConsoleColor.White);
            if (GlobalVars.main_side) input_output.InputOutput.WriteWithColor("↑ light\t", ConsoleColor.Yellow);
            else input_output.InputOutput.WriteWithColor("↯ dark\t", ConsoleColor.Cyan);
            Console.WriteLine();
            PrintCards(GetCards(user_cards), show_other_side: true, show_codes: true);
        }
    }
}