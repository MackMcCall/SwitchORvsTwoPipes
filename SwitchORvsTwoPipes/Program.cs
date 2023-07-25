using System.Threading.Channels;

namespace SwitchORvsTwoPipes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //So it seems that in the more recent versions of C# there is an easy way to include multiple options for a case in a switch statement.
            //This is in contrast to the old convention of stating a case and its value multiple times before the body and the break.
            
            Console.WriteLine("What is your favorite cardinal direction?");
            string direction = Console.ReadLine();

            switch (direction)
            {
                case "north":
                    Console.WriteLine("NORTH");
                    break;
                case "east":
                    Console.WriteLine("EAST");
                    break;

                //This is the "or" in action.
                case "south" or "west":
                    Console.WriteLine("SOUTH, WEST");
                    break;

                /* This commented out case would not work, as it uses the two pipes (logical OR operator). 
                 * 
                 * case "south" || "west":
                 *    Console.WriteLine("SOUTH, WEST");
                 *    break;
                 */
                default:
                    Console.WriteLine("invalid input");
                    break;
            }

            Console.WriteLine("What is your favorite number from 1 to 5?");
            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Console.WriteLine("ONE");
                    break;
                case 2:
                    Console.WriteLine("TWO");
                    break;
                //This "or" works on as many case parameters as you would want:
                case 3 or 4 or 5:
                    Console.WriteLine("THREE, FOUR, FIVE");
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }

            /*  Now, why does "or" work and "||" does not?
             *  
             *  There are two reasons why the || operator cannot be used.
             *  
             *  They both find their roots in the fact that the logical OR operator ("||") returns a boolean value. 
             *  First, since a boolean value is returned, the case above would simplify to either "case: true" or "case: false".
             *  When we pass in the "direction" variable it is compared to the value of the case. 
             *  We know that if the switch value is equal to ("==") the case value, then the statements in that case run.
             *  Given that neither "true" nor "false" == "south" or "west", the switch vs case comparison can never evaluate to true, and the case can never run.
             * 
             * This is furthered by the fact that the value of a case must be the same value type as the switch value. (bool is not string)
             * 
             * Secondly, the case value must be a constant. 
             * Given that the || operator takes two operands and outputs either true or false, by nature the expression is not a constant.
             * There is some amount of ambiguity that cannot be resolved within the case statement. 
             * 
             * Thanks to Erik for asking why "or" works and "||" doesn't. Always ponder the whys.
             */
        }
    }
}