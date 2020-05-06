using System;
using System.Threading.Tasks;
using HttpsNETCoreLog;
using HttpsNETCoreLog.Models;

namespace UseNetCoreLog.Data
{
    public class LogyhogService
    {

        /// <summary>
        /// if return: -1(error), 1(pass), 0(fail)
        /// </summary>
        /// <param name="datasetname">string</param>
        /// <param name="x">int</param>
        /// <param name="y">int</param>
        /// <returns>Task.FromResult</returns>
        public int GetPassFail(string datasetname, int x, int y)
        {
            TaskUser TU = new TaskUser("https://api.logyhog.com/api/", "66JCV1", "testdoggy", $"blazor{RandomString(6)}");
            TU.Setlimits("44", 5, 5, 3, 3);
            var response = TU.XY(datasetname, x, y);
            //-1 is a error
            if (response == null) return -1;
            if (response is Rectangle)
            {
                if (response is Rectangle && response.DatasetID < 0)
                    return 0;
                else
                    return -1;
            }
            return -1;
        }

        public static string RandomString(int length)
        {
            var chars = "78UVWXYZ01234ABCDNOPQRSGHIJKLM569TEF";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
                stringChars[i] = chars[random.Next(chars.Length)];

            return new String(stringChars);
        }
    }
}
