using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace SpeakToMe
{
    public class Narrator
    {
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

        public void saySomething(String message)
        {
            speechSynthesizer.Speak(message);
        }
    }
}
