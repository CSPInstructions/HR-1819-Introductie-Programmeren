using System;
using System.Collections.Generic;
using System.Linq;

namespace sportdag.Objects {

    public class SportEvent {

        private readonly string SportName;
        private readonly string SportScoreUnit;
        private readonly List<(Student Student, float Score)> SportScores;

        public SportEvent( string sportName, string sportScoreUnit ) {
            if ( !SportEvent.IsValidName( sportName ) || !SportEvent.IsValidScoreUnit( sportScoreUnit ) ) {
                throw new ArgumentException( "Not all data is correct" );
            }

            this.SportName = sportName;
            this.SportScoreUnit = sportScoreUnit;
            this.SportScores = new List<(Student student, float score)>();
        }

        #region Validation
        public static bool IsValidName( string name ) {
            bool isValidLength = name.Length > 0;
            bool isValidSyntax = name.All( character => Char.IsLetter( character ) || character == ' ' );
            return isValidLength && isValidSyntax;
        }

        public static bool IsValidScoreUnit( string unit ) {
            bool isValidLength = unit.Length > 0;
            bool isValidSyntax = unit.All( character => Char.IsLetter( character ) );
            return isValidLength && isValidSyntax;
        }
        #endregion

        #region Additions
        public bool AddScore( Student student, float score ) {
            if ( student == null ) {
                return false;
            }

            this.SportScores.Add( (student, score) );
            return true;
        }
        #endregion

        #region Prints
        public void PrintAllResults() {
            this.PrintResults( ( scores ) => {
                return scores
                    .OrderByDescending( ( score ) => score.Score )
                    .ToList();
            } );
        }

        public void PrintStageResults() {
            this.PrintResults( ( scores ) => {
                return scores
                    .OrderByDescending( ( score ) => score.Score )
                    .Take( 3 )
                    .ToList();
            } );
        }

        private void PrintResults( Func<List<(Student Student, float Score)>, List<(Student Student, float Score)>> filter ) {
            string results = this.SportName + "\n";
            List<(Student Student, float Score)> sortedScores = filter( this.SportScores );

            foreach ( (Student Student, float Score) score in sortedScores ) {
                results += String.Format( "{0} {1} - {2}\n", score.Score, this.SportScoreUnit, score.Student );
            }

            Console.Write( results );
        }
        #endregion

        #region Overrides
        public override string ToString() {
            return this.SportName;
        }
        #endregion
    }
}
