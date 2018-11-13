using System;
/*Implement atoi which converts a string to an integer.

The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. 
Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, 
and interprets them as a numerical value.

The string can contain additional characters after those that form the integral number, which are ignored and have no effect 
on the behavior of this function.

If the first sequence of non-whitespace characters in str is not a valid integral number, 
or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

If no valid conversion could be performed, a zero value is returned.

Note:

Only the space character ' ' is considered as whitespace character.
Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: 
[−2^31,  2^31 − 1]. If the numerical value is out of the range of representable values, INT_MAX (2^31 − 1) or INT_MIN (−2^31) is returned.
Example 1:

Input: "42"
Output: 42
Example 2:

Input: "   -42"
Output: -42
Explanation: The first non-whitespace character is '-', which is the minus sign.
             Then take as many numerical digits as possible, which gets 42.
Example 3:

Input: "4193 with words"
Output: 4193
Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.
Example 4:

Input: "words and 987"
Output: 0
Explanation: The first non-whitespace character is 'w', which is not a numerical 
             digit or a +/- sign. Therefore no valid conversion could be performed.
Example 5:

Input: "-91283472332"
Output: -2147483648
Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
             Thefore INT_MIN (−231) is returned.
 * */
namespace Atoi
{
    public class Solution
    {
        public static int MyAtoi(string str)
        {
            int rem = 0, sign = 1;
            int result = 0;
            bool flag_first = true, number_met = false;
            int number_next = 0;

            for (int i = 0; i < str.Length; i++)
            {
                char x = str[i];
                int y = (int)x;
                if (flag_first)
                {
                    /*
                     * ' ' =>32
                     * '+' =>43 y == 43 ||
                     * '-' =>45
                     * '0'....'9' => 48...57
                     * */
                    if (y == 32 || y == 43 || y == 45 || str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4'
                                || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9')
                    {
                        if (y == 32 && number_next > 0)
                            return result * sign;
                        if (y == 32 && number_met)
                            return result * sign;

                        if (y == 45 && number_next < 2) // '-'
                        {
                            if (number_met)
                                return result * sign;
                            sign = -1;
                            number_next ++;
                        }
                        else if (y == 43 && number_next < 2) // '+'
                        {
                            if (number_met)
                                return result * sign;
                            number_next ++;
                        }
                        else if ((str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4'
                                || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9') && number_next < 2)
                        {
                            number_met = true;
                            rem = str[i] - '0';
                            if (result * sign > Int32.MaxValue / 10 || (result * sign == Int32.MaxValue / 10 && rem * sign > 7))
                                return Int32.MaxValue;
                            if (result * sign < Int32.MinValue / 10 || (result * sign == Int32.MinValue / 10 && rem * sign < -8))
                                return Int32.MinValue;

                            result = result * 10 + rem;

                        }

                    }
                    else
                        flag_first = false;
                }


            }
            return result * sign;
        }
  

        public static void Main(string[] args)
        {
            string ss = "0 123";
            int num = MyAtoi(ss);
            Console.WriteLine(num);
        }
    }
}
