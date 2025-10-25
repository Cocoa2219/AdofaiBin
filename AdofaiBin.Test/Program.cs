using System;
using System.IO;
using AdofaiBin.Serialization.Encoding;

namespace AdofaiBin.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var file = "level.adofai";
            if (!File.Exists(file))
            {
                file = "main.adofai";
                if (!File.Exists(file))
                {
                    Console.WriteLine("No .adofai file found in the current directory.");
                    return;
                }
            }

            var encoder = new AdofaiBinEncoder(new EncodingOptions()
            {
                LeaveOpen = true
            });

            using var fs = File.OpenWrite("out.adobin");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(!encoder.TryEncodeFromFile(file, fs, out var error)
                ? $"Encoding failed: {error}, took {sw.ElapsedMilliseconds} ms."
                : "Encoding succeeded: out.adobin created, total of " + fs.Length + $" bytes, took {sw.ElapsedMilliseconds} ms.");

            fs.Close();
        }
    }
}