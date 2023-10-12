using System;

namespace UtilitiesLib
{
    public class Helper
    {

        bool StringToInt(string input, out int output)
        {
            return int.TryParse(input, out output);
        }

        bool StringToFloat(string input, out float output)
        {
            return float.TryParse(input, out output);
        }

        bool StringToInt(string input, out int output, int lowLimit, int highLimit)
        {
            if (int.TryParse(input, out output))
            {
                if (output >= lowLimit && output <= highLimit)
                {
                    return true;
                }               
            }           
            return false;
        }

        bool StringToFloat(string input, out float output, float lowLimit, float highLimit)
        {
            if (float.TryParse(input, out output))
            {

                if (output >= lowLimit && output <= highLimit)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
