/// <summary>
/// The method OldPhonePad will turn any input to OldPhonePad into the correct output.
/// </summary>
namespace OldPhoneSimulator
{
    public class OldPhoneSimulator
    {
        public static string OldPhonePad(string buttonSequence)
        {
            // Store the mobile keypad mappings
            string[] nums = { " ", "", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };

            char[] resultChars = new char[buttonSequence.Length];
            int resultIndex = 0;

            // Traverse the button sequence
            int i = 0;
            while (i < buttonSequence.Length)
            {
                char currentChar = buttonSequence[i];

                if (IsSpecialCharacter(currentChar))
                {
                    if (currentChar == '*' && resultIndex > 0)
                    {
                        // Delete the previous character if available
                        resultIndex--;
                    }
                    i++;
                    continue;
                }

                // Stores the number of continuous clicks
                int count = 0;

                // Iterate to find the count of same characters
                while (HasNextChar(buttonSequence, i) && buttonSequence[i] == buttonSequence[i + 1])
                {
                    count++;
                    i++;
                }

                char currentKey = buttonSequence[i];

                // Check if the current pressed key is 7 or 9
                if (IsSevenOrNine(currentKey))
                {
                    resultChars[resultIndex++] = nums[currentKey - '0'][count % 4];
                }
                else
                {
                    resultChars[resultIndex++] = nums[currentKey - '0'][count % 3];
                }

                i++;
            }

            return new string(resultChars, 0, resultIndex);
        }

        private static bool IsSpecialCharacter(char c)
        {
            return c == ' ' || c == '*' || c == '#';
        }

        private static bool HasNextChar(string str, int currentIndex)
        {
            return currentIndex + 1 < str.Length;
        }

        private static bool IsSevenOrNine(char key)
        {
            return key == '7' || key == '9';
        }

        public static void Main()
        {
            string? buttonSequence;

            Console.WriteLine("Enter button sequences. Enter an empty string to exit.");

            while (true)
            {
                Console.Write("Button sequence: ");

                if (!string.IsNullOrEmpty(buttonSequence = Console.ReadLine()))
                {
                    string result = OldPhonePad(buttonSequence);
                    Console.WriteLine("Result: " + result);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Program exited.");
                    Console.WriteLine();
                    break;
                }
            }
        }
    }
}
