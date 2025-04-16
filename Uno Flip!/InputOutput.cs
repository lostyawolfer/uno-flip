using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace input_output
{
    public static class InputOutput
    {
        static bool IsInArray(string? find, string[] arr)
        {
            foreach (string item in arr) if (item == find) return true;
            return false;
        }

        static bool IsInArray(int find, int[] arr)
        {
            foreach (int item in arr) if (item == find) return true;
            return false;
        }




        public static void WriteWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }




        public static string AwaitInput(string message, ConsoleColor message_color = ConsoleColor.White, ConsoleColor input_color = ConsoleColor.Cyan, bool spacing = false, string? def = null, params string[] expected)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            string? val;
            if (def == null)
            {
                do
                {
                    Console.ForegroundColor = message_color;
                    Console.Write(message);
                    Console.ForegroundColor = input_color;
                    val = Console.ReadLine();
                } while (!IsInArray(val, expected));
            } else {
                Console.ForegroundColor = message_color;
                Console.Write(message);
                Console.ForegroundColor = input_color;
                val = Console.ReadLine();
                if ((val == "") || (val == null)) val = def;
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (spacing) Console.WriteLine();

            return val;
        }

        public static int AwaitInput(string message, ConsoleColor message_color = ConsoleColor.White, ConsoleColor input_color = ConsoleColor.Cyan, bool spacing = false, int? def = null, params int[] expected)
        {   
            int val;
            string? input;
            if (def == null)
            {
                {
                    do
                    {
                        do
                        {
                            Console.ForegroundColor = message_color;
                            Console.Write(message);
                            Console.ForegroundColor = input_color;
                            input = Console.ReadLine();
                        } while (int.TryParse(input, out val));
                    } while (!IsInArray(val, expected));
                }
            } else {
                Console.ForegroundColor = message_color;
                Console.Write(message);
                Console.ForegroundColor = input_color;
                input = Console.ReadLine();
                if (!int.TryParse(input, out val)) val = (int)def;
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (spacing) Console.WriteLine();
            return val;
        }





        static bool GetArrayFromString(string input, out int[] res)
        {
            int amount = 1;
            foreach(char c in input){
                if(char.IsWhiteSpace(c)){
                    amount++;
                }
            }

            res = new int[amount];
            int currentnum = 0;
            int i = 0;
            foreach(char c in input){

                if(!char.IsWhiteSpace(c) && !char.IsNumber(c)) return false;
                if(char.IsNumber(c)){

                    currentnum *= 10;

                    currentnum += c - '0';

                }
                if(char.IsWhiteSpace(c)){
                    res[i] = currentnum;
                    currentnum = 0;
                    i++;

                }
            }
            res[i] = currentnum;

            return true;
        }

        public static int[,] AwaitInput(string message, int length, int width, ConsoleColor message_color = ConsoleColor.White, ConsoleColor input_color = ConsoleColor.Cyan, bool spacing = false)
        {   
            int[,] val = new int[width,length];
            int[] temp;
            string? input;

            int message_length = message.Length;
            
            Console.ForegroundColor = message_color;
            Console.Write(message);
            Console.ForegroundColor = input_color;
            string bad_input_msg = "Bad input!";
            int bad_input_msg_len = bad_input_msg.Length;
            int bad_input_msg_len_total = message_length - 10;

            int att_cnt;
            for (int i = 0; i < width; i++){
                att_cnt = 0;
                #pragma warning disable CS8604 // Possible null reference argument.
                do {
                    if (att_cnt > 0){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(bad_input_msg);
                        Console.ForegroundColor = input_color;
                        if (i > 0) for (int j = 0; j < bad_input_msg_len_total; j++) Console.Write(" ");
                    }
                    else if (i > 0) for (int j = 0; j < message_length; j++) Console.Write(" ");
                    //if (i > 0) for (int j = 0; j < message_length; j++) Console.Write(" ");
                    input = Console.ReadLine();
                    att_cnt++;
                } while (!GetArrayFromString(input, out temp));

                for (int j = 0; j < length; j++){
                    val[i, j] = temp[j];
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (spacing) Console.WriteLine();
            return val;
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
        public static void ParseCard(out ConsoleColor true_color, out string true_value, out string type, out string code, Card card, bool main_side = true, char back = ' '){
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

            // input_output.InputOutput.WriteWithColor($"╭───╮\n", true_color);
            // input_output.InputOutput.WriteWithColor($"│{type}  │\n", true_color);
            // input_output.InputOutput.WriteWithColor($"│{true_value} │\n", true_color);
            // input_output.InputOutput.WriteWithColor($"│  {type}│\n", true_color);     
            // input_output.InputOutput.WriteWithColor($"╰───╯\n", true_color);

            // Console.ResetColor();


            code = main_side ? card.main_code : card.reverse_code;
            while (code.Length < 3) code = $"{code}{back}";
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

            ConsoleColor true_render_wilds_as;
            if (real_main_side) {
                if (render_wilds_as == 1) true_render_wilds_as = ConsoleColor.Red;
                else if (render_wilds_as == 2) true_render_wilds_as = ConsoleColor.Yellow;
                else if (render_wilds_as == 3) true_render_wilds_as = ConsoleColor.Green;
                else if (render_wilds_as == 4) true_render_wilds_as = ConsoleColor.Blue;
                else true_render_wilds_as = ConsoleColor.White;
            } else {
                if (render_wilds_as == 1) true_render_wilds_as = ConsoleColor.DarkCyan;
                else if (render_wilds_as == 2) true_render_wilds_as = ConsoleColor.DarkMagenta;
                else if (render_wilds_as == 3) true_render_wilds_as = ConsoleColor.Magenta;
                else if (render_wilds_as == 4) true_render_wilds_as = ConsoleColor.DarkYellow;
                else true_render_wilds_as = ConsoleColor.Gray;
            }

            if (render_wilds_as != 0) Console.WriteLine($"rendering wilds as {render_wilds_as} (ConsoleColor.{true_render_wilds_as})");

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
                            ParseCard(out color, out value, out type, out code, card, !real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, !real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}{value}  │ ", color);
                        } Console.WriteLine();
                    }

                    if (!compact){   
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}    │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│     │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│ {value}  │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│     │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│    {type}│ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, back: '─');
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            if (show_codes) input_output.InputOutput.WriteWithColor($"{spacing}╰{code}──╯ ", color);
                            else input_output.InputOutput.WriteWithColor($"{spacing}╰─────╯ ", color);
                        } Console.WriteLine();
                    } else {
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}╭─────╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}{value}  │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, back: '─');
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            if (show_codes) input_output.InputOutput.WriteWithColor($"{spacing}╰{code}──╯ ", color);
                            else input_output.InputOutput.WriteWithColor($"{spacing}╰─────╯ ", color);
                        } Console.WriteLine();
                    }
                } else {
                    if (show_other_side){
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, !real_main_side, back: '─');
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}╭{type}{value}╮ ", color);
                        } Console.WriteLine();
                    }

                    if (!compact) {
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}╭───╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}  │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│{value} │ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│  {type}│ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, back: '─');
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            if (show_codes) input_output.InputOutput.WriteWithColor($"{spacing}╰{code}╯ ", color);
                            else input_output.InputOutput.WriteWithColor($"{spacing}╰───╯ ", color);
                        } Console.WriteLine();
                    } else {
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}╭───╮ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side);
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
                            input_output.InputOutput.WriteWithColor($"{spacing}│{type}{value}│ ", color);
                        } Console.WriteLine();
                        foreach (Card card in cards_part){
                            if (card.main_color == -1) break;
                            ParseCard(out color, out value, out type, out code, card, real_main_side, back: '─');
                            if (render_wilds_as != 0 && card.main_color == 0) color = true_render_wilds_as;
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
    }
}