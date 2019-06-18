using System;
using System.Linq;

namespace sportdag.Objects {

    public class Student {

        private readonly string StudentNumber;
        private readonly string StudentName;

        public Student( string studentNumber, string studentName ) {
            if ( !Student.IsValidName( studentName ) || studentName.Length <= 0 ) {
                throw new ArgumentException( "Not all data is correct" );
            }

            this.StudentNumber = studentNumber;
            this.StudentName = studentName;
        }

        public override string ToString() {
            return String.Format( "{0} - {1}", this.StudentNumber, this.StudentName );
        }

        public static bool IsValidName( string name ) {
            bool isValidLength = name.Length > 0;
            bool isValidSyntax = name.All( character => Char.IsLetter( character ) || character == ' ' );
            return isValidLength && isValidSyntax;
        }
    }
}
