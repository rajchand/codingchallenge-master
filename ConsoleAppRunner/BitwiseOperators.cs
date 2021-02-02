using System;

namespace ConsoleAppRunner
{
    public static class BitwiseOperators
    {
        // https://www.programiz.com/csharp-programming/bitwise-operators
        // C# provides 4 bitwise and 2 bit shift operators.

        // Binary 0000 0000 It is 0 and 1
        // Values 128 64 32 16 8 4 2 1

        // Decimal number 0000 0000 It is base 10 
        // 0 1 2 3 4 5 6 7 8 9
            
        public static int BitwiseAnd(int firstNumber, int secondNumber)
        {
            // &	Bitwise AND - 2 operands - If any bit contains 0, the result is 0
            // 14 = 00001110 (In Binary)
            // 11 = 00001011 (In Binary)
            // -----------------------------
            //      00001010 = 10 in decimal

            int result = firstNumber & secondNumber;
            Console.WriteLine("{0} & {1} = {2}", firstNumber, secondNumber, result);
            return result;
        }

        public static int BitwiseOR(int firstNumber, int secondNumber)
        {
            // |	Bitwise OR - 2 operands - If either of the bits is 1, the result is 1
            // 14 = 00001110 (In Binary)
            // 11 = 00001011 (In Binary)
            //-----------------------------
            //      00001111 = 15 in decimal

            int result = firstNumber | secondNumber;
            Console.WriteLine("{0} | {1} = {2}", firstNumber, secondNumber, result);
            return result;
        }

        public static int BitwiseXOR(int firstNumber, int secondNumber)
        {
            // ^	Bitwise XOR (Exclusive) - 2 operands - If bits are same then 0. If different then result is 1
            // 14 = 00001110 (In Binary)
            // 11 = 00001011 (In Binary)
            //-----------------------------
            //      00000101 = 5 in decimal

            int result = firstNumber ^ secondNumber;
            Console.WriteLine("{0} ^ {1} = {2}", firstNumber, secondNumber, result);
            return result;
        }

        public static int BitwiseComplement(int number)
        {
            // ~	Bitwise Complement - 1 operand - It inverts each bit 1 = 0, 0 = 1
            // 26 = 00011010 (In Binary)
            //-----------------------------
            //      11100101 = 229 in decimal
            // Output is -27 because its a 2's complement representation of -27. 2's complement of n = -(n+1)
            // 229	11100101	-(00011010 + 1) = -00011011 = -27

            int result = ~number;
            Console.WriteLine("~ {0} = {1}", number, result);
            return result;
        }

        public static int BitwiseLeftShift(int number, int bit)
        {
            // <<	Bitwise Left Shift - operator shifts a number to the left by a specified number of bits. Zeroes are added to the least significant bits
            // decimal equivilent to num * 2bits
            // 42 = 101010 (In binary)

            // 42 << 1 bit  = 84  (In binary 1010100)
            // 42 << 2 bits = 168 (In binary 10101000)
            // 42 << 4 bits = 672 (In binary 101010000)
            int result = number << bit;
            Console.WriteLine("{0}<<{1} = {2}", number, bit, result);
            return result;            
        }

        public static int BitwiseRightShift(int number, int bit)
        {
            // >>	Bitwise Right Shift - operator shifts a number to the right by a specified number of bits. The first operand is shifted to right by the number of bits specified by second operand.
            // decimal equivilent to floor(num / 2bits)
            // 42 = 101010 (In binary)

            // 42 >> 1 bit  = 21  (In binary 010101)
            // 42 >> 2 bits = 10  (In binary 001010)
            // 42 >> 4 bits = 2   (In binary 000010)

            int result = number >> bit;
            Console.WriteLine("{0}>>{1} = {2}", number, bit, result);
            return result;
        }
    }

}
