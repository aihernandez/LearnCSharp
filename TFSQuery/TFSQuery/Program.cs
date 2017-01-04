﻿using System;

namespace TFSQuery
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                DoQuerying();
                Console.ReadLine();
            }
        }

        private static async void DoQuerying()
        {
            var query = new QueryForChanges();
            await query.GetTopChangedFiles();
        }
    }
}