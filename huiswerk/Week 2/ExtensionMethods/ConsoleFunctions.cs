using System;

namespace sportdag.ExtensionMethods {

    public static class ConsoleFunctions {

        public static string GetInput( string message ) {
            Console.Write( message );
            return Console.ReadLine();
        }

        public static string[] GetInputs( string[] messages, string quitOnFind ) {
            string[] answers = new string[messages.Length];

            for ( int messageIndex = 0; messageIndex < messages.Length;  messageIndex += 1 ) {
                string input = GetInput( messages[messageIndex] );

                if ( input.ToLower() == quitOnFind.ToLower() ) {
                    return null;
                }

                answers[messageIndex] = input;
            }

            return answers;
        }
    }
}
