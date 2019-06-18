using System;
using System.Collections.Generic;
using System.Linq;

namespace sportdag.Menu {

    public static class Menu {

        private static readonly string[] ValidOptions = { "1", "2", "3", "4", "5", "6", "7", "0" };

        #region Prints
        private static void PrintMenuInstruction() {
            Console.WriteLine( "Please enter the number corresponding to the action that needs to be performed" );
        }

        public static void PrintActionInstruction() {
            Console.WriteLine( "Fill in the required information, quit by typing 'quit' at any time" );
        }

        public static void PrintMainMenu() {
            PrintMenuInstruction();

            Console.WriteLine (
                "(1) Add Students\n" +
                "(2) Show All Students\n" +
                "(3) Add Sport Events\n" +
                "(4) Show All Sport Events\n" +
                "(5) Enter Scores\n" +
                "(6) Show All Scores\n" +
                "(7) Show Top Scores\n" +
                "(0) Quit\n"
            );
        }

        public static void PrintMenuFromList<T>( List<T> list ) {
            PrintMenuInstruction();

            for ( int index = 0; index < list.Count; index += 1 ) {
                Console.WriteLine( String.Format( "({0}) {1}", index, list[index] ) );
            }
        }
        #endregion

        #region Selects
        public static int SelectAction() {
            while ( true ) {
                Console.Write( "Selection: " );
                string choice = Console.ReadLine();

                if ( ValidOptions.Contains( choice ) ) {
                    return int.Parse( choice );
                }

                if ( choice.ToLower() == "quit" ) {
                    return 0;
                }

                Console.WriteLine( "Please enter a valid option" );
            }
        }

        public static T SelectActionFromList<T>( List<T> list ) {
            while ( true ) {
                Console.Write( "Selection: " );
                string choice = Console.ReadLine();

                if ( choice.ToLower() == "quit" ) {
                    return default;
                }

                if ( int.TryParse( choice, out int possibleIndex ) ) {
                    if ( list.Count > possibleIndex ) {
                        return list[possibleIndex];
                    }
                    else {
                        Console.WriteLine( "Pick a valid number" );
                    }
                } else {
                    Console.WriteLine( "Please enter a number" );
                }
            }
        }
        #endregion

        #region Combination
        public static T MenuAndSelectFromList<T>( List<T> list ) {
            PrintMenuFromList( list );
            return SelectActionFromList( list );
        }
        #endregion
    }
}
