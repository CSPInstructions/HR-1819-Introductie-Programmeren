using System;
using sportdag.Menu;
using sportdag.Objects;

namespace sportdag {

    class MainClass {

        public static SportDay sportDay;

        public static void Main( string[] args ) {
            sportDay = new SportDay();
            bool stop = false;

            PrintIntroduction();
            while( !stop ) {
                int choice = UserMenu();
                Console.WriteLine();

                switch( choice ) {
                    case 1: AddStudents(); break;
                    case 2: ExecuteAndWait( sportDay.PrintAllStudents ); break;
                    case 3: AddSports(); break;
                    case 4: ExecuteAndWait( sportDay.PrintAllEvents ); break;
                    case 5: AddScore(); break;
                    case 6: ExecuteAndWait( sportDay.PrintAllScores ); break;
                    case 7: ExecuteAndWait( sportDay.PrintTopScores ); break;
                    case 0: stop = true; break;
                }

                Console.WriteLine( "\n" );
            }
        }

        #region MenuFunctionality
        public static void PrintIntroduction() {
            Console.WriteLine( 
                "Sportdag Console Application\n" +
            	"By: Wesley van Schaijk\n" 
            );
        }

        public static int UserMenu() {
            Menu.Menu.PrintMainMenu();
            return Menu.Menu.SelectAction();
        }


        public static void ExecuteAndWait( Action action ) {
            action();
            Console.Write( "Press any key to continue..." );
            Console.ReadKey();
        }
        #endregion

        #region Additions
        private static void AddObjects( Func<int> action, string objectName ) {
            Menu.Menu.PrintActionInstruction();
            bool stop = false;

            while ( !stop ) {
                int result = action();

                if ( result == -1 ) {
                    stop = true;
                }

                if ( result == 0 ) {
                    Console.WriteLine( objectName + " Added" );
                }
            }
        }

        public static void AddStudents() { AddObjects( () => sportDay.AddStudent(), "Student" ); }
        public static void AddSports() { AddObjects( () => sportDay.AddSportEvent(), "Sport" ); }
        public static void AddScore() { AddObjects( () => sportDay.AddScore(), "Score" ); }
        #endregion
    }
}
