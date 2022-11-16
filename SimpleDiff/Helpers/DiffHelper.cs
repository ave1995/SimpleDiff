namespace SimpleDiff.Helpers
{
    public static class DiffHelper
    {
        /// <summary>
        /// Algorithm for calculating the difference
        /// </summary>
        /// <param name="leftInput"></param>
        /// <param name="rightInput"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public static Dictionary<int, int> GetDiff(string leftInput, string rightInput)
        {
            //Checking equal length inputs
            if (!leftInput.Length.Equals(rightInput.Length))
            {
                throw new ApplicationException("input must have same lenght");
            }
            //a dictionary for storing offsets
            var offsetsLengthsDic = new Dictionary<int, int>();
            //a variable for storing offset
            int? offset = null;
            //a variable for storing length
            var length = 0;
            //iterations of both inputs
            for (var i = 0; i < leftInput.Length; i++)
            {
                //when the char of left input with index=i is not equal to the char of right input with index=i 
                if (!leftInput[i].Equals(rightInput[i]))
                {
                    offset ??= i;   //i will set offset if offset is null
                    length++;       //i will add the lenght
                    continue;       //and I am going to the next round of iterations
                }

                if (offset is null) continue;   //if offset is null i know there is no change and I am going to the next round of iterations

                offsetsLengthsDic.Add(offset.Value, length);    //I store offset and lenght, because the char of left input with index=i is equal to the char of right input with index=i and offset is not null
                offset = null;                                  //reset offset for future rounds of iterations
                length = 0;                                     //reset length for future rounds of iterations
            }

            if (offset is not null) //last check and store, because the iterations could have ended without char equality
            {
                offsetsLengthsDic.Add(offset.Value, length);
            }

            return offsetsLengthsDic;   //return dictionary key like offset and value like lenght
        }
    }
}