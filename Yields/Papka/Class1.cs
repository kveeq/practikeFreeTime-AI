using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yields.Papka
{
    public class Class1
    {
        public static Action<string> messAction;

        private static async Task<Result?> Formirovanie(int i)
        {
            return await Task.Run(async () => await Print(await GetString(i)));
        }

        public static async Task<Result> OtchetFormirovanie(int i)
        {
            return await Task.Run(async () => await Formirovanie(i) ?? Result.Bad);
        }

        private static async Task<string> GetString(int i)
        {
            return await Task.Run(() => $"{i}) string");
        }

        private static async Task<Result> Print(string str)
        {
            await Task.Run(() => messAction?.Invoke(str));
            await Task.Delay(100);
            if (str == "5")
                return Result.Bad;

            return Result.Succes;
        }
    }

    public enum Result
    {
        Succes,
        Bad,
        Warning
    }
}
