using ScreenRecordedSoft.Capture;
using System;
using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenRecordedSoft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rec = new Recorder(new RecorderParams("out.mp4", 10, SharpAvi.KnownFourCCs.Codecs.Xvid, 70));
            Console.WriteLine("Press any key to Stop...");
            Console.ReadKey();

            // Finish Writing
            rec.Dispose();
        }
    }
}
