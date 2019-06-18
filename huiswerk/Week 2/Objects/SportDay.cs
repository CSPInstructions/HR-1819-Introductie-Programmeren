using System;
using System.Collections.Generic;
using sportdag.ExtensionMethods;
using sportdag.Menu;

namespace sportdag.Objects {

    public class SportDay {

        private readonly List<SportEvent> Sports;
        private readonly List<Student> Students;

        public SportDay() {
            this.Sports = new List<SportEvent>();
            this.Students = new List<Student>();
        }

        #region Additions
        private int AddObject( string[] requestedInput, Func<string[], bool> validate, Action<string[]> creation ) {
            string[] input = ConsoleFunctions.GetInputs( requestedInput, "quit" );

            if ( input == null ) {
                return -1;
            }

            if ( !validate( input ) ) {
                Console.WriteLine( "Please enter the requested information" );
                return 1;
            }

            creation( input );
            return 0;
        }

        public int AddStudent() {
            string[] requestedInput = { "Student Number: ", "Student Name: " };
            bool validate( string[] input ) => input[0].Length > 0 || Student.IsValidName( input[1] );
            void creation( string[] input ) => this.Students.Add( new Student( input[0], input[1] ) );

            return AddObject( requestedInput, validate, creation );
        }

        public int AddSportEvent() {
            string[] requestedInput = { "Sport Name: ", "Score Unit: " };
            bool validate( string[] input ) => SportEvent.IsValidName( input[0] ) || SportEvent.IsValidScoreUnit( input[1] );
            void creation( string[] input ) => this.Sports.Add( new SportEvent( input[0], input[1] ) );

            return AddObject( requestedInput, validate, creation );
        }

        public int AddScore() {
            Console.Write( "Select a student. " );
            Student selectedStudent = Menu.Menu.MenuAndSelectFromList( this.Students );
            if ( selectedStudent == default( Student ) ) { return -1; }

            Console.Write( "Select an event. " );
            SportEvent sportEvent = Menu.Menu.MenuAndSelectFromList( this.Sports );
            if ( sportEvent == default( SportEvent ) ) { return -1; }

            Console.Write( "Enter the score: " );
            string potentialScore = Console.ReadLine();

            if ( float.TryParse( potentialScore, out float score ) ) {
                sportEvent.AddScore( selectedStudent, score );
                return 0;
            } else {
                Console.WriteLine( "Invalid Score" );
                return 1;
            }
        }
        #endregion

        #region Prints
        private void PrintAllObjects<T>( List<T> objects ) {
            foreach ( T item in objects ) {
                Console.WriteLine( item );
            }
        }

        private void PrintScores( Action<SportEvent> printAction ) {
            foreach ( SportEvent sport in Sports ) {
                printAction( sport );
                Console.WriteLine();
            }
        }

        public void PrintAllStudents() { this.PrintAllObjects( this.Students ); }
        public void PrintAllEvents() { this.PrintAllObjects( this.Sports ); }
        public void PrintAllScores() { this.PrintScores( sport => sport.PrintAllResults() ); }
        public void PrintTopScores() { this.PrintScores( sport => sport.PrintStageResults() ); }
        #endregion
    }
}
